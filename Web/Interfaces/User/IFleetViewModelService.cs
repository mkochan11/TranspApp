using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ViewModels.User;

namespace Web.Interfaces.User
{
    public interface IFleetViewModelService
    {
        Task<FleetIndexViewModel> GetFleetItems();
        Task<IEnumerable<SelectListItem>> GetVehicleTypes();
    }
}
