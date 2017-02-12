namespace Stilwill.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateOfService = c.DateTime(nullable: false),
                        OdometerMiles = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IntervalMiles = c.Int(nullable: false),
                        IntervalMonths = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Year = c.String(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceActivities", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.ServiceActivities", "ServiceId", "dbo.Services");
            DropIndex("dbo.ServiceActivities", new[] { "ServiceId" });
            DropIndex("dbo.ServiceActivities", new[] { "VehicleId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Services");
            DropTable("dbo.ServiceActivities");
        }
    }
}
