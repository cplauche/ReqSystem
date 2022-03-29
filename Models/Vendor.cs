using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class Vendor : EntityBase
    {
        public string Name { get; set; }
        public Department Address { get; set; }
        public int VendorCode { get; set; }
        //Is VendorCode seperate from its Id?
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
