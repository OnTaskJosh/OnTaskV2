using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnTaskV2.Models.DataModels
{
    public class OrgHierarchy
    {
        [Key, ForeignKey("Client")]
        public int ID { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Country> Countries { get; set; } //Navigation Property

    }

    public class Store
    {
        [Key]
        public int ID { get; set; }
        
        [ForeignKey("District")]
        public int DistrictID { get; set; }
        public virtual District District { get; set; } //Navigation Property

        public string Name { get; set; }
        public string Number { get; set; }

        //public virtual ICollection<StoreAttribute> Attributes { get; set; } //TODO
    }

    public class Department
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Store")]
        public int StoreID { get; set; }
        public virtual Store Store { get; set; } //Navigation Property

        public string Name { get; set; }
    }

    public class District
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Region")]
        public int RegionID { get; set; }
        public virtual Region Region { get; set; } //Navigation Property
        public virtual ICollection<Store> Stores { get; set; } //Navigation Property

        public string Name { get; set; }
    }

    public class Region
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Division")]
        public int DivisionID { get; set; }
        public virtual Division Division { get; set; } //Navigation Property
        public virtual ICollection<District> Districts { get; set; } //Navigation Property

        public string Name { get; set; }
    }

    public class Division
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; } //Navigation Property
        public virtual ICollection<Region> Regions { get; set; } //Navigation Property

        public string Name { get; set; }
    }

    public class Country
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("OrgHierarchy")]
        public int OrgHierarchyID { get; set; }
        public virtual OrgHierarchy OrgHierarchy { get; set; } //Navigation Property
        public virtual ICollection<Division> Divisions { get; set; } //Navigation Property

        public string Name { get; set; }
    }
}