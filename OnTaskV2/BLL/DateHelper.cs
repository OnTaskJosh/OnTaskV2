using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTaskV2.BLL
{
    public static class DateHelper
    {
        public static int AddDayOffsetToLY(DateTime date)
        {
            var addDays = 1;
            if(date > new DateTime(date.Year,2,29,0,0,0)) //after March 1, test current year
            {
                if(DateTime.IsLeapYear(date.Year))
                {
                    addDays = 2;
                }
            }
            else //beforeMarch 1, check previous year
            {
                if (DateTime.IsLeapYear(date.Year - 1))
                {
                    addDays = 2;
                }
            }
            return addDays;
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }
        
    }
}