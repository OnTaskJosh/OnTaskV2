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
        public ActionResult DayTable(int storeId, DateTime date, decimal? star)
        {
            var store = db.Stores.Find(storeId);
            var table = new TA_Table()
            {
                BaseHours = 0.0M,
                BudgetHours = 0.0M,
                NonSellHours = 0.0M,
                SellingHours = 0.0M,
                ActualHours = new decimal[96],
                RecommendHours = new decimal[96],
                AdjustHours = new decimal[96],
                ConversionPercent = new decimal[96],
                TrafficTY = new decimal[96],
                TrafficLY = new decimal[96],
                Transactions = new decimal[96],
                TrafficPercent = new decimal[96],
                TPLH = new decimal[96],
                PlusMinusHours = new decimal[96],
            };

            try
            {
                table.BaseHours = _storeAttributeService.GetOpenHoursSum(store, date) * Convert.ToDecimal(store.Attributes.Where(a => a.Name == "Minimum Coverage").First().Value);
            }
            catch
            {
            }

            table.BudgetHours = _historicDataService.GetDriverVolumeByWeek("LaborHours", store.Number, date) * (_historicDataService.GetDriverVolumeByDay("Traffic", store.Number, date) / _historicDataService.GetDriverVolumeByWeek("Traffic", store.Number, date)); // (LaborHours) * (DailyTrafficPercentOfWeek)
            //table.NonSellHours =

            table.SellingHours = table.BudgetHours - table.BaseHours - table.NonSellHours;
            table.ActualHours = _historicDataService.GetDriverVolumeBy15min("LaborHours",store.Number, date);
            
            table.TrafficLY = _historicDataService.GetDriverVolumeBy15min("Traffic", store.Number, date.AddYears(-1).AddDays(DateHelper.AddDayOffsetToLY(date))); //adding days keeps on the same day of week
            table.TrafficTY = _historicDataService.GetDriverVolumeBy15min("Traffic",store.Number, date);
            table.Transactions = _historicDataService.GetDriverVolumeBy15min("Transactions", store.Number, date);

            var totalTraffic = table.TrafficTY.Sum();
            for(int i=0; i<96;i++)
            {
                if(table.Transactions[i] > 0)
                {
                    table.ConversionPercent[i] = table.Transactions[i] / table.Transactions[i];
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
            
            return PartialView("_DayTable",table);
        }
    }
}