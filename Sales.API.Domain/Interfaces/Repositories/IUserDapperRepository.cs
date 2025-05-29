using Sales.API.Domain.DTOs.User;
using Sales.API.Domain.Entities;

namespace Sales.API.Domain.Interfaces.Repositories
{
    public interface IUserDapperRepository
    {
        //Task<ICollection<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<UserDTO?> GetUserByIdAsync(Guid id);
    }
}
