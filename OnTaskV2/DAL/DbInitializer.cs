using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnTaskV2.Models.DataModels;
using System.Data.Entity.Migrations;



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
            clients.ForEach(s => dbContext.Clients.AddOrUpdate(s));
            dbContext.SaveChanges();

            var countries = new List<Country>
            {
                new Country{ ID = 1, Name = "United States", OrgHierarchyID = 1},
            };
            countries.ForEach(s => dbContext.Countries.AddOrUpdate(s));
            dbContext.SaveChanges();

            var divisions = new List<Division>
            {
                new Division{ID = 1, Name = "Premium Stores", CountryID = 1 },
                new Division{ID = 2, Name = "Outlet Stores", CountryID = 1 },
            };
            divisions.ForEach(s => dbContext.Divisions.AddOrUpdate(s));
            dbContext.SaveChanges();

            var regions = new List<Region>
            {
                new Region{ID = 1, Name = "Premium East", DivisionID = 1 },
                new Region{ID = 2, Name = "Premium West", DivisionID = 1 },
                new Region{ID = 3, Name = "Outlet East", DivisionID = 2 },
                new Region{ID = 4, Name = "Outlet West", DivisionID = 2 },
            };
            regions.ForEach(s => dbContext.Regions.AddOrUpdate(s));
            dbContext.SaveChanges();

            var districts = new List<District>
            {
                new District{ID = 1, Name = "New England", RegionID = 1 },
                new District{ID = 2, Name = "South East", RegionID = 1 },
            };
            districts.ForEach(s => dbContext.Districts.AddOrUpdate(s));
            dbContext.SaveChanges();

            var stores = new List<Store>
            {
                new Store{ID = 1, Name = "NYC - Manhattan", Number = 100, DistrictID = 1 },
                new Store{ID = 2, Name = "FL - Orlando", Number = 101, DistrictID = 2 },
            };
            stores.ForEach(s => dbContext.Stores.AddOrUpdate(s));
            dbContext.SaveChanges();

            var storeAttributes = new List<StoreAttribute>
            {
                new StoreAttribute{ID = 1, StoreID = 1, Name = "SundayOpen", Value = "01/01/1900 10:00:00" },
                new StoreAttribute{ID = 2, StoreID = 1, Name = "SundayClose", Value = "01/02/1900 20:00:00" },
                new StoreAttribute{ID = 3, StoreID = 1, Name = "MondayOpen", Value = "01/01/1900 09:00:00" },
                new StoreAttribute{ID = 4, StoreID = 1, Name = "MondayClose", Value = "01/02/1900 21:00:00" },
                new StoreAttribute{ID = 5, StoreID = 1, Name = "TuesdayOpen", Value = "01/01/1900 09:00:00" },
                new StoreAttribute{ID = 6, StoreID = 1, Name = "TuesdayClose", Value = "01/02/1900 21:00:00" },
                new StoreAttribute{ID = 7, StoreID = 1, Name = "WednesdayOpen", Value = "01/01/1900 09:00:00" },
                new StoreAttribute{ID = 8, StoreID = 1, Name = "WednesdayClose", Value = "01/02/1900 21:00:00" },
                new StoreAttribute{ID = 9, StoreID = 1, Name = "ThursdayOpen", Value = "01/01/1900 09:00:00" },
                new StoreAttribute{ID = 10, StoreID = 1, Name = "ThursdayClose", Value = "01/02/1900 21:00:00" },
                new StoreAttribute{ID = 11, StoreID = 1, Name = "FridayOpen", Value = "01/01/1900 09:00:00" },
                new StoreAttribute{ID = 12, StoreID = 1, Name = "FridayClose", Value = "01/02/1900 21:00:00" },
                new StoreAttribute{ID = 13, StoreID = 1, Name = "SaturdayOpen", Value = "01/01/1900 09:00:00" },
                new StoreAttribute{ID = 14, StoreID = 1, Name = "SaturdayClose", Value = "01/02/1900 21:00:00" },
                new StoreAttribute{ID = 15, StoreID = 1, Name = "SundayBaseCoverage", Value = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0" }, //open 10am-8pm
                new StoreAttribute{ID = 16, StoreID = 1, Name = "MondayBaseCoverage", Value = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0" }, //open 9am-9pm
                new StoreAttribute{ID = 17, StoreID = 1, Name = "TuesdayBaseCoverage", Value = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0" }, //open 9am-9pm
                new StoreAttribute{ID = 18, StoreID = 1, Name = "WednesdayBaseCoverage", Value = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0" }, //open 9am-9pm
                new StoreAttribute{ID = 19, StoreID = 1, Name = "ThursdayBaseCoverage", Value = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0" }, //open 9am-9pm
                new StoreAttribute{ID = 20, StoreID = 1, Name = "FridayBaseCoverage", Value = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0" }, //open 9am-9pm
                new StoreAttribute{ID = 21, StoreID = 1, Name = "SaturdayBaseCoverage", Value = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0" }, //open 9am-9pm
            };
            storeAttributes.ForEach(s => dbContext.StoreAttributes.AddOrUpdate(s));
            dbContext.SaveChanges();

            var nonSellWeekHours = new List<NonSellWeekHour>
            {
                new NonSellWeekHour{
                    StoreID = 1,
                    StartOfWeekDate = new DateTime(2016,11,06,0,0,0,0,DateTimeKind.Local),
                    SundayNonSellHours = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0", //9am-10am open, 9pm-10pm close
                    MondayNonSellHours = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0", //8am-9am open, 10pm-11pm close
                    TuesdayNonSellHours = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0" , //8am-9am open, 10pm-11pm close
                    WednesdayNonSellHours = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0", //8am-9am open, 10pm-11pm close
                    ThursdayNonSellHours = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0", //8am-9am open, 10pm-11pm close
                    FridayNonSellHours = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0", //8am-9am open, 10pm-11pm close
                    SaturdayNonSellHours = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0", //8am-9am open, 10pm-11pm close
                },
            };
            nonSellWeekHours.ForEach(s => dbContext.NonSellWeekHours.AddOrUpdate(s));
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

                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity = 3 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity = 11 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity = 17 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 23 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity =52 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 44 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 67 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 49 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 47 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 38 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 34 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 34 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 38 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity = 4 }, //DateTime Kind (2) = Local

                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity = 0 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity = 0 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity = 0 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 10 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity = 6 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 10 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 3 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 6 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 5 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 4 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 6 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 5 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 0 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity = 0 }, //DateTime Kind (2) = Local

                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity = 2 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity = 3 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity = 4 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 5 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity = 7 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 7 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 8 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 8 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 5 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 4 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 5 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 5 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 5 }, //DateTime Kind (2) = Local
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,07,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity = 0 }, //DateTime Kind (2) = Local

                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =   2},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =   8},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity =   22},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity =  35},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity =   52},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity =   41},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity =   55},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity =   41},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity =   30},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity =   37},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity =   29},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity =  20},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =   7},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =   3},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =   0},

                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity =  3},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity =  6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity =  5},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 4},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =  0},

                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity = 0},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =  2},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =  5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity =  6},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity =  8},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 8},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 9},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 8},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 6},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 6},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 6},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =  3},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,08,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =  0},

                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity =   2},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =   11},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =   15},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity =   21},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity =  50},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity =   41},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity =   65},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity =   48},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity =   48},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity =   37},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity =   35},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity =   33},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity =  37},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =   4},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =   0},

                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity =  3},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity =  6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity =  5},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 4},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =  0},

                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity = 2},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =  3},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =  4},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity =  7},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity =  7},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 8},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 8},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 4},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,09,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =  0},

                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity =   2},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =   11},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =   15},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity =   21},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity =  50},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity =   41},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity =   65},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity =   48},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity =   48},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity =   37},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity =   35},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity =   33},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity =  37},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =   4},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =   0},

                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity =  3},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity =  6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity =  5},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 4},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =  0},

                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity = 2},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =  3},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =  4},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity =  7},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity =  7},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 8},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 8},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 4},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,10,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =  0},

                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity =   2},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =   11},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =   15},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity =   21},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity =  50},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity =   41},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity =   65},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity =   48},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity =   48},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity =   37},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity =   35},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity =   33},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity =  37},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =   4},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =   0},

                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity =  3},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity =  6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity =  5},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 4},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =  0},

                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity = 2},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =  3},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =  4},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity =  7},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity =  7},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 8},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 8},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 4},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 5},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,11,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =  0},

                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity =   4},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =   13},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =   21},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity =   42},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity =  68},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity =   81},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity =   118},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity =   136},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity =   21},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity =   6},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity =   4},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity =   1},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity =  7},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =   6},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Traffic", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =   0},

                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =   0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =  6},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 7},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity = 8},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity = 9},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 7},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity =  16},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity =  1},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "Transactions", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =  0},

                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,8,0,0,0,DateTimeKind.Local), Quantity = 0},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,9,0,0,0,DateTimeKind.Local), Quantity =  7},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,10,0,0,0,DateTimeKind.Local), Quantity =  10},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,11,0,0,0,DateTimeKind.Local), Quantity = 11},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,12,0,0,0,DateTimeKind.Local), Quantity =  11},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,13,0,0,0,DateTimeKind.Local), Quantity =  10},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,14,0,0,0,DateTimeKind.Local), Quantity = 11},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,15,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,16,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,17,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,18,0,0,0,DateTimeKind.Local), Quantity = 10},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,19,0,0,0,DateTimeKind.Local), Quantity = 9},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,20,0,0,0,DateTimeKind.Local), Quantity = 9},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,21,0,0,0,DateTimeKind.Local), Quantity =  8},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,22,0,0,0,DateTimeKind.Local), Quantity =  0},
                new HistoricData {StoreNumber = 100, DriverName = "LaborHours", Date = new DateTime(2016,11,12,0,0,0,0,DateTimeKind.Local), Time = new DateTime(1900,1,1,23,0,0,0,DateTimeKind.Local), Quantity =  0},

            };
            historicData.ForEach(s => dbContext.HistoricData.AddOrUpdate(s));
            dbContext.SaveChanges();
        }
    }
}