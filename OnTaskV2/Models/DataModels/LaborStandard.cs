using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnTaskV2.Models.DataModels
{
    public class LaborStandard
    {
        [Key]
        public int ID { get; set; } //PK
        public int TaskID { get; set; } //FK
        public string TaskName { get; set; }
        public int RoleID { get; set; } //FK
        public string RoleName { get; set; }
        public int DriverID { get; set; }//FK
        public string DriverName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss.fff}")]
        public DateTime? TimeStandard { get; set; }

        public bool IsActive { get; set; }
        public bool IsSelling { get; set; }

        public virtual ICollection<TaskElement> TaskElements { get; set; }
    }

    public class TaskElement
    {
        [Key]
        public int ID { get; set; } //PK
        [ForeignKey("LaborStandard")]
        public int LaborStandardID { get; set; } //FK
        public virtual LaborStandard LaborStandard { get; set; } //Navigation Property

        public string Name { get; set; }
        public int Order { get; set; } //1,2,3,etc
        public char SubOrder { get; set; } //a,b,c,etc //used for 1a,1b,1c,etc
        [DisplayFormat(DataFormatString = "{0:P2}")] //0.1234 formats as "12.34 %"
        public decimal PercentChance { get; set; }
        
        public decimal UnitOfMeasureToDriver { get; set; } //multiplier to driver
        public string UnitOfMeasure { get; set; }
        public string Driver { get; set; } //Need in both LaborStandard & Task Element??

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss.fff}")]
        public DateTime TimeStandard { get; set; }

        // public int StoreAttributeID { get; set; } 
        // public virtual StoreAttribute Trigger { get; set; }
    }
}