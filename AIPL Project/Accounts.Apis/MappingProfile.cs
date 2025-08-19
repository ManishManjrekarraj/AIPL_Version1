using AccontApi.Core.Entities;
using AccountApi.Core;
using AccountApi.Core.Entities;
using Accounts.Models.UIModels;
//using AccountsUIBlazor.UIModels;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;

namespace Accounts.Apis
{
   public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            

            CreateMap<UIRopeConstants, RopeConstants>().ReverseMap();

            CreateMap<UIChainConstants, ChainConstants>().ReverseMap();

            CreateMap<UIFloatCategory, FloatCategory>()//.ReverseMap();
                .ForMember(dest => dest.Floatcategory, opt => opt.MapFrom(src => src.FloatCategory)).ReverseMap();

            CreateMap<UIFloatSelection, FloatSelection>().ReverseMap();

            CreateMap<UIOutputDetails, OutputDetails>().ReverseMap();

            CreateMap<UILoadDatas, LoadDatas>().ReverseMap();

            CreateMap<UIInputsAndLayout, InputsandLayout>().ReverseMap();

            CreateMap<UILoadDatas, UIHydrostatics>().ReverseMap();

            CreateMap<UIProjectDetails, ProjectDetails>().ReverseMap();

            //CreateMap<UICustomer, Customer>().ReverseMap();
            //CreateMap<UICustomer, Customer>().ReverseMap();
            //CreateMap<UICustomer, Customer>().ReverseMap();
            //CreateMap<UICustomer, Customer>().ReverseMap();
            //CreateMap<UICustomer, Customer>().ReverseMap();
            //CreateMap<UICustomer, Customer>().ReverseMap();


        }
    }
}
