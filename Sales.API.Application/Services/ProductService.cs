using AutoMapper;
using Sales.API.Domain.DTOs;
using Sales.API.Domain.Entities;
using Sales.API.Domain.Interfaces.Repositories;
using Sales.API.Domain.Interfaces.Services;

namespace Sales.API.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IComissionRepository _comissionRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IComissionRepository comissionRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _comissionRepository = comissionRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            var comission = await _comissionRepository.GetByIdAsync(product.ComissionId);

            product.TotalPrice = CalculatePrice(product.Amount, product.Price);
            product.ComissionPrice = CalculateComission(product.TotalPrice, comission.Percentage);

            await _productRepository.CreateAsync(product);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task DeleteAsync(Guid id)
        {

            await _productRepository.DeleteAsync(id);
        }

        public async Task<ICollection<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<ICollection<ProductDTO>>(products);

        }

        public async Task<ProductDTO> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _productRepository.EditAsync(product);

            var result = _mapper.Map<ProductDTO>(product);
            return result;
        }
        public static double CalculatePrice(int amount, double price)
        {
            var result = amount * price;
            return result;
        }

        public static double CalculateComission(double totalPrice, int percentage)
        {
            var comissionPrice = (totalPrice * percentage)/100;
            return comissionPrice;
        }
    }
}
