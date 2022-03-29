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
        
        public ICollection<ReqUser> Members { get; set; }
        public ICollection<AcademicProgram> AcademicPrograms { get; set; }
    }
}
