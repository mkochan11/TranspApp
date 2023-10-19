using MediatR;
using Web.Interfaces;
using Web.Services;

namespace Web.Configuration
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IFleetViewModelService, FleetViewModelService>();
            services.AddScoped<IFleetItemViewModelService, FleetItemViewModelService>();
            services.AddScoped<IPricingItemViewModelService, PricingItemViewModelService>();
            services.AddScoped<IPricingViewModelService, PricingViewModelService>();

            return services;
        }
    }
}
