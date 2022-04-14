using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Approval : EntityBase
    {
        public Requisition Requisition { get; set; }
        public int RequisitionId { get; set; }
        public ReqUser ReqUser { get; set; }
        public string ReqUserId { get; set; }
    }
}
