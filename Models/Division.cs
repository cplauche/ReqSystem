using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Division : EntityBase
    {
        public String ReqUserId { get; set; }
        public ReqUser ReqUser { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
