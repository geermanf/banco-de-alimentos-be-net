using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Farmacity.FCDM.BackOffice.Repositories
{
    public interface IUnitOfWork
    {

        IInternalUserRepository InternalUserRepository { get; }
        IOrganizationRepository OrganizationRepository { get; }

        int Complete();
        Task<int> CompleteAsync();
        void CreateMigrations();
    }
}
