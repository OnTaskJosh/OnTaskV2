using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnTaskV2.Models.DataModels;

namespace OnTaskV2.DAL
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseAlways<DatabaseContext>
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
                new Store{ID = 1, Name = "NYC - Manhattan", Number = 100, DistrictID = 1 },
                new Store{ID = 2, Name = "FL - Orlando", Number = 101, DistrictID = 2 },
            };
            stores.ForEach(s => dbContext.Stores.Add(s));
            dbContext.SaveChanges();

            var storeAttributes = new List<StoreAttribute>
            {
                new StoreAttribute{ID = 1, StoreID = 1, Name = "SundayOpen", Value = "01/01/1900 00:00:00" },
                new StoreAttribute{ID = 1, StoreID = 1, Name = "SundayClose", Value = "01/02/1900 00:00:00" },
            };
            storeAttributes.ForEach(s => dbContext.StoreAttributes.Add(s));
            dbContext.SaveChanges();

            var historicData = new List<HistoricData>
            {

                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity = 2 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,15,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,30,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,45,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity = 4 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,15,0,0,DateTimeKind.Local), Quantity = 4 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,30,0,0,DateTimeKind.Local), Quantity = 4 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,45,0,0,DateTimeKind.Local), Quantity = 4 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 12 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,15,0,0,DateTimeKind.Local), Quantity = 12 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,30,0,0,DateTimeKind.Local), Quantity = 12 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,45,0,0,DateTimeKind.Local), Quantity = 12 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity = 9 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,15,0,0,DateTimeKind.Local), Quantity = 9 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,30,0,0,DateTimeKind.Local), Quantity = 9 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,45,0,0,DateTimeKind.Local), Quantity = 9 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 26 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,15,0,0,DateTimeKind.Local), Quantity = 26 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,30,0,0,DateTimeKind.Local), Quantity = 26 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,45,0,0,DateTimeKind.Local), Quantity = 26 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 18 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,15,0,0,DateTimeKind.Local), Quantity = 18 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,30,0,0,DateTimeKind.Local), Quantity = 18 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,45,0,0,DateTimeKind.Local), Quantity = 18 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 31 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,15,0,0,DateTimeKind.Local), Quantity = 31 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,30,0,0,DateTimeKind.Local), Quantity = 31 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,45,0,0,DateTimeKind.Local), Quantity = 31 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 29 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,15,0,0,DateTimeKind.Local), Quantity = 29 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,30,0,0,DateTimeKind.Local), Quantity = 29 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,45,0,0,DateTimeKind.Local), Quantity = 29 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 20 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,15,0,0,DateTimeKind.Local), Quantity = 20 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,30,0,0,DateTimeKind.Local), Quantity = 20 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,45,0,0,DateTimeKind.Local), Quantity = 20 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 20 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,15,0,0,DateTimeKind.Local), Quantity = 20 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,30,0,0,DateTimeKind.Local), Quantity = 20 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,45,0,0,DateTimeKind.Local), Quantity = 20 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 11 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,15,0,0,DateTimeKind.Local), Quantity = 11 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,30,0,0,DateTimeKind.Local), Quantity = 11 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,45,0,0,DateTimeKind.Local), Quantity = 11 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 3 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,15,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,30,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,45,0,0,DateTimeKind.Local), Quantity = 3 },

                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity = 2 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,15,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,30,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,45,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity = 4 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,15,0,0,DateTimeKind.Local), Quantity = 4 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,30,0,0,DateTimeKind.Local), Quantity = 4 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,45,0,0,DateTimeKind.Local), Quantity = 4 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 12 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,15,0,0,DateTimeKind.Local), Quantity = 12 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,30,0,0,DateTimeKind.Local), Quantity = 12 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,45,0,0,DateTimeKind.Local), Quantity = 12 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity = 8 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,15,0,0,DateTimeKind.Local), Quantity = 8 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,30,0,0,DateTimeKind.Local), Quantity = 8 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,45,0,0,DateTimeKind.Local), Quantity = 8 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 25 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,15,0,0,DateTimeKind.Local), Quantity = 25 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,30,0,0,DateTimeKind.Local), Quantity = 25 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,45,0,0,DateTimeKind.Local), Quantity = 25 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 17 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,15,0,0,DateTimeKind.Local), Quantity = 17 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,30,0,0,DateTimeKind.Local), Quantity = 17 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,45,0,0,DateTimeKind.Local), Quantity = 17 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 30 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,15,0,0,DateTimeKind.Local), Quantity = 30 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,30,0,0,DateTimeKind.Local), Quantity = 30 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,45,0,0,DateTimeKind.Local), Quantity = 30 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 28 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,15,0,0,DateTimeKind.Local), Quantity = 28 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,30,0,0,DateTimeKind.Local), Quantity = 28 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,45,0,0,DateTimeKind.Local), Quantity = 28 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 19 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,15,0,0,DateTimeKind.Local), Quantity = 19 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,30,0,0,DateTimeKind.Local), Quantity = 19 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,45,0,0,DateTimeKind.Local), Quantity = 19 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 19 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,15,0,0,DateTimeKind.Local), Quantity = 19 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,30,0,0,DateTimeKind.Local), Quantity = 19 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,45,0,0,DateTimeKind.Local), Quantity = 19 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 10 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,15,0,0,DateTimeKind.Local), Quantity = 10 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,30,0,0,DateTimeKind.Local), Quantity = 10 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,45,0,0,DateTimeKind.Local), Quantity = 10 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 3 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,15,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,30,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2015,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,45,0,0,DateTimeKind.Local), Quantity = 3 },

                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity = 1 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,15,0,0,DateTimeKind.Local), Quantity = 0 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,30,0,0,DateTimeKind.Local), Quantity = 0 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,45,0,0,DateTimeKind.Local), Quantity = 0 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 1 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,15,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,30,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,45,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity = 1 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,15,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,30,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,45,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 1 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,15,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,30,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,45,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 1 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,15,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,30,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,45,0,0,DateTimeKind.Local), Quantity = 0 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 2 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,15,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,30,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,45,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 4 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,15,0,0,DateTimeKind.Local), Quantity = 4 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,30,0,0,DateTimeKind.Local), Quantity = 4 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,45,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 4 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,15,0,0,DateTimeKind.Local), Quantity = 4 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,30,0,0,DateTimeKind.Local), Quantity = 4 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,45,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 3 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,15,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,30,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,45,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 1 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,15,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,30,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,45,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 1 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,15,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,30,0,0,DateTimeKind.Local), Quantity = 0 },
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,45,0,0,DateTimeKind.Local), Quantity = 0 },

                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity = 0.75M }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,15,0,0,DateTimeKind.Local), Quantity = 0.75M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,30,0,0,DateTimeKind.Local), Quantity = 0.75M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,45,0,0,DateTimeKind.Local), Quantity = 0.75M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity = 1.25M }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,15,0,0,DateTimeKind.Local), Quantity = 1.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,30,0,0,DateTimeKind.Local), Quantity = 1.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,45,0,0,DateTimeKind.Local), Quantity = 1.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 1.75M }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,15,0,0,DateTimeKind.Local), Quantity = 1.75M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,30,0,0,DateTimeKind.Local), Quantity = 1.75M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,45,0,0,DateTimeKind.Local), Quantity = 1.75M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity = 2.25M }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,15,0,0,DateTimeKind.Local), Quantity = 2.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,30,0,0,DateTimeKind.Local), Quantity = 2.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,45,0,0,DateTimeKind.Local), Quantity = 2.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 3 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,15,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,30,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,45,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 3 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,15,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,30,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,45,0,0,DateTimeKind.Local), Quantity = 3 },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 3.25M }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,15,0,0,DateTimeKind.Local), Quantity = 3.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,30,0,0,DateTimeKind.Local), Quantity = 3.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,45,0,0,DateTimeKind.Local), Quantity = 3.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 2.25M }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,15,0,0,DateTimeKind.Local), Quantity = 2.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,30,0,0,DateTimeKind.Local), Quantity = 2.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,45,0,0,DateTimeKind.Local), Quantity = 2.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 2.25M }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,15,0,0,DateTimeKind.Local), Quantity = 2.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,30,0,0,DateTimeKind.Local), Quantity = 2.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,45,0,0,DateTimeKind.Local), Quantity = 2.25M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 2 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,15,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,30,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,45,0,0,DateTimeKind.Local), Quantity = 2 },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 1.75M }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,15,0,0,DateTimeKind.Local), Quantity = 1.75M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,30,0,0,DateTimeKind.Local), Quantity = 1.75M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,45,0,0,DateTimeKind.Local), Quantity = 1.75M },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 1 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,15,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,30,0,0,DateTimeKind.Local), Quantity = 1 },
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,45,0,0,DateTimeKind.Local), Quantity = 1 },
            };
            historicData.ForEach(s => dbContext.HistoricData.Add(s));
            dbContext.SaveChanges();
        }
    }
}