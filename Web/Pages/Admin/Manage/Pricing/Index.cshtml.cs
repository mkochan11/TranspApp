using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Interfaces.Admin.Manage.Pricing;
using Web.ViewModels.Admin.Manage.Pricing;

namespace Web.Pages.Admin.Manage.Pricing
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IViewModelService _viewModelService;

        public IndexModel(IViewModelService viewModelService)
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
    }
}
