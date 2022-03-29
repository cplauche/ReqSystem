using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Fee: EntityBase
    {
        public string Description { get; set; }
        public Double Amount { get; set; }
        public String Name { get; set; }
        public Semester Semester { get; set; }
        public Budget Budget { get; set; }

    }
}
