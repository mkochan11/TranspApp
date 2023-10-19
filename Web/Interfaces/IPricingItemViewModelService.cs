using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IPricingItemViewModelService
    {
        Task UpdatePricingItem(PricingItemViewModel viewModel);
    }
}
