
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Web.Interfaces.Admin.Manage.Fleet;
using Web.ViewModels.Admin.Manage;
using Web.ViewModels.Admin.Manage.Fleet;
using Web.ViewModels.User;

namespace Web.Services.Admin.Manage.Fleet
{
    public class ViewModelService : IViewModelService
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<VehicleType> _vehicleTypeRepository;

        public ViewModelService(IRepository<Vehicle> vehicleRepository, IRepository<VehicleType> vehicleTypeRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        public async Task DeleteVehicle(int Id)
        {
            Vehicle? vehicle = await _vehicleRepository.GetByIdAsync(Id);
            if (vehicle != null)
            {
                await _vehicleRepository.DeleteAsync(vehicle);
            }
        }

        public async Task<IndexViewModel> GetIndexViewModel()
        {
            var vehicles = await _vehicleRepository.ListAsync();
            var vehicleTypes = await _vehicleTypeRepository.ListAsync();

            var vm = new IndexViewModel()
            {
                Vehicles = vehicles.Select(i => new ItemViewModel
                {
                    Id = i.Id,
                    Model = i.Model,
                    Brand = i.Brand,
                    ProductionYear = i.ProductionYear,
                }).ToList(),

                DetailedVehicles = vehicles.Select(i => new DetailedItemViewModel
                {
                    Id = i.Id,
                    Model = i.Model,
                    Brand = i.Brand,
                    ProductionYear = i.ProductionYear,
                    RegistrationNumber = i.RegistrationNumber,
                    VehicleType = i.VehicleType,
                    Capacity = i.Capacity,
                }).ToList(),

                VehicleTypes = vehicleTypes.Select(i => new VehicleTypeViewModel
                {
                    Id = i.Id,
                    Type = i.Type
                }).ToList(),

            };
            return vm;
        }
    }
}
