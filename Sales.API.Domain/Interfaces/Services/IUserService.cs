using Sales.API.Domain.DTOs.Base;
using Sales.API.Domain.DTOs.User;

namespace Sales.API.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<ResponseDTO<UserDTO>> CreateAsync(UserDTO userDTO);
        Task<ICollection<UserDTO>> GetAllAsync();
        bool Login(string username, string password);
        Task<UserDTO>GetUserByIdAsync(Guid id);
    }
}
