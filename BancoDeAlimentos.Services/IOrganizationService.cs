using BancoDeAlimentos.DTOs;
using BancoDeAlimentos.DTOs.Request;
using BancoDeAlimentos.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeAlimentos.Services
{
    public interface IOrganizationService
    {
        Organization GetOrganizationByEmail(string email);
        IEnumerable<Organization> GetAllAwaiting();

        IEnumerable<Organization> GetAllApproved();
        Organization Get(string key);
        Organization RegisterNewOrganization(RegisterOrganizationRequest request);

        void EditAmountOfPeople(EditAmountOfPeopleRequest request);

        void EditStatus(string key, string status);


        //InternalUserDto Update(InternalUserRequest updateInternalUserRequest);

        //void Remove(string key);
    }
}
