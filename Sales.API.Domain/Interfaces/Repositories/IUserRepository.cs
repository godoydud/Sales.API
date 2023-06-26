using Sales.API.Domain.Entities;

namespace Sales.API.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User> GetUserByIdAsync(Guid id);
    }
}
