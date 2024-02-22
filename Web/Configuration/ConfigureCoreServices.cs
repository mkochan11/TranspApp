using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Data;

namespace Web.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IVehicleService), typeof(VehicleService));
            services.AddScoped(typeof(IVehicleTypeService), typeof(VehicleTypeService));
            services.AddScoped(typeof(IEmployeeContractService), typeof(EmployeeContractService));
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
            services.AddScoped(typeof(IOrderService), typeof(OrderService));
            
            return services;
        }
    }
}
