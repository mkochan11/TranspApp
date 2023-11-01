using Web.ViewModels.User;

namespace Web.Interfaces.User
{
    public interface IPricingItemViewModelService
    {
        Task UpdatePricingItem(PricingItemViewModel viewModel);
    }
}
