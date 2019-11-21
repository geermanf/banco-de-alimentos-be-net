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
        IProductRepository ProductRepository { get; }
        IDeliveryRepository DeliveryRepository { get; }

        void GenerateBaseData();

        int Complete();
        Task<int> CompleteAsync();
        void CreateMigrations();
    }
}
