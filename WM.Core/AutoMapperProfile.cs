using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Core.Entities;
using WM.Core.Models;
using WM.Core.ViewModels;

namespace WM.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductModel, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
