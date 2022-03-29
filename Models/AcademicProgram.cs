using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class AcademicProgram: EntityBase
    {
        public String Name { get; set; }
        public String Description { get; set; }
        //Is a description field important? When would this be used?
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
