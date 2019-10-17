using Farmacity.FCDM.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farmacity.FCDM.BackOffice.Context
{
    public partial class DB_FCDM_BackOfficeContext : DbContext
    {
        public DB_FCDM_BackOfficeContext()
        {
        }

        public DB_FCDM_BackOfficeContext(DbContextOptions<DB_FCDM_BackOfficeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
        }

        public virtual DbSet<InternalUser> InternalUsers { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
    }
}
