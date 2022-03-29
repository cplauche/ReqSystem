using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Department : EntityBase
    {
        public int DivisionId { get; set; }
        public Division Division { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
        
        public ICollection<ReqUser> ReqUsers { get; set; }
        public ICollection<AcademicProgram> AcademicPrograms { get; set; }
    }
}
