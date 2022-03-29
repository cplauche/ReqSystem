using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class FileAttachment: EntityBase
    {
        public DateTime DateSubmitted { get; set; }
        public String Description { get; set; }
        public String FileName { get; set; } 
    }
}
