using Microsoft.Extensions.DependencyInjection;
using Sales.API.Application.Services;
using Sales.API.Domain.Interfaces.Services;

namespace Sales.API.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IComissionService, ComissionService>();
            services.AddScoped<IUserService, UserService>();
            
        }
    }
}
