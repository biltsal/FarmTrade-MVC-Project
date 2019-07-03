using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeFinal.Models
{
    public class Auction
    {
        // * Properties * //
        public int ID { get; private set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AuctionDate { get; set; }

        public bool IsCompleted { get; set; }

        // Navigation Properties
        public ICollection<MarketEntry> MarketEntries { get; set; }
        public ICollection<TradeMatch> MatchedOrders { get; set; }

        // * Constructors * //
        // Custom Constructor
        public Auction(DateTime auctionDate)
        {
            AuctionDate = auctionDate;
        }

        // Default Constructor
        public Auction()
        {

        }

        

        



    }
}