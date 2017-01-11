using OnTaskV2.DAL;
using OnTaskV2.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnTaskV2.BLL
{
    public class TaskCalendarService : ITaskCalendarService
    {
        private DatabaseContext db;
        public TaskCalendarService(DatabaseContext _db)
        {
            db = _db;
        }

        public decimal GetNonSellHoursSum(Store store, DateTime date)
        {
            string nonSellHourStr;
            decimal[] nonSellHourArr = new decimal[96]; //time increment = 15 minutes
            DateTime startWeekDate = date.StartOfWeek(DayOfWeek.Sunday);
            decimal floatingHoursSum = 0.0M;
            
            var nonSellWeekHours = db.NonSellWeekHours.Where(n => n.StoreID == store.ID && DbFunctions.TruncateTime(n.StartOfWeekDate) == DbFunctions.TruncateTime(startWeekDate.Date)).FirstOrDefault();

            try
            {
                
                switch (date.DayOfWeek.ToString())
                {
                    case "Sunday":
                        nonSellHourStr = nonSellWeekHours.SundayNonSellHours;
                        nonSellHourArr = nonSellHourStr.Split(',').Select(decimal.Parse).ToArray();
                        floatingHoursSum = Convert.ToDecimal(nonSellWeekHours.FloatSundayNonSellHours);
                        break;
                    case "Monday":
                        nonSellHourStr = nonSellWeekHours.MondayNonSellHours;
                        nonSellHourArr = nonSellHourStr.Split(',').Select(decimal.Parse).ToArray();
                        floatingHoursSum = Convert.ToDecimal(nonSellWeekHours.FloatMondayNonSellHours);
                        break;
                    case "Tuesday":
                        nonSellHourStr = nonSellWeekHours.TuesdayNonSellHours;
                        nonSellHourArr = nonSellHourStr.Split(',').Select(decimal.Parse).ToArray();
                        floatingHoursSum = Convert.ToDecimal(nonSellWeekHours.FloatTuesdayNonSellHours);
                        break;
                    case "Wednesday":
                        nonSellHourStr = nonSellWeekHours.WednesdayNonSellHours;
                        nonSellHourArr = nonSellHourStr.Split(',').Select(decimal.Parse).ToArray();
                        floatingHoursSum = Convert.ToDecimal(nonSellWeekHours.FloatWednesdayNonSellHours);
                        break;
                    case "Thursday":
                        nonSellHourStr = nonSellWeekHours.ThursdayNonSellHours;
                        nonSellHourArr = nonSellHourStr.Split(',').Select(decimal.Parse).ToArray();
                        floatingHoursSum = Convert.ToDecimal(nonSellWeekHours.FloatThursdayNonSellHours);
                        break;
                    case "Friday":
                        nonSellHourStr = nonSellWeekHours.FridayNonSellHours;
                        nonSellHourArr = nonSellHourStr.Split(',').Select(decimal.Parse).ToArray();
                        floatingHoursSum = Convert.ToDecimal(nonSellWeekHours.FloatFridayNonSellHours);
                        break;
                    case "Saturday":
                        nonSellHourStr = nonSellWeekHours.SaturdayNonSellHours;
                        nonSellHourArr = nonSellHourStr.Split(',').Select(decimal.Parse).ToArray();
                        floatingHoursSum = Convert.ToDecimal(nonSellWeekHours.FloatSaturdayNonSellHours);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                //if no data, set to 0
            }
            return Convert.ToDecimal((nonSellHourArr.Sum() + floatingHoursSum) / 4 ); //divide by 4 to change from 15min array into hours
        }
    }

    public interface ITaskCalendarService
    {
        decimal GetNonSellHoursSum(Store store, DateTime date);
    }
}