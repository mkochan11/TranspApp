using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Interfaces.User;
using Web.ViewModels.User;

namespace Web.Pages.Pricing
{
    public class IndexModel : PageModel
    {
        private readonly IPricingViewModelService _pricingViewModelService;

        public IndexModel(IPricingViewModelService pricingViewModelService)
        {
            _pricingViewModelService = pricingViewModelService;
        }

        public required PricingIndexViewModel PricingModel { get; set; } = new PricingIndexViewModel();


        public async Task OnGet(PricingIndexViewModel pricingModel)
        {
            PricingModel = await _pricingViewModelService.GetPricingItems();
        }
    }
}
