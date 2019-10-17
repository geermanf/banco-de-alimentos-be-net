using Farmacity.FCDM.BackOffice.DTOs;
using Farmacity.FCDM.BackOffice.DTOs.Request;
using Farmacity.FCDM.BackOffice.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Farmacity.FCDM.BackOffice.Services
{
    public interface IInternalUserService
    {
        InternalUserResponse GetInternalUserInformation(InternalUserLoginRequest internalUserLoginRequest);
        IEnumerable<InternalUserDto> GetAll();
        InternalUserDto Get(string key);

        //InternalUserDto Update(InternalUserRequest updateInternalUserRequest);
        void Create(string Email, string Password);
        //void Remove(string key);
    }
}
