using Web.ViewModels.Admin.Manage.Fleet;

namespace Web.Interfaces.Admin.Manage.Fleet
{
    public interface IManageFleetViewModelService
    {
        Task<IndexViewModel> GetIndexViewModel();
        Task DeleteVehicle(int Id);
    }
}
