using AutoMapper;
using Farmacity.FCDM.BackOffice.DTOs;
using Farmacity.FCDM.BackOffice.DTOs.Request;
using Farmacity.FCDM.BackOffice.Entities;
using Farmacity.FCDM.BackOffice.Entities.Common;
using Farmacity.FCDM.BackOffice.Entities.Enum;
using System;

namespace Farmacity.FCDM.BackOffice.Repositories
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
