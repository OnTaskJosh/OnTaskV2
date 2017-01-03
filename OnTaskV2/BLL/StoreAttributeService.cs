using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnTaskV2.Models;
using OnTaskV2.Models.DataModels;
using OnTaskV2.DAL;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace OnTaskV2.BLL
{
    public class StoreAttributeService : IStoreAttributeService
    {
        private DatabaseContext db;
        public StoreAttributeService(DatabaseContext _db)
        {
            db = _db;
        }

        public decimal GetOpenHoursSum(Store store, DateTime date)
        {
            TimeSpan openHours = TimeSpan.Zero;
            try
            {
                DateTime openTime = DateTime.Parse(store.Attributes.Where(d => d.Name == (date.DayOfWeek.ToString() + "Open")).FirstOrDefault().Value); //e.g. Name == SundayOpen
                DateTime closeTime = DateTime.Parse(store.Attributes.Where(d => d.Name == (date.DayOfWeek.ToString() + "Close")).FirstOrDefault().Value); //e.g. Name == SundayClose
                openHours = closeTime - openTime;
            }
            catch
            {
            }
            return Convert.ToDecimal(openHours.TotalHours);
        }

        public decimal GetBaseCoverageSum(Store store, DateTime date)
        {
            decimal[] baseCovArr = new decimal[96]; //time increment = 15 minutes
            string baseCovAttr = date.DayOfWeek.ToString() + "BaseCoverage";
            try
            {
                string baseCovStr = store.Attributes.Where(a => a.Name == baseCovAttr).FirstOrDefault().Value; //e.g. Name == SundayBaseCoverage
                baseCovArr = baseCovStr.Split(',').Select(decimal.Parse).ToArray();
            }
            catch
            {
            }
            return Convert.ToDecimal(baseCovArr.Sum()/4); //divide by 4 to change from 15min array into hours
        }

        public decimal[] GetBaseCoverageByHour(Store store, DateTime date)
        {
            decimal[] baseCovArr15 = new decimal[96]; //time increment = 15 minutes
            decimal[] baseCovArrHr = new decimal[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }; //time increment = 24 hours
            string baseCovAttr = date.DayOfWeek.ToString() + "BaseCoverage";
            try
            {
                string baseCovStr = store.Attributes.Where(a => a.Name == baseCovAttr).FirstOrDefault().Value; //e.g. Name == SundayBaseCoverage
                baseCovArr15 = baseCovStr.Split(',').Select(decimal.Parse).ToArray();
                for(int i=0;i<96;i++)
                {
                    baseCovArrHr[i / 4] += baseCovArr15[i]/4;
                }
            }
            catch
            {
            }
            return baseCovArrHr; //returns a decimal array with 24 positions
        }
    }

    public interface IStoreAttributeService
    {
        decimal GetOpenHoursSum(Store store, DateTime date);
        decimal GetBaseCoverageSum(Store store, DateTime date);
        decimal[] GetBaseCoverageByHour(Store store, DateTime date);
    }
}