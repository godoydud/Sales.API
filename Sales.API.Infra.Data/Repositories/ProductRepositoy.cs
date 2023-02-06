using Microsoft.EntityFrameworkCore;
using Sales.API.Domain.Entities;
using Sales.API.Domain.Interfaces.Repositories;
using Sales.API.Infra.Data.Context;
using System.Data;

namespace Sales.API.Infra.Data.Repositories
{
    public class ProductRepositoy : IProductRepository
    {
        private readonly CoreContext _appDbContext;
        public ProductRepositoy(CoreContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _appDbContext.Add(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await GetByIdAsync(id);

                if (result == null)
                    return false;

                _appDbContext.Remove(result);

                _appDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task EditAsync(Product product)
        {
            _appDbContext.Update(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _appDbContext.Product.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return _appDbContext.Product.FirstOrDefault(x => x.Id == id);
        }
    }
}
