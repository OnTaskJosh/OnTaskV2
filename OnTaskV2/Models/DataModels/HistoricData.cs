using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTaskV2.Models.DataModels
{
    public class HistoricData
    {
        public string DriverName { get; set; }
        public string StoreNumber { get; set; } //FK to store
        public DateTime Date { get; set; }
        public DateTime Time { get; set; } //15 min increment
        public int Quantity { get; set; } // This is an eric comment. Completely irrelevant. 
        //public string JoshEdit { get; set; }
        public int Fake { get; set; }
    }

}