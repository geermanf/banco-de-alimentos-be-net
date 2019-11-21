using BancoDeAlimentos.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BancoDeAlimentos.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {

        public IInternalUserRepository InternalUserRepository { get; }
        public IOrganizationRepository OrganizationRepository { get; }
        public IProductRepository ProductRepository { get; }

        public IDeliveryRepository DeliveryRepository { get; }


        private readonly DB_FCDM_BackOfficeContext _dbContext;

        public UnitOfWork (IInternalUserRepository internalUserRepository, IOrganizationRepository organizationRepository,
                            IProductRepository productRepository, IDeliveryRepository deliveryRepository, DB_FCDM_BackOfficeContext dbContext)
        {
            InternalUserRepository = internalUserRepository;
            OrganizationRepository = organizationRepository;
            ProductRepository = productRepository;
            DeliveryRepository = deliveryRepository;
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


        public void GenerateBaseData()
        {
            if (!_dbContext.Products.AnyAsync(x => x.Name == "hamburguesas").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "hamburguesas", Description = "hamburguesas", Stock = 5 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "aceite de girasol").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "aceite de girasol", Description = "aceite de girasol", Stock = 20 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "aceite de maíz").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "aceite de maíz", Description = "aceite de maíz", Stock = 30 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "arroz").Result)
                _dbContext.Products.Add(new Entities.Product { Name = " arroz", Description = " arroz", Stock = 11 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "azúcar").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "azúcar", Description = "azúcar", Stock = 200 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "sal").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "sal", Description = "sal", Stock = 50 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "atún").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "atún", Description = "atún", Stock = 30 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "mermelada").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "mermelada", Description = "mermelada", Stock = 50 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "mate cocido").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "mate cocido", Description = "mate cocido", Stock = 200 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "té").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "té", Description = "té", Stock = 250 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "leche").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "leche", Description = "leche", Stock = 500 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "fideos").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "fideos", Description = "fideos", Stock = 30 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "agua").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "agua", Description = "agua", Stock = 1000 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "salchichas").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "salchichas", Description = "salchichas", Stock = 50 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "galletitas").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "galletitas", Description = "galletitas", Stock = 500 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "manteca").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "manteca", Description = "manteca", Stock = 50 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "queso").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "queso", Description = "queso", Stock = 100 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "yogurt").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "yogurt", Description = "yogurt", Stock = 50 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "dulce de leche").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "dulce de leche", Description = "dulce de leche", Stock = 0 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "gaseosa").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "gaseosa", Description = "gaseosa", Stock = 0 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "agua gasificada").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "agua gasificada", Description = "agua gasificada", Stock = 0 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "picadillo de carne").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "picadillo de carne", Description = "picadillo de carne", Stock = 20 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "paté").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "paté", Description = "paté", Stock = 30 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "pan").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "pan", Description = "pan", Stock = 50 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "harina de maíz").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "harina de maíz", Description = "harina de maíz", Stock = 200 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "harina de trigo").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "harina de trigo", Description = "harina de trigo", Stock = 330 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "salsa").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "salsa", Description = "salsa", Stock = 50 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "mayonesa").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "mayonesa", Description = "mayonesa", Stock = 50 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "mostaza").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "mostaza", Description = "mostaza", Stock = 20 });

            if (!_dbContext.Products.AnyAsync(x => x.Name == "café").Result)
                _dbContext.Products.Add(new Entities.Product { Name = "café", Description = "café", Stock = 50 });

            if (!_dbContext.InternalUsers.AnyAsync(x => x.Email == "admin").Result)
                _dbContext.InternalUsers.Add(new Entities.InternalUser { Email = "admin", IsOrganization = false, Key = "admin", Password = "admin", Status = Entities.Enum.InternalUserStatus.Enabled, OrganizationInfo = null });


            Complete();
        }
    }
}