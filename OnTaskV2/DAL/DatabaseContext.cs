using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnTaskV2.Models.DataModels;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OnTaskV2.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<HistoricData> HistoricData { get; set; }
        public DbSet<OrgHierarchy> OrgHierarchy { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreAttribute> StoreAttributes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LaborStandard> LaborStandards { get; set; }
        public DbSet<TaskElement> TaskElements { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}