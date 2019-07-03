namespace FarmTradeFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarketEntry1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.FinalProducts", newName: "FinalProduct");
            RenameTable(name: "dbo.Locations", newName: "Location");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.Qualities", newName: "Quality");
            RenameTable(name: "dbo.Storages", newName: "Storage");
            RenameTable(name: "dbo.UserAccounts", newName: "UserAccount");
            CreateTable(
                "dbo.EntryType",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MarketEntry",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntryQuantity = c.Double(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        EntryPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryDate = c.DateTime(nullable: false),
                        DeliveryLocationID = c.Int(nullable: false),
                        EntryTypeId = c.Byte(nullable: false),
                        UserAccountID = c.Int(nullable: false),
                        FinalProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Location", t => t.DeliveryLocationID, cascadeDelete: true)
                .ForeignKey("dbo.EntryType", t => t.EntryTypeId, cascadeDelete: true)
                .ForeignKey("dbo.FinalProduct", t => t.FinalProductID)
                .ForeignKey("dbo.UserAccount", t => t.UserAccountID, cascadeDelete: true)
                .Index(t => t.DeliveryLocationID)
                .Index(t => t.EntryTypeId)
                .Index(t => t.UserAccountID)
                .Index(t => t.FinalProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MarketEntry", "UserAccountID", "dbo.UserAccount");
            DropForeignKey("dbo.MarketEntry", "FinalProductID", "dbo.FinalProduct");
            DropForeignKey("dbo.MarketEntry", "EntryTypeId", "dbo.EntryType");
            DropForeignKey("dbo.MarketEntry", "DeliveryLocationID", "dbo.Location");
            DropIndex("dbo.MarketEntry", new[] { "FinalProductID" });
            DropIndex("dbo.MarketEntry", new[] { "UserAccountID" });
            DropIndex("dbo.MarketEntry", new[] { "EntryTypeId" });
            DropIndex("dbo.MarketEntry", new[] { "DeliveryLocationID" });
            DropTable("dbo.MarketEntry");
            DropTable("dbo.EntryType");
            RenameTable(name: "dbo.UserAccount", newName: "UserAccounts");
            RenameTable(name: "dbo.Storage", newName: "Storages");
            RenameTable(name: "dbo.Quality", newName: "Qualities");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Location", newName: "Locations");
            RenameTable(name: "dbo.FinalProduct", newName: "FinalProducts");
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
