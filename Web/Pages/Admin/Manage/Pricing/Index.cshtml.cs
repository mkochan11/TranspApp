using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Interfaces.Admin.Manage.Pricing;
using Web.ViewModels.Admin.Manage.Pricing;

namespace Web.Pages.Admin.Manage.Pricing
{
    [Authorize(Policy = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IManagePricingViewModelService _viewModelService;

        public IndexModel(IManagePricingViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }

        public required IndexViewModel PricingModel { get; set; } = new IndexViewModel();

        public async Task OnGet()
        {
            PricingModel = await _viewModelService.GetIndexViewModel();
        }

        public Task<RedirectToPageResult> OnPostAdd()
        {
            return Task.FromResult(RedirectToPage("./Create"));
        }
        public Task<RedirectToPageResult> OnPostUpdate(int Id)
        {
            TempData["VehicleTypeId"] = Id;
            return Task.FromResult(RedirectToPage("./Update"));
        }

    }
}
