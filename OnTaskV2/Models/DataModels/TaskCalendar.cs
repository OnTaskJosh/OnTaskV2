using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnTaskV2.Models.DataModels
{
    public class TaskCalendar
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Store")]
        public int StoreID { get; set; }
        public virtual Store Store { get; set; } //Navigation Property

        //public string Name { get; set; }
        //public string Value { get; set; }
    }

    //gets updated with each Task to keep track of total hours
    public class NonSellWeekHour
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Store")]
        public int StoreID { get; set; }
        public virtual Store Store { get; set; } //Navigation Property

        public DateTime? StartOfWeekDate { get; set; }

        //Hours with a specific set time
        public string MondayNonSellHours { get; set; } //decimal array of size[96] stored as a string. //use array size [96] for 15min increments over 24 hrs
        public string TuesdayNonSellHours { get; set; }
        public string WednesdayNonSellHours { get; set; }
        public string ThursdayNonSellHours { get; set; }
        public string FridayNonSellHours { get; set; }
        public string SaturdayNonSellHours { get; set; }
        public string SundayNonSellHours { get; set; }

        //Hours with a specific day but no set time //Can be adjusted
        public decimal? FloatMondayNonSellHours { get; set; } 
        public decimal? FloatTuesdayNonSellHours { get; set; }
        public decimal? FloatWednesdayNonSellHours { get; set; }
        public decimal? FloatThursdayNonSellHours { get; set; }
        public decimal? FloatFridayNonSellHours { get; set; }
        public decimal? FloatSaturdayNonSellHours { get; set; }
        public decimal? FloatSundayNonSellHours { get; set; }

        //Hours set for the week but no specific day or time
        public decimal? FloatWeekNonSellHours { get; set; }
    }

    public class NonSellTask
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Store")]
        public int StoreID { get; set; }
        public virtual Store Store { get; set; } //Navigation Property

        /* //Not Set Up Yet
        [ForeignKey("Task")]
        public int TaskID { get; set; }
        public virtual Task Task { get; set; } //Navigation Property
        */

        //Date Range for completion window
        public DateTime? StartWindow { get; set; }
        public DateTime? FinishWindow { get; set; }

        //Date Range for Set Task Time
        public DateTime? SetStart { get; set; }
        public DateTime? SetFinish { get; set; }

        public Decimal AverageVolume { get; set; }
        public Decimal Index { get; set; }
        public int TeamSize { get; set; }
        public string Instructions { get; set; }
        public string Attachments { get; set; } //change to FileAttachment
        public bool IsSent { get; set; } //sent to stores?
        public Decimal ExpectedHours { get; set; } //expected time to complete from labor standard * volume
        public bool IsComplete { get; set; }
        //Date Range for actual time
        public DateTime? ActualStart { get; set; }
        public DateTime? ActualFinish { get; set; }
        public bool IsOnTime { get; set; } //Is ActualFinish <= set Finish Time
        public Decimal ActualHours { get; set; }
        public Decimal PercentToStandard { get; set; } //ExpectedHours / ActualHours * 100
        public string StoreFeedback { get; set; }

    }

    
}