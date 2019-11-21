using BancoDeAlimentos.Context;
using BancoDeAlimentos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancoDeAlimentos.Repositories.Implementation
{
    public class DeliveryRepository : Repository<Delivery>, IDeliveryRepository
    {
        public DB_FCDM_BackOfficeContext _dbContext => _context as DB_FCDM_BackOfficeContext;

        public DeliveryRepository(DB_FCDM_BackOfficeContext context) : base(context)
        {
        }
    }
}
