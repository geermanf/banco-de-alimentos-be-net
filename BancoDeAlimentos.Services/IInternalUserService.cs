using BancoDeAlimentos.DTOs;
using BancoDeAlimentos.DTOs.Request;
using BancoDeAlimentos.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeAlimentos.Services
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
