using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IPricingViewModelService
    {
        Task<PricingIndexViewModel> GetPricingItems();
    }
}
