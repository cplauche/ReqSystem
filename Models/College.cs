using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class College : EntityBase
    {
        public String Name { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
        public ICollection<Division> Divisions { get; set; }
        public ICollection<StateContract> StateContracts { get; set; }
    }
}
