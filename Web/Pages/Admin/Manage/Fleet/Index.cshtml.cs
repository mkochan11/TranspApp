using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using Web.Interfaces;
using Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Web.Pages.Admin.Manage.Fleet
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IFleetViewModelService _fleetViewModelService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(IFleetViewModelService fleetViewModelService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _fleetViewModelService = fleetViewModelService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public required FleetIndexViewModel FleetModel { get; set; } = new FleetIndexViewModel();

        public async Task OnGet(FleetIndexViewModel fleetModel)
        {
            FleetModel = await _fleetViewModelService.GetFleetItems();
        }

        public async Task<RedirectToPageResult> OnPostDelete(int Id)
        {
            await _fleetViewModelService.DeleteFleetItem(Id);
            return RedirectToPage("./Index");
        }

        //Do implementacji
        public Task<RedirectToPageResult> OnPostEdit(int Id)
        {
            return Task.FromResult(RedirectToPage("./Index"));
        }

        public Task<RedirectToPageResult> OnPostAdd()
        {
            return Task.FromResult(RedirectToPage("./Create"));
        }
    }
}
