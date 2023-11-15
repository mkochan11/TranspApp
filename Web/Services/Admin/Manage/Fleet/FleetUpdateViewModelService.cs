using ApplicationCore.Entities.VehicleAggregate;
using ApplicationCore.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Web.Interfaces.Admin.Manage.Fleet;

namespace Web.Services.Admin.Manage.Fleet
{
    public class FleetUpdateViewModelService : IFleetUpdateViewModelService
    {
        private readonly IRepository<Vehicle> _vehicleRepository;

        public FleetUpdateViewModelService(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<Vehicle> GetVehicleByIdAsync(int Id)
        {
            try
            {
                var Vehicle = await _vehicleRepository.GetByIdAsync(Id);
                return Vehicle;

            }
            catch
            {
                throw new Exception("Vehicle not found");
            }
        }
    }
}
