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


        public decimal[] GetDriverVolumeForDayBy15min(string driver, int storeNum, DateTime date)
        {
            var volumes = new decimal[96];
            var volumeData = db.HistoricData.Where(d => d.StoreNumber == storeNum && d.DriverName == driver && DbFunctions.TruncateTime(d.Date) == DbFunctions.TruncateTime(date.Date));
            int minuteInc = 0, hourInc = 0;
            List<HistoricData> incVolData = new List<HistoricData>();
            for (int i = 0; i < 96; i++) //loop through 15 minute increments.
            {
                minuteInc = (i % 4)*15;
                hourInc = i / 4;
                try
                {
                    volumes[i] = 0;
                    incVolData = volumeData.Where(d => DbFunctions.CreateTime(d.Time.Value.Hour, d.Time.Value.Minute, 0) == DbFunctions.CreateTime(hourInc, minuteInc, 0)).ToList(); //get specific 15-minute increment
                    foreach(var dataItem in incVolData)
                    {
                        volumes[i] += dataItem.Quantity;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                     //if no data, set to 0
                }
            }
            return volumes;
        }

        public decimal[] GetDriverVolumeForDayByHour(string driver, int storeNum, DateTime date)
        {
            var volumes = new decimal[24];
            var volumeData = db.HistoricData.Where(d => d.StoreNumber == storeNum && d.DriverName == driver && DbFunctions.TruncateTime(d.Date) == DbFunctions.TruncateTime(date.Date));
            int hourInc = 0;
            List<HistoricData> hourVolData = new List<HistoricData>();
            for (int i = 0; i < 24; i++) //loop through hour increments.
            {
                hourInc = i;
                try
                {
                    volumes[i] = 0;
                    hourVolData = volumeData.Where(d => DbFunctions.CreateTime(d.Time.Value.Hour, 0, 0) == DbFunctions.CreateTime(hourInc, 0, 0)).ToList(); //get all hour increment
                    foreach(var dataItem in hourVolData)
                    {
                        volumes[i] += dataItem.Quantity;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    volumes[i] = 0; //if no data, set to 0
                }
            }
            return volumes;
        }

        public decimal[] GetDriverVolumeForWeekByDay(string driver, int storeNum, DateTime startOfWeekDate)
        {
            var volumes = new decimal[7];
            DateTime endOfWeekDate = startOfWeekDate.AddDays(7);
            var volumeData = db.HistoricData.Where(d => d.StoreNumber == storeNum && d.DriverName == driver && DbFunctions.TruncateTime(d.Date) >= DbFunctions.TruncateTime(startOfWeekDate.Date) && DbFunctions.TruncateTime(d.Date) <= DbFunctions.TruncateTime(endOfWeekDate.Date));
            DateTime dayInc = new DateTime();
            List<HistoricData> dayVolData = new List<HistoricData>();
            for (int i = 0; i < 7; i++) //loop through day increments.
            {
                dayInc = startOfWeekDate.AddDays(i);
                try
                {
                    volumes[i] = 0;
                    dayVolData = volumeData.Where(d => DbFunctions.TruncateTime(d.Date) == DbFunctions.TruncateTime(dayInc)).ToList(); //get all volumes for the day
                    foreach (var dataItem in dayVolData)
                    {
                        volumes[i] += dataItem.Quantity;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    volumes[i] = 0; //if no data, set to 0
                }
            }
            return volumes;
        }

        public decimal[] GetDriverVolumeForWeekByHour(string driver, int storeNum, DateTime startOfWeekDate)
        {
            var volumes = new decimal[24*7];
            DateTime endOfWeekDate = startOfWeekDate.AddDays(7);
            var volumeData = db.HistoricData.Where(d => d.StoreNumber == storeNum && d.DriverName == driver && DbFunctions.TruncateTime(d.Date) >= DbFunctions.TruncateTime(startOfWeekDate.Date) && DbFunctions.TruncateTime(d.Date) <= DbFunctions.TruncateTime(endOfWeekDate.Date));
            DateTime dayInc = new DateTime();
            int hourInc = 0;
            List<HistoricData> incVolData = new List<HistoricData>();
            for (int i = 0; i < 7; i++) //loop through day increments.
            {
                dayInc = startOfWeekDate.AddDays(i);
                for (int j = 0; j < 24; j++) //loop through 15 minute increments.
                {
                    hourInc = j;
                    try
                    {
                        volumes[(i*j)] = 0;
                        incVolData = volumeData.Where(d => DbFunctions.CreateTime(d.Time.Value.Hour, 0, 0) == DbFunctions.CreateTime(hourInc, 0, 0) && DbFunctions.TruncateTime(d.Date) == DbFunctions.TruncateTime(dayInc)).ToList(); //get specific 15-minute increment
                        foreach (var dataItem in incVolData)
                        {
                            volumes[(i*j)] += dataItem.Quantity;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} Exception caught.", e);
                        volumes[(i*j)] = 0; //if no data, set to 0
                    }
                }
            }
            return volumes;
        }

        public decimal GetDriverVolumeSumByDay(string driver, int storeNum, DateTime date)
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

        public decimal GetDriverVolumeSumByWeek(string driver, int storeNum, DateTime date)
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
        decimal[] GetDriverVolumeForDayBy15min(string driver, int storeNum, DateTime date);
        decimal[] GetDriverVolumeForDayByHour(string driver, int storeNum, DateTime date);
        decimal[] GetDriverVolumeForWeekByDay(string driver, int storeNum, DateTime date);
        decimal[] GetDriverVolumeForWeekByHour(string driver, int storeNum, DateTime date);
        decimal GetDriverVolumeSumByDay(string driver, int storeNum, DateTime date);
        decimal GetDriverVolumeSumByWeek(string driver, int storeNum, DateTime date);
    }
}