using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Web.Interfaces.Admin.ManageFleet;

namespace Web.Services.Admin.ManageFleet
{
    public class UpdateViewModelService : IUpdateViewModelService
    {
        private readonly IRepository<Vehicle> _vehicleRepository;

        public UpdateViewModelService(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<Vehicle> GetVehicleByIdAsync(int Id)
        {
            try
            {
                var Vehicle = await _vehicleRepository.GetByIdAsync(Id);
                return Vehicle;

            }catch (Exception ex)
            {
                throw new Exception("Vehicle not found");
            }
        }
    }
}
