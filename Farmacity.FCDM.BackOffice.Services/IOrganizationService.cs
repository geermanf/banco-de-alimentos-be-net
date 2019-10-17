using Farmacity.FCDM.BackOffice.DTOs;
using Farmacity.FCDM.BackOffice.DTOs.Request;
using Farmacity.FCDM.BackOffice.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Farmacity.FCDM.BackOffice.Services
{
    public interface IOrganizationService
    {
        Organization GetOrganizationByEmail(string email);
        IEnumerable<Organization> GetAllAwaiting();

        IEnumerable<Organization> GetAllConfirmed();
        Organization Get(string key);
        Organization RegisterNewOrganization(RegisterOrganizationRequest request);

        //InternalUserDto Update(InternalUserRequest updateInternalUserRequest);

        //void Remove(string key);
    }
}
