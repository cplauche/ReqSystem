using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Comment: EntityBase
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }

        public int RequisitionId { get; set; }
        public Requisition Requisition { get; set; }
    }
}
