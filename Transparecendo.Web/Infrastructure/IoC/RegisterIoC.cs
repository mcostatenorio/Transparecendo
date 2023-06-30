using Transparecendo.Service.Web.Request;
using Transparecendo.Service.Web.Services;
using Transparecendo.Service.Web.Services.Interfaces;
using Transparecendo.Service.Web.WebRequest.Interfaces;

namespace Transparecendo.Service.API.Infrastructure.IoC
{
    public static class RegisterIoC
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<GetWebRequest>();

            services.AddScoped<IGetWebRequest, GetWebRequest>();

            services.AddScoped<ICorporateSpendingService, CorporateSpendingService>();

            return services;
        }
    }
}
