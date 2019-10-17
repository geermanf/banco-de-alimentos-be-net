using Farmacity.FCDM.BackOffice.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Farmacity.FCDM.BackOffice.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {

        public IInternalUserRepository InternalUserRepository { get; }
        public IOrganizationRepository OrganizationRepository { get; }


        private readonly DB_FCDM_BackOfficeContext _dbContext;

        public UnitOfWork (IInternalUserRepository internalUserRepository, IOrganizationRepository organizationRepository, DB_FCDM_BackOfficeContext dbContext)
        {
            InternalUserRepository = internalUserRepository;
            OrganizationRepository = organizationRepository;
            _dbContext = dbContext;
        }

        public async Task<int> CompleteAsync()
        {
            var rows = await _dbContext.SaveChangesAsync();
            return rows;
        }

        public int Complete()
        {
            var rows = _dbContext.SaveChanges();
            return rows;
        }

        public void CreateMigrations()
        {
            _dbContext.Database.Migrate();
        }
    }
}