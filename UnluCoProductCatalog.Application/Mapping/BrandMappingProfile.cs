using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UnluCoProductCatalog.Application.ViewModels.BrandViewModels;
using UnluCoProductCatalog.Application.ViewModels.UsingStatusViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Mapping
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<BrandViewModel, Brand>().ReverseMap();
        }
    }

    public class UsingStatusMappingProfile : Profile
    {
        public UsingStatusMappingProfile()
        {
            CreateMap<UsingStatusViewModel, UsingStatus>().ReverseMap();
        }
    }
}
