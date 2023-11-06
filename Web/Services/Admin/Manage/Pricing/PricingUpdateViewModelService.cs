using ApplicationCore.Entities.VehicleAggregate;
using ApplicationCore.Interfaces;
using Web.Interfaces.Admin.Manage.Pricing;

namespace Web.Services.Admin.Manage.Pricing
{
    public class PricingUpdateViewModelService : IUpdateViewModelService
    {
        private readonly IRepository<VehicleType> _vehicleTypesRepository;

        public PricingUpdateViewModelService( IRepository<VehicleType> vehicleTypesRepository)
        {
            _vehicleTypesRepository = vehicleTypesRepository;
        }
        public async Task<VehicleType> GetVehicleTypeByIdAsync(int id)
        {
            try
            {
                var VehicleType = await _vehicleTypesRepository.GetByIdAsync(id);
                return VehicleType;
            }catch
            {
                throw new Exception("Vehicle Type not found.");
            }

        }
    }
}
