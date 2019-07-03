using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeFinal.Models
{
    public class MarketEntry
    {
        // * Properties * //
        public int ID { get; private set; }

        [Display(Name = "ΠΟΣΟΤΗΤΑ ΠΡΟΙΟΝΤΟΣ")]
        public double EntryQuantity { get; set; }


        //[AuctionInProgress]
        public DateTime EntryDate { get; set; }

        [Display(Name = "ΤΙΜΗ ΠΡΟΙΟΝΤΟΣ / ΚΙΛΟ")]
        [DisplayFormat(DataFormatString = "{0:n} €")]
        public decimal EntryPrice { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΔΟΣΗΣ")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "ΤΟΠΟΘΕΣΙΑ ΠΑΡΑΛΑΒΗΣ")]
        public int DeliveryLocationID { get; set; }
        public Location DeliveryLocation { get; set; }

        [Display(Name = "ΤΥΠΟΣ ΕΝΤΟΛΗΣ")]
        public byte EntryTypeId { get; set; }
        public EntryType EntryType { get; set; }

        // Foreign Keys Properties
        public int UserAccountID { get; set; }
        public UserAccount UserAccount { get; set; }

        [Display(Name = "ΟΝΟΜΑΣΙΑ ΠΡΟΙΟΝΤΟΣ")]
        public int FinalProductID { get; set; }
        public FinalProduct FinalProduct { get; set; }

        public int AuctionID { get; set; }
        public virtual Auction Auction { get; set; }

        // * Constructors * //
        // Default Constructor
        public MarketEntry()
        {

        }

        // Custom Constructor
        public MarketEntry(int auctionID,int userAccountID, int finalProductID, double entryQuantity,
                            decimal entryPrice, DateTime deliveryDate,
                            int deliveryLocationId, byte entryTypeId)
        {
            UserAccountID = userAccountID;
            FinalProductID = finalProductID;
            AuctionID = auctionID;
            EntryDate = DateTime.Now;
            EntryQuantity = entryQuantity;
            EntryPrice = entryPrice;
            DeliveryDate = deliveryDate;
            DeliveryLocationID = deliveryLocationId;
            EntryTypeId = entryTypeId;
        }

        // * Methods *
        // Setting Buyer Order Quantity
        public void SetNewQuantity(double newQuantity)
        {
            EntryQuantity = newQuantity;
        }




    }
}