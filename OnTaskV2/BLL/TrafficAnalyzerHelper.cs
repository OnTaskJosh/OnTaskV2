
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTaskV2.BLL
{
    public class TrafficAnalyzerHelper
    {


        public static decimal RecommendedHour(decimal traffic, decimal? star)
        {
            return (star != null && star > 0) ? (Convert.ToDecimal(traffic) / Convert.ToDecimal(star)) : 0.0M;
        }

    }
}