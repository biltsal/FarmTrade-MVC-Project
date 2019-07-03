namespace FarmTradeFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FinalProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        QualityID = c.Int(nullable: false),
                        UserAccountID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        StorageID = c.Int(),
                        ImportDateToStorage = c.DateTime(nullable: false),
                        ExportDateFromStorage = c.DateTime(),
                        IsOrganic = c.Boolean(nullable: false),
                        Comments = c.String(),
                        Quantity = c.Int(nullable: false),
                        MetricUnits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Qualities", t => t.QualityID, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageID)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.QualityID)
                .Index(t => t.UserAccountID)
                .Index(t => t.LocationID)
                .Index(t => t.StorageID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Qualities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TaxNumber = c.Int(nullable: false),
                        DateAccountCreated = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        MobileNumber = c.String(),
                        Email = c.String(),
                        CompanyName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        County = c.String(),
                        PostCode = c.String(),
                        IsBanned = c.Boolean(nullable: false),
                        RoleID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FinalProducts", "UserAccountID", "dbo.UserAccounts");
            DropForeignKey("dbo.FinalProducts", "StorageID", "dbo.Storages");
            DropForeignKey("dbo.Storages", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.FinalProducts", "QualityID", "dbo.Qualities");
            DropForeignKey("dbo.FinalProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.FinalProducts", "LocationID", "dbo.Locations");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Storages", new[] { "LocationID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.FinalProducts", new[] { "StorageID" });
            DropIndex("dbo.FinalProducts", new[] { "LocationID" });
            DropIndex("dbo.FinalProducts", new[] { "UserAccountID" });
            DropIndex("dbo.FinalProducts", new[] { "QualityID" });
            DropIndex("dbo.FinalProducts", new[] { "ProductID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Storages");
            DropTable("dbo.Qualities");
            DropTable("dbo.Products");
            DropTable("dbo.Locations");
            DropTable("dbo.FinalProducts");
            DropTable("dbo.Categories");
        }
    }
}
