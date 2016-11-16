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
    public class HistoricDataService : IHistoricDataService
    {
        private DatabaseContext db;
        public HistoricDataService(DatabaseContext _db)
        {
            db = _db;
        }

        #region Constants
        string TRAFFIC_DRIVER_NAME = "Traffic";
        #endregion


        public decimal[] GetDriverVolumeBy15min(string driver, int storeNum, DateTime date)
        {
            var volumes = new decimal[96];
            var volumeData = db.HistoricData.Where(d => d.StoreNumber == storeNum && d.DriverName == driver && d.Date == date.Date);
            int minuteInc = 0, hourInc = 0;
            for (int i = 0; i < 96; i++) //loop through 15 minute increments.
            {
                minuteInc = (i % 4)*15;
                hourInc = i / 4;
                try
                {
                    volumes[i] = volumeData.Where(d => DbFunctions.CreateTime(d.Time.Value.Hour, d.Time.Value.Minute, d.Time.Value.Second) == DbFunctions.CreateTime(hourInc, minuteInc, 0)).First().Quantity; //get specific 15-minute increment
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    volumes[i] = 0; //if no data, set to 0
                }
            }
            return volumes;
        }

        public decimal GetDriverVolumeByDay(string driver, int storeNum, DateTime date)
        {
            decimal volumeTotal = 0.0M;
            var volumes = db.HistoricData.Where(d => d.StoreNumber == storeNum && d.DriverName == driver && DbFunctions.TruncateTime(d.Date) == date.Date);
            if (volumes != null)
            {
                foreach (var vol in volumes)
                {
                    volumeTotal += vol.Quantity;
                }
            }
            return volumeTotal;
        }

        public decimal GetDriverVolumeByWeek(string driver, int storeNum, DateTime date)
        {
            decimal volumeTotal = 0.0M;
            DateTime startWeekDate = date.StartOfWeek(DayOfWeek.Sunday);
            for (int i = 0; i < 7; i++)
            {
                var volumes = db.HistoricData.Where(d => d.StoreNumber == storeNum && d.DriverName == driver && DbFunctions.TruncateTime(d.Date) == DbFunctions.TruncateTime(startWeekDate.Date));
                if(volumes != null)
                {
                    foreach(var vol in volumes)
                    {
                        volumeTotal += vol.Quantity;
                    }
                }
                startWeekDate.AddDays(1);
            }
            return volumeTotal;
        }


    }

    public interface IHistoricDataService
    {
        decimal[] GetDriverVolumeBy15min(string driver, int storeNum, DateTime date);
        decimal GetDriverVolumeByDay(string driver, int storeNum, DateTime date);
        decimal GetDriverVolumeByWeek(string driver, int storeNum, DateTime date);
    }
}