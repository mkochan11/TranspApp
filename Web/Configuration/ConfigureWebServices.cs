using MediatR;
using Web.Interfaces.Admin.ManageFleet;
using Web.Interfaces.User;
using Web.Services.Admin.ManageFleet;
using Web.Services.User;

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
            services.AddScoped<IViewModelService, ViewModelService>();
            services.AddScoped<IUpdateViewModelService, UpdateViewModelService>();

            return services;
        }
    }
}
