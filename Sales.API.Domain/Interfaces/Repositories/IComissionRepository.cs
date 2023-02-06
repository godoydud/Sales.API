using Sales.API.Domain.Entities;

namespace Sales.API.Domain.Interfaces.Repositories
{
    public interface IComissionRepository
    {
        Task<Comission> GetByIdAsync(Guid id);
        Task<ICollection<Comission>> GetAllAsync();
        Task<Comission> CreateAsync(Comission comission);
        Task EditAsync(Comission comission);
        Task<bool> DeleteAsync(Guid id);
    }
}
