using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeFinal.Models
{
    public class TradeMatch
    {
        // * Properties * //
        public int ID { get; private set; }
        public double QuantityExecuted { get; set; }
        public decimal PriceExecuted { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateExecuted { get; set; }

        // Foreign Keys Properties
        public int AuctionID { get; set; }
        public int SellerEntryID { get; set; }
        public int BuyerEntryID { get; set; }

        // Navigation Properties
        public Auction Auction { get; set; }
        public MarketEntry SellerEntry { get; set; }
        public MarketEntry BuyerEntry { get; set; }
        //public TradeSummary TradeSummary { get; set; }

        // * Constructors * //
        // Custom Constructor
        public TradeMatch(int auctionID, int sellerEntryID, int buyerEntryID,
                          double quantityExecuted, decimal priceExecuted)
        {
            AuctionID = auctionID;
            SellerEntryID = sellerEntryID;
            BuyerEntryID = buyerEntryID;
            QuantityExecuted = quantityExecuted;
            PriceExecuted = priceExecuted;
            DateExecuted = DateTime.Now;
        }

        // Default Constructor
        public TradeMatch()
        {

        }










    }
}