using ApplicationCore.Entities.VehicleAggregate;
using ApplicationCore.Interfaces;
using Web.Interfaces.Admin.Manage.Pricing;
using Web.ViewModels.Admin.Manage.Pricing;
using Web.ViewModels.User;

namespace Web.Services.Admin.Manage.Pricing
{
    public class ManagePricingViewModelService : IManagePricingViewModelService
    {

        private readonly IRepository<VehicleType> _vehicleTypeRepository;

        public ManagePricingViewModelService(IRepository<VehicleType> vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }
        public async Task<IndexViewModel> GetIndexViewModel()
        {
            var itemsOnPage = await _vehicleTypeRepository.ListAsync();

            var vm = new IndexViewModel()
            {
                PricingItems = itemsOnPage.Select(i => new ItemViewModel
                {
                    Id = i.Id,
                    Type = i.Type,
                    PricePer100km = i.PricePer100km
                }).ToList(),
            };
            return vm;
        }
    }
}
