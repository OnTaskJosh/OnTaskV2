using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnTaskV2.Models.ViewModels
{
    public class TrafficAnalyzer
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? SelectedDate { get; set; }
        public string SelectedStore { get; set; }
        public Decimal TargetSTAR { get; set; }
    }

    public class TA_Table
    {
        public Decimal BudgetHours { get; set; }
        public Decimal BaseHours { get; set; }
        public Decimal NonSellHours { get; set; }
        public Decimal SellingHours { get; set; }

        public Decimal[] TrafficLY { get; set; } //0-95 //96 total increments in the array. 15-min increments for one full day
        public Decimal[] TrafficTY { get; set; }
        public Decimal[] TrafficPercent { get; set; } //percent of time period to total traffic for the day
        public Decimal[] Transactions { get; set; }
        public Decimal[] ConversionPercent { get; set; }
        public Decimal[] ActualHours { get; set; }
        public Decimal[] RecommendHours { get; set; }
        public Decimal[] AdjustHours { get; set; }
        public Decimal[] PlusMinusHours { get; set; }
        public Decimal[] TPLH { get; set; }
    }
}