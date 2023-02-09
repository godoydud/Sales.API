using Sales.API.Domain.DTOs.Product;

namespace Sales.API.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductDTO> CreateAsync(ProductDTO productDTO);
        Task<ICollection<ProductResponseDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(Guid id);
        Task<ProductDTO> UpdateAsync(ProductDTO productDTO);
        Task DeleteAsync(Guid id);
    }
}
