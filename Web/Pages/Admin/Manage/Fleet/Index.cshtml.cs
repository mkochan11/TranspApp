using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;
using Web.Interfaces.Admin.Manage.Fleet;
using Web.ViewModels.Admin.Manage.Fleet;

namespace Web.Pages.Admin.Manage.Fleet
{
    [Authorize(Policy = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IViewModelService _viewModelService;

        public IndexModel(IViewModelService ViewModelService)
        {
            _viewModelService = ViewModelService;
        }
        public required IndexViewModel FleetModel { get; set; } = new IndexViewModel();

        public async Task OnGet(IndexViewModel fleetModel)
        {
            FleetModel = await _viewModelService.GetIndexViewModel();
        }

        public async Task<RedirectToPageResult> OnPostDelete(int Id)
        {
            await _viewModelService.DeleteVehicle(Id);
            return RedirectToPage("./Index");
        }

        public Task<RedirectToPageResult> OnPostUpdate(int Id)
        {
            TempData["VehicleId"] = Id;
            return Task.FromResult(RedirectToPage("./Update"));
        }


        public Task<RedirectToPageResult> OnPostAdd()
        {
            return Task.FromResult(RedirectToPage("./Create"));
        }

        public Task<PartialViewResult> OnPostDetails(int Id)
        {
            return Task.FromResult(Partial("_vehicleDetails+" + Id));
        }
    }
}
