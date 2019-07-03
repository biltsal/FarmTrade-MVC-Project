using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeFinal.Models
{
    public class Storage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public int LocationID { get; set; }




    }
}