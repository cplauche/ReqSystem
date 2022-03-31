using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class ReqUser: IdentityUser
    {
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Requisition> Requisitions{ get; set; }
        public ICollection<Budget> Budgets { get; set; }
    }
}
