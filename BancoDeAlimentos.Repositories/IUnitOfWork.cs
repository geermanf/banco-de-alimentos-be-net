using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeAlimentos.Repositories
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
