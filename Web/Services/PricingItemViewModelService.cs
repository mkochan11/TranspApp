using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class PricingItemViewModelService : IPricingItemViewModelService
    {

        private readonly IRepository<VehicleType> _vehicleTypeRepository;

        public PricingItemViewModelService(IRepository<VehicleType> vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }
        public Task UpdatePricingItem(PricingItemViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
