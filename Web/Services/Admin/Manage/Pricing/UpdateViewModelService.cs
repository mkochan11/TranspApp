using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Web.Interfaces.Admin.Manage.Pricing;

namespace Web.Services.Admin.Manage.Pricing
{
    public class UpdateViewModelService : IUpdateViewModelService
    {
        private readonly IRepository<VehicleType> _vehicleTypesRepository;

        public UpdateViewModelService( IRepository<VehicleType> vehicleTypesRepository)
        {
            _vehicleTypesRepository = vehicleTypesRepository;
        }
        public async Task<VehicleType> GetVehicleTypeByIdAsync(int id)
        {
            try
            {
                var VehicleType = await _vehicleTypesRepository.GetByIdAsync(id);
                return VehicleType;
            }catch (Exception ex)
            {
                throw new Exception("Vehicle Type not found.");
            }

        }
    }
}
