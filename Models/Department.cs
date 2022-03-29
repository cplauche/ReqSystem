using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Department : EntityBase
    {
        public Division Division { get; set; }
        public Budget Budget { get; set; }
        
        public IEnumerable<ReqUser> Members { get; set; }
        public IEnumerable<AcademicProgram> AcademicPrograms { get; set; }
    }
}
