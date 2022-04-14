using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Requisition : EntityBase
    {
        //buyer
        public string ReqUserId { get; set; }
        public ReqUser ReqUser { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }  
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public ReqStatus Status { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Approval> Approvals { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
