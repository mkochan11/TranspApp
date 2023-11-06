using ApplicationCore.Entities.VehicleAggregate;
using ApplicationCore.Interfaces;
using Web.Interfaces.User;
using Web.ViewModels.User;

namespace Web.Services.User
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
