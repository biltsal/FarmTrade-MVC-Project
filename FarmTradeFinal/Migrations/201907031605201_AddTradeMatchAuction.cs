namespace FarmTradeFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTradeMatchAuction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auction",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuctionDate = c.DateTime(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TradeMatch",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuantityExecuted = c.Double(nullable: false),
                        PriceExecuted = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateExecuted = c.DateTime(nullable: false),
                        AuctionID = c.Int(nullable: false),
                        SellerEntryID = c.Int(nullable: false),
                        BuyerEntryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Auction", t => t.AuctionID, cascadeDelete: true)
                .ForeignKey("dbo.MarketEntry", t => t.BuyerEntryID)
                .ForeignKey("dbo.MarketEntry", t => t.SellerEntryID)
                .Index(t => t.AuctionID)
                .Index(t => t.SellerEntryID)
                .Index(t => t.BuyerEntryID);
            
            AddColumn("dbo.MarketEntry", "Auction_ID", c => c.Int());
            CreateIndex("dbo.MarketEntry", "Auction_ID");
            AddForeignKey("dbo.MarketEntry", "Auction_ID", "dbo.Auction", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TradeMatch", "SellerEntryID", "dbo.MarketEntry");
            DropForeignKey("dbo.TradeMatch", "BuyerEntryID", "dbo.MarketEntry");
            DropForeignKey("dbo.TradeMatch", "AuctionID", "dbo.Auction");
            DropForeignKey("dbo.MarketEntry", "Auction_ID", "dbo.Auction");
            DropIndex("dbo.TradeMatch", new[] { "BuyerEntryID" });
            DropIndex("dbo.TradeMatch", new[] { "SellerEntryID" });
            DropIndex("dbo.TradeMatch", new[] { "AuctionID" });
            DropIndex("dbo.MarketEntry", new[] { "Auction_ID" });
            DropColumn("dbo.MarketEntry", "Auction_ID");
            DropTable("dbo.TradeMatch");
            DropTable("dbo.Auction");
        }
    }
}
