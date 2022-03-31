using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Budget : EntityBase
    {
        public double Amount { get; set; }
        public BudgetStatus Status { get; set; }
        public String Name { get; set; }
        public bool IsAnnual { get; set; }
        public int BudgetCodeNumber { get; set; }
        public bool IsActive { get; set; } // Doesn't status cover this??


    }
}
