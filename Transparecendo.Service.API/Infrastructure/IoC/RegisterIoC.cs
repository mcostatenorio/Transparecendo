using Transparecendo.Service.API.Interfaces.Repository;
using Transparecendo.Service.API.Interfaces.Services;
using Transparecendo.Service.API.Services;
using Transparecendo.Service.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Transparecendo.Service.API.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Transparecendo.Service.API.Infrastructure.IoC
{
    public static class RegisterIoC
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TransparecendoDbContext>(options => options.UseSqlServer(configuration["SqlConnection:SqlConnectionString"]));

            services.AddScoped<IServiceCorporateSpending, ServiceCorporateSpending>();

            services.AddScoped<IRepositoryCorporateSpending, RepositoryCorporateSpending>();

            return services;
        }
    }
}
