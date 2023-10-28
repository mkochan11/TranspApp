using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IFleetViewModelService
    {
        Task<FleetIndexViewModel> GetFleetItems();
        Task<IEnumerable<SelectListItem>> GetVehicleTypes();
        Task<List<VehicleType>> GetVehicleTypesList();
        Task DeleteFleetItem(int Id);
    }
}
