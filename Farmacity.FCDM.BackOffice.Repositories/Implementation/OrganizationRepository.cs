using Farmacity.FCDM.BackOffice.Context;
using Farmacity.FCDM.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacity.FCDM.BackOffice.Repositories.Implementation
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public DB_FCDM_BackOfficeContext _dbContext => _context as DB_FCDM_BackOfficeContext;

        public OrganizationRepository(DB_FCDM_BackOfficeContext context) : base(context)
        {
        }
    }
}
