using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sales.API.Domain.DTOs;
using Sales.API.Domain.DTOs.Product;
using Sales.API.Domain.Entities;

namespace Sales.API.CrossCutting.DependencyInjection
{
    public class ConfigureMappers
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(config =>
            {
                #region [ProductMapper]
                config.CreateMap<Product, ProductDTO>();
                config.CreateMap<ProductDTO, Product>();
                config.CreateMap<Product, ProductResponseDTO>();
                config.CreateMap<ProductResponseDTO, Product>();
                #endregion

                #region [ComissionMapper]
                config.CreateMap<Comission, ComissionDTO>();
                config.CreateMap<ComissionDTO, Comission>();
                #endregion

            }).CreateMapper());
        }
    }
}
