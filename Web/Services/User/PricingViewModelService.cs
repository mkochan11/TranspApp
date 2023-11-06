using ApplicationCore.Entities.VehicleAggregate;
using ApplicationCore.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Web.Interfaces.User;
using Web.ViewModels;
using Web.ViewModels.User;

namespace Web.Services.User
{
    public class PricingViewModelService : IPricingViewModelService
    {
        private readonly IRepository<VehicleType> _vehicleTypeRepository;

        public PricingViewModelService(IRepository<VehicleType> vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        public async Task<PricingIndexViewModel> GetPricingItems()
        {
            var itemsOnPage = await _vehicleTypeRepository.ListAsync();

            var vm = new PricingIndexViewModel()
            {
                PricingItems = itemsOnPage.Select(i => new PricingItemViewModel
                {
                    Type = i.Type,
                    PricePer100km = i.PricePer100km
                }).ToList(),
            };
            return vm;
        }

    }
}
