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
        public decimal TargetSTAR { get; set; }
    }

    public class TA_Table
    {
        public decimal BudgetHours { get; set; }
        public decimal BaseHours { get; set; }
        public decimal NonSellHours { get; set; }
        public decimal SellingHours { get; set; }

        public decimal[] TrafficLY { get; set; } //0-95 //96 total increments in the array. 15-min increments for one full day
        public decimal[] TrafficTY { get; set; }
        public decimal[] TrafficPercent { get; set; } //percent of time period to total traffic for the day
        public decimal[] Transactions { get; set; }
        public decimal[] ConversionPercent { get; set; }
        public decimal[] ActualHours { get; set; }
        public decimal[] RecommendHours { get; set; }
        public decimal[] AdjustHours { get; set; }
        public decimal[] PlusMinusHours { get; set; }
        public decimal[] TPLH { get; set; }
    }
}