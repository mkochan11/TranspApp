using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IFleetViewModelService
    {
        Task<FleetIndexViewModel> GetFleetItems();
        Task<IEnumerable<SelectListItem>> GetVehicleTypes();
        Task DeleteFleetItem(int Id);
    }
}
