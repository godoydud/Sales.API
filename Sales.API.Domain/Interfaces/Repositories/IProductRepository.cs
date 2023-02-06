using Sales.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.API.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<ICollection<Product>> GetAllAsync();
        Task<Product> CreateAsync(Product product);
        Task EditAsync (Product product);
        Task<bool> DeleteAsync(Guid id);
    }
}
