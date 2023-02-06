using Sales.API.Domain.DTOs;

namespace Sales.API.Domain.Interfaces.Services
{
    public interface IComissionService
    {
        Task<ComissionDTO> CreateAsync(ComissionDTO comissionDTO);
        Task<ICollection<ComissionDTO>> GetAllAsync();
        Task<ComissionDTO> GetByIdAsync(Guid id);
        Task<ComissionDTO> UpdateAsync(ComissionDTO productDTO);
        Task DeleteAsync(Guid id);
    }
}
