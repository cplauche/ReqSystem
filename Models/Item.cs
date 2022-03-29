using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Item : EntityBase
    {
        public String Name { get; set; }
        public int ItemNumber { get; set; }
        public String Description { get; set; }
        public Double Price { get; set; }
        public int NumberInStock { get; set; }
        public Vendor SuggestedVendor { get; set; }
        public ICollection<CompetingItem> CompetingItems { get; set; }

    }
}
