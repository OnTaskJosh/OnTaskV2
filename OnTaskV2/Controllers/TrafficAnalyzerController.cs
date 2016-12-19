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
            var client = "NRF Demo"; //TODO: change to User's client or client selector for Claris users
            var taIndex = new TAIndex() {
                OrgHierarchy = db.OrgHierarchy.Where(o => o.Client.Name == client).Include(o=>o.Countries).FirstOrDefault(),
            }; 
            ViewBag.StoresList = new SelectList(db.Stores, "ID", "NumberName");
            return View("Index", taIndex);
        }

        [HttpPost]
        public ActionResult WeekTable(int storeId, DateTime date, decimal? baseStar, decimal? peakStar)
        {
            var store = db.Stores.Find(storeId);
            var sundayDate = date.AddDays(DayOfWeek.Sunday - date.DayOfWeek);
            var timeInc = 7; // 7=daily
            var table = new TA_Table()
            {
                InputStoreId = storeId,
                InputDate = date,
                InputBaseSTAR = baseStar,
                InputPeakSTAR = peakStar,
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
                TimePeriod = new string[timeInc],
            };
            table.TimeIncrement = (timeInc != 0) ? new TimeSpan((table.EndTime - table.StartTime).Ticks / timeInc) : new TimeSpan(0);

            table.ActualHours = _historicDataService.GetDriverVolumeForWeekByDay("LaborHours", store.Number, sundayDate);
            table.TrafficLY = _historicDataService.GetDriverVolumeForWeekByDay("Traffic", store.Number, date.AddYears(-1).AddDays(DateHelper.AddDayOffsetToLY(sundayDate))); //adding days keeps on the same day of week
            table.TrafficTY = _historicDataService.GetDriverVolumeForWeekByDay("Traffic", store.Number, sundayDate);
            table.Transactions = _historicDataService.GetDriverVolumeForWeekByDay("Transactions", store.Number, sundayDate);
            table.Sales = _historicDataService.GetDriverVolumeForWeekByDay("Sales", store.Number, sundayDate);

            var totalTraffic = table.TrafficTY.Sum();
            for (int i = 0; i < timeInc; i++)
            {
                table.TimePeriod[i] = table.StartTime.Add(new TimeSpan(table.TimeIncrement.Ticks * i)).ToShortTimeString();
                table.ConversionPercent[i] = (table.TrafficTY[i] != 0) ? (table.Transactions[i] / table.TrafficTY[i]) : 0.0M ;
                table.TrafficPercent[i] = (totalTraffic > 0) ? (table.TrafficTY[i] / totalTraffic) : 0.0M;
                table.AdjustHours[i] = table.RecommendHours[i]; //default set adjusted hours to recommended hours
                table.TPLH[i] = (table.ActualHours[i] > 0) ? (table.TrafficTY[i] / table.ActualHours[i]) : 0.0M;
                table.AvgTransactions[i] = (table.Sales[i] > 0) ? (table.Sales[i] / table.Transactions[i]) : 0.0M;
                //table.RecommendHours[i] = (star != null && star > 0) ? (table.TrafficTY[i] / Convert.ToDecimal(star)) : 0.0M; //TODO: Doesn't break day hours into peak & base star
                //table.PlusMinusHours[i] = table.ActualHours[i] - table.RecommendHours[i]; //TODO: Doesn't break day hours into peak & base star
            }
            table.TargetBaseSTAR = Convert.ToDecimal(baseStar);
            table.TargetPeakSTAR = Convert.ToDecimal(peakStar);
            return PartialView("_WeekTable-Static", table);
        }


        [HttpPost]
        public PartialViewResult DayTable(int storeId, DateTime date, decimal? baseStar, decimal? peakStar)
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
                InputBaseSTAR = baseStar,
                InputPeakSTAR = peakStar,
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
                IsPeakPeriod = new bool[timeInc],
                TimePeriod = new string[timeInc],
            };
            table.TimeIncrement = (timeInc != 0) ? (new TimeSpan((table.EndTime - table.StartTime).Ticks / timeInc)) : (new TimeSpan(0));
            try
            {
                table.BaseHours = _storeAttributeService.GetOpenHoursSum(store, date) * Convert.ToDecimal(store.Attributes.Where(a => a.Name == "Minimum Coverage").First().Value);
            }
            catch
            {
            }

            var totalWeekTraffic = _historicDataService.GetDriverVolumeSumByWeek("Traffic", store.Number, date);
            var totalWeekLaborHours = _historicDataService.GetDriverVolumeSumByWeek("LaborHours", store.Number, date);
            table.BudgetHours = (totalWeekTraffic != 0) ? (totalWeekLaborHours * (_historicDataService.GetDriverVolumeSumByDay("Traffic", store.Number, date) / totalWeekTraffic)) : 0.0M; // (LaborHours) * (DailyTrafficPercentOfWeek)
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
                table.TimePeriod[i] = table.StartTime.Add(new TimeSpan(table.TimeIncrement.Ticks * i)).ToShortTimeString();
                table.ConversionPercent[i] = (table.Transactions[i] > 0) ? (table.Transactions[i] / table.TrafficTY[i]) : 0.0M;
                table.TrafficPercent[i] = (totalTraffic > 0) ? (table.TrafficTY[i] / totalTraffic) : 0.0M;
                table.AdjustHours[i] = table.RecommendHours[i]; //default set adjusted hours to recommended hours
                table.TPLH[i] = (table.ActualHours[i] > 0) ? (table.TrafficTY[i] / table.ActualHours[i]) : 0.0M;
                if (timeInc == 96)
                {
                    //TODO: replace percent with store attribute
                    table.IsPeakPeriod[i] = table.TrafficPercent[i] >= .0225M ? true : false; //15-min increment greater than 2.25% of total daily traffic
                }
                else if (timeInc == 24)
                {
                    //TODO: replace percent with store attribute
                    table.IsPeakPeriod[i] = table.TrafficPercent[i] >= .09M ? true : false; //hourly increment greater than 9% of total daily traffic 
                }
                if(table.IsPeakPeriod[i])
                {
                    table.RecommendHours[i] = (peakStar != null && peakStar > 0) ? TrafficAnalyzerHelper.RecommendedHour(table.TrafficTY[i], peakStar) : ((baseStar != null && baseStar > 0) ? TrafficAnalyzerHelper.RecommendedHour(table.TrafficTY[i], baseStar) : 0.0M);
                }
                else
                {
                    table.RecommendHours[i] = TrafficAnalyzerHelper.RecommendedHour(table.TrafficTY[i], baseStar);
                }
                table.PlusMinusHours[i] = table.RecommendHours[i] - table.ActualHours[i];
            }

            table.TargetBaseSTAR = Convert.ToDecimal(baseStar);
            table.TargetPeakSTAR = Convert.ToDecimal(peakStar);
            return PartialView("_DayTable-Static",table);
        }
        

        [HttpPost]
        public ActionResult WeekScatterChart_Star_Conv(int storeId, DateTime date, decimal? baseStar, decimal? peakStar)
        {
            var store = db.Stores.Find(storeId);
            var sundayDate = date.AddDays(DayOfWeek.Sunday - date.DayOfWeek);
            var timeInc = 24*7; // 24 hrs, 7 days
            var table = new TA_Table()
            {
                InputStoreId = storeId,
                InputDate = date,
                InputBaseSTAR = baseStar,
                InputPeakSTAR = peakStar,
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
                TimePeriod = new string[timeInc],
            };
            table.TimeIncrement = (timeInc != 0) ? (new TimeSpan((table.EndTime - table.StartTime).Ticks / timeInc)) : (new TimeSpan(0));

            table.ActualHours = _historicDataService.GetDriverVolumeForWeekByHour("LaborHours", store.Number, sundayDate);
            table.TrafficLY = _historicDataService.GetDriverVolumeForWeekByHour("Traffic", store.Number, date.AddYears(-1).AddDays(DateHelper.AddDayOffsetToLY(sundayDate))); //adding days keeps on the same day of week
            table.TrafficTY = _historicDataService.GetDriverVolumeForWeekByHour("Traffic", store.Number, sundayDate);
            table.Transactions = _historicDataService.GetDriverVolumeForWeekByHour("Transactions", store.Number, sundayDate);
            table.Sales = _historicDataService.GetDriverVolumeForWeekByHour("Sales", store.Number, sundayDate);

            var totalTraffic = table.TrafficTY.Sum();
            for (int i = 0; i < timeInc; i++)
            {
                table.TimePeriod[i] = table.StartTime.Add(new TimeSpan(table.TimeIncrement.Ticks * i)).ToShortTimeString();
                table.ConversionPercent[i] = (table.Transactions[i] > 0) ? (table.Transactions[i] / table.TrafficTY[i]) : 0.0M ;
                table.TrafficPercent[i] = (totalTraffic > 0) ? (table.TrafficTY[i] / totalTraffic) : 0.0M;
                table.AdjustHours[i] = table.RecommendHours[i]; //default set adjusted hours to recommended hours
                table.TPLH[i] = (table.ActualHours[i] > 0) ? (table.TrafficTY[i] / table.ActualHours[i]) : 0.0M;
                //table.RecommendHours[i] = (baseStar != null && baseStar > 0) ? (table.TrafficTY[i] / Convert.ToDecimal(baseStar)) : 0.0M;
                //table.PlusMinusHours[i] = table.ActualHours[i] - table.RecommendHours[i];
                table.AvgTransactions[i] = (table.Sales[i] > 0) ? (table.Sales[i] / table.Transactions[i]) : 0.0M;
            }
            table.TargetBaseSTAR = Convert.ToDecimal(baseStar);
            table.TargetPeakSTAR = Convert.ToDecimal(peakStar);
            return PartialView("_WeekScatterChart_StarConv", table);
        }
    }
}