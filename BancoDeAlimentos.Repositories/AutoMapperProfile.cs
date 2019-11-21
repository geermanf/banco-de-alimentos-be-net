using AutoMapper;
using BancoDeAlimentos.DTOs;
using BancoDeAlimentos.DTOs.Request;
using BancoDeAlimentos.Entities;
using BancoDeAlimentos.Entities.Common;
using BancoDeAlimentos.Entities.Enum;
using System;
using System.Linq;

namespace BancoDeAlimentos.Repositories
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<InternalUser, InternalUserDto>(MemberList.None);

            CreateMap<InternalUser, InternalUserResponse>(MemberList.None);

            CreateMap<RegisterOrganizationRequest, Organization>(MemberList.None)
                .ForMember(dest => dest.Status, opt => opt.Ignore());

            CreateMap<Delivery, DeliveryDto>(MemberList.None)
                .ForMember(dest => dest.Status, opt => opt.ToString())
                .ForMember(dest => dest.ProductDeliverys, opt => opt.MapFrom(del => del.ProductDeliverys.Select(pd => new ProductDeliveryDto { ProductName = pd.Product.Name, Quantity = pd.Quantity })))
                .ForMember(dest => dest.productsToShow, opt => opt.MapFrom(del => string.Join(", ", del.ProductDeliverys.Select(pd => pd.Product.Name + ": " + pd.Quantity.ToString()))));

            CreateMap<ProductDelivery, ProductDeliveryDto>(MemberList.None)
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(pd => pd.Product.Name))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(pd => pd.Quantity));
        }

    }
}
