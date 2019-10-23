using AutoMapper;
using BancoDeAlimentos.DTOs;
using BancoDeAlimentos.DTOs.Request;
using BancoDeAlimentos.Entities;
using BancoDeAlimentos.Entities.Common;
using BancoDeAlimentos.Entities.Enum;
using System;

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

        }

    }
}
