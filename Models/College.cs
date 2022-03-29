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
        public Department Address { get; set; }
        public List<Division> Divisions { get; set; }
        public Semester Semester { get; set; }
        public IEnumerable<StateContract> StateContracts { get; set; }
        public Budget Budget { get; set; }
    }
}
