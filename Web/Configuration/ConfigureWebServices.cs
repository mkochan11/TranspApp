using MediatR;
using Web.Interfaces.Admin.Manage.Fleet;
using Web.Interfaces.Admin.Manage.Pricing;
using Web.Interfaces.User;
using Web.Services.Admin.Manage.Fleet;
using Web.Services.Admin.Manage.Pricing;
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
            services.AddScoped<Interfaces.Admin.Manage.Fleet.IViewModelService, Services.Admin.Manage.Fleet.ManageFleetViewModelService>();
            services.AddScoped<Interfaces.Admin.Manage.Fleet.IUpdateViewModelService, Services.Admin.Manage.Fleet.FleetUpdateViewModelService>();
            services.AddScoped<Interfaces.Admin.Manage.Pricing.IViewModelService, Services.Admin.Manage.Pricing.ManagePricingViewModelService>();
            services.AddScoped<Interfaces.Admin.Manage.Pricing.IUpdateViewModelService, Services.Admin.Manage.Pricing.PricingUpdateViewModelService>();


            return services;
        }
    }
}
