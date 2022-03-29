using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class CompetingItem : Item
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
