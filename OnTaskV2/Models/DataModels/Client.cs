using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnTaskV2.Models.DataModels
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        
        public virtual OrgHierarchy OrgHierarchy { get; set; } //Navigation Property
        //public virtual ICollection<Users> Users { get; set; } //Navigation Property //TODO

        public string Name { get; set; }
        
    }
}