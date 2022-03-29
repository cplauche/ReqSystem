using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Models
{
    public class ReqUser: IdentityUser
    {
        public DateTime HireDate { get; set; }
        public Department Department { get; set; }
    }
}
