using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeFinal.Models
{

    public enum MetricUnits
    {
        Tones, Kilograms, Grams
    }




    public class FinalProduct
    {
        public int ID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int QualityID { get; set; }
        public Quality Quality { get; set; }
       

        public int UserAccountID { get; set; }
        public UserAccount UserAccount { get; set; }

        public int LocationID { get; set; }
        public Location Location { get; set; } //

        public int? StorageID { get; set; }
        public Storage Storage { get; set; } //
       
        public DateTime ImportDateToStorage { get; set; }
        public DateTime? ExportDateFromStorage { get; set; }
        public bool IsOrganic { get; set; }
        public string Comments { get; set; }
        public int Quantity { get; set; }
        public MetricUnits MetricUnits { get; set; }




    }
}