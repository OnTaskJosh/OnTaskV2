using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnTaskV2.Models.DataModels
{
    public class HistoricData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string DriverName { get; set; }
        public int StoreNumber { get; set; } //FK to store
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; } //15 min increment
        public decimal Quantity { get; set; } 
    }

}