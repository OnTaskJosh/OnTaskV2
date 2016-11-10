using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnTaskV2.Models.DataModels;

namespace OnTaskV2.DAL
{
    public class DbInitiliazer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext dbContext)
        {
            var clients = new List<Client>
            {
                new Client{ID = 1, Name = "NRF Demo", OrgHierarchy = new OrgHierarchy{ID = 1} },
            };
            clients.ForEach(s => dbContext.Clients.Add(s));
            dbContext.SaveChanges();

            var countries = new List<Country>
            {
                new Country{ ID = 1, Name = "United States", OrgHierarchyID = 1},
            };
            countries.ForEach(s => dbContext.Countries.Add(s));
            dbContext.SaveChanges();

            var divisions = new List<Division>
            {
                new Division{ID = 1, Name = "Premium Stores", CountryID = 1 },
                new Division{ID = 2, Name = "Outlet Stores", CountryID = 1 },
            };
            divisions.ForEach(s => dbContext.Divisions.Add(s));
            dbContext.SaveChanges();

            var regions = new List<Region>
            {
                new Region{ID = 1, Name = "Premium East", DivisionID = 1 },
                new Region{ID = 2, Name = "Premium West", DivisionID = 1 },
                new Region{ID = 3, Name = "Outlet East", DivisionID = 2 },
                new Region{ID = 4, Name = "Outlet West", DivisionID = 2 },
            };
            regions.ForEach(s => dbContext.Regions.Add(s));
            dbContext.SaveChanges();

            var districts = new List<District>
            {
                new District{ID = 1, Name = "New England", RegionID = 1 },
                new District{ID = 2, Name = "South East", RegionID = 1 },
            };
            districts.ForEach(s => dbContext.Districts.Add(s));
            dbContext.SaveChanges();

            var stores = new List<Store>
            {
                new Store{ID = 1, Name = "NYC - Manhattan", DistrictID = 1 },
                new Store{ID = 2, Name = "FL - Orlando", DistrictID = 2 },
            };
            stores.ForEach(s => dbContext.Stores.Add(s));
            dbContext.SaveChanges();

        }
    }
}