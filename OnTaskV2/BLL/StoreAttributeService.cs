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

    }

    public interface IStoreAttributeService
    {
        decimal GetOpenHoursSum(Store store, DateTime date);
    }
}