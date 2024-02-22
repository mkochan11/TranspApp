using MediatR;
using Web.Interfaces.Admin.Manage.Contracts;
using Web.Interfaces.Admin.Manage.Employees;
using Web.Interfaces.Admin.Manage.Fleet;
using Web.Interfaces.Admin.Manage.Pricing;
using Web.Interfaces.User;
using Web.Services.Admin.Manage.Contracts;
using Web.Services.Admin.Manage.Employees;
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
            services.AddScoped<IPricingViewModelService, PricingViewModelService>();
            services.AddScoped<IManageFleetViewModelService, ManageFleetViewModelService>();
            services.AddScoped<IFleetUpdateViewModelService, FleetUpdateViewModelService>();
            services.AddScoped<IManagePricingViewModelService, ManagePricingViewModelService>();
            services.AddScoped<IPricingUpdateViewModelService, PricingUpdateViewModelService>();
            services.AddScoped<IManageEmployeesViewModelService, ManageEmployeesViewModelService>();
            services.AddScoped<IEmployeeDetailsViewModelService, EmployeeDetailsViewModelService>();
            services.AddScoped<IManageContractsViewModelService, ManageContractsViewModelService>();
            services.AddScoped<IMyOrdersViewModelService, MyOrdersViewModelService>();


            return services;
        }
    }
}
