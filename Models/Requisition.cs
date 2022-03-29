using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Requisition : EntityBase
    {
        //Probably best to seperate this into different classes to represent the
        //stages of a requisition
        public ReqUser Buyer { get; set; }
        public Budget Budget { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public Vendor Vendor { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        //There are a series of comments through the req cycle
        public ReqStatus Status { get; set; }



    }
}
