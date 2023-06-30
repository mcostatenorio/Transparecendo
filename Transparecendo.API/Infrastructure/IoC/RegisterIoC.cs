using Microsoft.EntityFrameworkCore;
using Transparecendo.Core.Mapper;
using Transparecendo.Service.API.Infrastructure.DbContext;
using Transparecendo.Service.API.Interfaces.Repository;
using Transparecendo.Service.API.Interfaces.Services;
using Transparecendo.Service.API.Services;
using Transparecendo.Service.Domain.Repository;
using Transparecendo.Core.Mapper.Interfaces;

namespace Transparecendo.Service.API.Infrastructure.IoC
{
    public static class RegisterIoC
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TransparecendoDbContext>(options => options.UseSqlServer(configuration["SqlConnection:SqlConnectionString"]));

            services.AddScoped<IServiceCorporateSpending, ServiceCorporateSpending>();

            services.AddScoped<IRepositoryCorporateSpending, RepositoryCorporateSpending>();

            services.AddScoped<IMapperCorporateSpending, MapperCorporateSpending>();

            return services;
        }
    }
}
