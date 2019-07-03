namespace FarmTradeFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MarketEntry", "Auction_ID", "dbo.Auction");
            DropIndex("dbo.MarketEntry", new[] { "Auction_ID" });
            RenameColumn(table: "dbo.MarketEntry", name: "Auction_ID", newName: "AuctionID");
            AlterColumn("dbo.MarketEntry", "AuctionID", c => c.Int(nullable: false));
            CreateIndex("dbo.MarketEntry", "AuctionID");
            AddForeignKey("dbo.MarketEntry", "AuctionID", "dbo.Auction", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MarketEntry", "AuctionID", "dbo.Auction");
            DropIndex("dbo.MarketEntry", new[] { "AuctionID" });
            AlterColumn("dbo.MarketEntry", "AuctionID", c => c.Int());
            RenameColumn(table: "dbo.MarketEntry", name: "AuctionID", newName: "Auction_ID");
            CreateIndex("dbo.MarketEntry", "Auction_ID");
            AddForeignKey("dbo.MarketEntry", "Auction_ID", "dbo.Auction", "ID");
        }
    }
}
