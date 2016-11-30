using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnTaskV2.Models;
using OnTaskV2.Models.DataModels;
using OnTaskV2.Models.ViewModels;
using OnTaskV2.DAL;
using OnTaskV2.BLL;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace OnTaskV2.Controllers
{
    public class TrafficAnalyzerController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private IHistoricDataService _historicDataService;
        private IStoreAttributeService _storeAttributeService;
        public TrafficAnalyzerController()
        {
            _historicDataService = new HistoricDataService(db);
            _storeAttributeService = new StoreAttributeService(db);
        }


        // GET: TrafficAnalyzer
        public ActionResult Index()
        {
            ViewBag.StoresList = new SelectList(db.Stores, "ID", "NumberName");
            return View();
        }

        [HttpPost]
        public ActionResult WeekTable(int storeId, DateTime date, decimal? star)
        {
            var store = db.Stores.Find(storeId);
            var sundayDate = date.AddDays(DayOfWeek.Sunday - date.DayOfWeek);
            var timeInc = 7; // 7=daily
            var table = new TA_Table()
            {
                InputStoreId = storeId,
                InputDate = date,
                InputSTAR = star,
                BaseHours = 0.0M,
                BudgetHours = 0.0M,
                NonSellHours = 0.0M,
                SellingHours = 0.0M,
                ActualHours = new decimal[timeInc],
                RecommendHours = new decimal[timeInc],
                AdjustHours = new decimal[timeInc],
                ConversionPercent = new decimal[timeInc],
                TrafficTY = new decimal[timeInc],
                TrafficLY = new decimal[timeInc],
                Transactions = new decimal[timeInc],
                TrafficPercent = new decimal[timeInc],
                TPLH = new decimal[timeInc],
                PlusMinusHours = new decimal[timeInc],
                StartTime = sundayDate,
                EndTime = sundayDate.AddDays(timeInc),
                Sales = new decimal[timeInc],
                AvgTransactions = new decimal[timeInc],
            };
            table.TimeIncrement = new TimeSpan((table.EndTime - table.StartTime).Ticks / timeInc);
            
            table.ActualHours = _historicDataService.GetDriverVolumeForWeekByDay("LaborHours", store.Number, sundayDate);
            table.TrafficLY = _historicDataService.GetDriverVolumeForWeekByDay("Traffic", store.Number, date.AddYears(-1).AddDays(DateHelper.AddDayOffsetToLY(sundayDate))); //adding days keeps on the same day of week
            table.TrafficTY = _historicDataService.GetDriverVolumeForDayBy15min("Traffic", store.Number, sundayDate);
            table.Transactions = _historicDataService.GetDriverVolumeForDayBy15min("Transactions", store.Number, sundayDate);

            var totalTraffic = table.TrafficTY.Sum();
            for (int i = 0; i < timeInc; i++)
            {
                if (table.Transactions[i] > 0)
                {
                    table.ConversionPercent[i] = table.Transactions[i] / table.TrafficTY[i];
                }
                else
                {
                    table.ConversionPercent[i] = 0.0M;
                }
                if (totalTraffic > 0)
                {
                    table.TrafficPercent[i] = table.TrafficTY[i] / totalTraffic;
                }
                else
                {
                    table.TrafficPercent[i] = 0.0M;
                }
                if (star != null && star > 0) //if star is null, set to 0
                {
                    table.RecommendHours[i] = (table.TrafficTY[i] / Convert.ToDecimal(star));
                }
                else
                {
                    table.RecommendHours[i] = 0.0M;
                }
                table.AdjustHours[i] = table.RecommendHours[i]; //default set adjusted hours to recommended hours
                if (table.ActualHours[i] > 0)
                {
                    table.TPLH[i] = table.TrafficTY[i] / table.ActualHours[i];
                }
                else
                {
                    table.TPLH[i] = 0.0M;
                }
                table.PlusMinusHours[i] = table.ActualHours[i] - table.RecommendHours[i];
            }
            table.TargetSTAR = Convert.ToDecimal(star);
            return PartialView("_WeekTable-Static", table);
        }


        [HttpPost]
        public PartialViewResult DayTable(int storeId, DateTime date, decimal? star)
        {
            var timeInc = 24; //96 = 15 minute increments, 24 = hourly
            //timeInc = GetTimeInc(); //TODO: create function
            var store = db.Stores.Find(storeId);
            string openTimeAttr = date.DayOfWeek.ToString() + "Open";
            string closeTimeAttr = date.DayOfWeek.ToString() + "Close";
            var table = new TA_Table()
            {
                InputStoreId = storeId,
                InputDate = date,
                InputSTAR = star,
                BaseHours = 0.0M,
                BudgetHours = 0.0M,
                NonSellHours = 0.0M,
                SellingHours = 0.0M,
                ActualHours = new decimal[timeInc],
                RecommendHours = new decimal[timeInc],
                AdjustHours = new decimal[timeInc],
                ConversionPercent = new decimal[timeInc],
                TrafficTY = new decimal[timeInc],
                TrafficLY = new decimal[timeInc],
                Transactions = new decimal[timeInc],
                TrafficPercent = new decimal[timeInc],
                TPLH = new decimal[timeInc],
                PlusMinusHours = new decimal[timeInc],
                StartTime = Convert.ToDateTime(store.Attributes.Where(a=>a.Name == openTimeAttr).FirstOrDefault()?.Value),
                EndTime = Convert.ToDateTime(store.Attributes.Where(a => a.Name == closeTimeAttr).FirstOrDefault()?.Value),
            };
            table.TimeIncrement = new TimeSpan((table.EndTime - table.StartTime).Ticks / timeInc);
            try
            {
                table.BaseHours = _storeAttributeService.GetOpenHoursSum(store, date) * Convert.ToDecimal(store.Attributes.Where(a => a.Name == "Minimum Coverage").First().Value);
            }
            catch
            {
            }

            table.BudgetHours = _historicDataService.GetDriverVolumeSumByWeek("LaborHours", store.Number, date) * (_historicDataService.GetDriverVolumeSumByDay("Traffic", store.Number, date) / _historicDataService.GetDriverVolumeSumByWeek("Traffic", store.Number, date)); // (LaborHours) * (DailyTrafficPercentOfWeek)
            //table.NonSellHours =

            table.SellingHours = table.BudgetHours - table.BaseHours - table.NonSellHours;
            if(timeInc == 96)
            {
                table.ActualHours = _historicDataService.GetDriverVolumeForDayBy15min("LaborHours", store.Number, date);
                table.TrafficLY = _historicDataService.GetDriverVolumeForDayBy15min("Traffic", store.Number, date.AddYears(-1).AddDays(DateHelper.AddDayOffsetToLY(date))); //adding days keeps on the same day of week
                table.TrafficTY = _historicDataService.GetDriverVolumeForDayBy15min("Traffic", store.Number, date);
                table.Transactions = _historicDataService.GetDriverVolumeForDayBy15min("Transactions", store.Number, date);
            }
            else if(timeInc == 24)
            {
                table.ActualHours = _historicDataService.GetDriverVolumeForDayByHour("LaborHours", store.Number, date);
                table.TrafficLY = _historicDataService.GetDriverVolumeForDayByHour("Traffic", store.Number, date.AddYears(-1).AddDays(DateHelper.AddDayOffsetToLY(date))); //adding days keeps on the same day of week
                table.TrafficTY = _historicDataService.GetDriverVolumeForDayByHour("Traffic", store.Number, date);
                table.Transactions = _historicDataService.GetDriverVolumeForDayByHour("Transactions", store.Number, date);
            }


            var totalTraffic = table.TrafficTY.Sum();
            for(int i=0; i<timeInc;i++)
            {
                if(table.Transactions[i] > 0)
                {
                    table.ConversionPercent[i] = table.Transactions[i] / table.TrafficTY[i];
                }
                else
                {
                    table.ConversionPercent[i] = 0.0M;
                }
                if(totalTraffic > 0)
                {
                    table.TrafficPercent[i] = table.TrafficTY[i] / totalTraffic;
                }
                else
                {
                    table.TrafficPercent[i] = 0.0M;
                }
                if(star != null && star > 0) //if star is null, set to 0
                {
                    table.RecommendHours[i] = (table.TrafficTY[i] / Convert.ToDecimal(star));
                }
                else
                {
                    table.RecommendHours[i] = 0.0M;
                }
                table.AdjustHours[i] = table.RecommendHours[i]; //default set adjusted hours to recommended hours
                if(table.ActualHours[i] > 0)
                {
                    table.TPLH[i] = table.TrafficTY[i] / table.ActualHours[i];
                }
                else
                {
                    table.TPLH[i] = 0.0M;
                }
                table.PlusMinusHours[i] = table.ActualHours[i] - table.RecommendHours[i];
            }

            table.TargetSTAR = Convert.ToDecimal(star);
            return PartialView("_DayTable-Static",table);
        }
    }
}