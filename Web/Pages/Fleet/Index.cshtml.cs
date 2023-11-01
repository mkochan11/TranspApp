
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Identity;
using Web.ViewModels.User;
using Web.Interfaces.User;

namespace Web.Pages.Fleet
{
    public class IndexModel : PageModel
    {
        private readonly IFleetViewModelService _fleetViewModelService;

        public IndexModel(IFleetViewModelService fleetViewModelService)
        {
            _fleetViewModelService = fleetViewModelService;
        }

        public required FleetIndexViewModel FleetModel { get; set; } = new FleetIndexViewModel();

        public async Task OnGet(FleetIndexViewModel fleetModel)
        {
            FleetModel = await _fleetViewModelService.GetFleetItems();
        }
    }
} 
