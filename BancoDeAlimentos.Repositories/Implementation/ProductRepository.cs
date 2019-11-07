using BancoDeAlimentos.Context;
using BancoDeAlimentos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancoDeAlimentos.Repositories.Implementation
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public DB_FCDM_BackOfficeContext _dbContext => _context as DB_FCDM_BackOfficeContext;

        public ProductRepository(DB_FCDM_BackOfficeContext context) : base(context)
        {
        }
    }
}
