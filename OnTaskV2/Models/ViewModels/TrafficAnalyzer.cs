using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnTaskV2.Models.DataModels;

namespace OnTaskV2.Models.ViewModels
{
    public class TAIndex
    {
        public OrgHierarchy OrgHierarchy { get; set; }
    }

    public class TrafficAnalyzer
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? SelectedDate { get; set; }
        public string SelectedStore { get; set; }
        public decimal TargetSTAR { get; set; }
    }

    public class TA_Table
    {
        public int InputStoreId { get; set; }
        public DateTime InputDate { get; set; }
        public Decimal? InputSTAR { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal BudgetHours { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal BaseHours { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal NonSellHours { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal SellingHours { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal TargetSTAR { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal[] TrafficLY { get; set; } //0-95 //96 total increments in the array. 15-min increments for one full day
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal[] TrafficTY { get; set; }
        [DisplayFormat(DataFormatString = "{0:##.##%}", ApplyFormatInEditMode = true)]
        public decimal[] TrafficPercent { get; set; } //percent of time period to total traffic for the day
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal[] Transactions { get; set; }
        [DisplayFormat(DataFormatString = "{0:##.##%}", ApplyFormatInEditMode = true)]
        public decimal[] ConversionPercent { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal[] ActualHours { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal[] RecommendHours { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal[] AdjustHours { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal[] PlusMinusHours { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal[] TPLH { get; set; }
        [DisplayFormat(DataFormatString = "{0:$0.00}", ApplyFormatInEditMode = true)]
        public decimal[] Sales { get; set; }
        [DisplayFormat(DataFormatString = "{0:$0.00}", ApplyFormatInEditMode = true)]
        public decimal[] AvgTransactions { get; set; }

        [DisplayFormat(DataFormatString = "{0:h:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:h:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:h:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan TimeIncrement { get; set; }
        public string[] TimePeriod { get; set; }
        public bool[] IsPeakPeriod { get; set; }
    }
}