using Web.ViewModels.User;

namespace Web.Interfaces.User
{
    public interface IPricingViewModelService
    {
        Task<PricingIndexViewModel> GetPricingItems();
    }
}
