namespace OnTaskV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrgHierarchy",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Client", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrgHierarchyID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrgHierarchy", t => t.OrgHierarchyID)
                .Index(t => t.OrgHierarchyID);
            
            CreateTable(
                "dbo.Division",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Country", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DivisionID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Division", t => t.DivisionID)
                .Index(t => t.DivisionID);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegionID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Region", t => t.RegionID)
                .Index(t => t.RegionID);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DistrictID = c.Int(nullable: false),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.District", t => t.DistrictID)
                .Index(t => t.DistrictID);
            
            CreateTable(
                "dbo.StoreAttribute",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        Name = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Store", t => t.StoreID)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Store", t => t.StoreID)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.HistoricData",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DriverName = c.String(),
                        StoreNumber = c.Int(nullable: false),
                        Date = c.DateTime(),
                        Time = c.DateTime(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LaborStandard",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TaskID = c.Int(nullable: false),
                        TaskName = c.String(),
                        RoleID = c.Int(nullable: false),
                        RoleName = c.String(),
                        DriverID = c.Int(nullable: false),
                        DriverName = c.String(),
                        TimeStandard = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsSelling = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TaskElement",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LaborStandardID = c.Int(nullable: false),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        PercentChance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureToDriver = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasure = c.String(),
                        Driver = c.String(),
                        TimeStandard = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LaborStandard", t => t.LaborStandardID)
                .Index(t => t.LaborStandardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskElement", "LaborStandardID", "dbo.LaborStandard");
            DropForeignKey("dbo.Department", "StoreID", "dbo.Store");
            DropForeignKey("dbo.Country", "OrgHierarchyID", "dbo.OrgHierarchy");
            DropForeignKey("dbo.Region", "DivisionID", "dbo.Division");
            DropForeignKey("dbo.Store", "DistrictID", "dbo.District");
            DropForeignKey("dbo.StoreAttribute", "StoreID", "dbo.Store");
            DropForeignKey("dbo.District", "RegionID", "dbo.Region");
            DropForeignKey("dbo.Division", "CountryID", "dbo.Country");
            DropForeignKey("dbo.OrgHierarchy", "ID", "dbo.Client");
            DropIndex("dbo.TaskElement", new[] { "LaborStandardID" });
            DropIndex("dbo.Department", new[] { "StoreID" });
            DropIndex("dbo.StoreAttribute", new[] { "StoreID" });
            DropIndex("dbo.Store", new[] { "DistrictID" });
            DropIndex("dbo.District", new[] { "RegionID" });
            DropIndex("dbo.Region", new[] { "DivisionID" });
            DropIndex("dbo.Division", new[] { "CountryID" });
            DropIndex("dbo.Country", new[] { "OrgHierarchyID" });
            DropIndex("dbo.OrgHierarchy", new[] { "ID" });
            DropTable("dbo.TaskElement");
            DropTable("dbo.LaborStandard");
            DropTable("dbo.HistoricData");
            DropTable("dbo.Department");
            DropTable("dbo.StoreAttribute");
            DropTable("dbo.Store");
            DropTable("dbo.District");
            DropTable("dbo.Region");
            DropTable("dbo.Division");
            DropTable("dbo.Country");
            DropTable("dbo.OrgHierarchy");
            DropTable("dbo.Client");
        }
    }
}
