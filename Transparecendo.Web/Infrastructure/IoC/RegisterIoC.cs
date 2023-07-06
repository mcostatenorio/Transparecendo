using Transparecendo.Web.Request;
using Transparecendo.Web.Services;
using Transparecendo.Web.Services.Interfaces;
using Transparecendo.Web.WebRequest.Interfaces;

namespace Transparecendo.Web.Infrastructure.IoC
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
