using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class StateContract: EntityBase
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public Double PricePerUnit { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        
    }
}
