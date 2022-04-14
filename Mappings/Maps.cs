using AutoMapper;
using ReqSystem.Models;
using ReqSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReqSystem.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Requisition, RequisitionVM>().ReverseMap();

        }
    }
}
