using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Division : EntityBase
    {
        public IEnumerable<Department> Departments { get; set; }
        public ReqUser Chair { get; set; }
    }
}
