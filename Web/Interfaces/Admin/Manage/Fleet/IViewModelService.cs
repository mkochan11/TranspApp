using Web.ViewModels.Admin.Manage.Fleet;

namespace Web.Interfaces.Admin.Manage.Fleet
{
    public interface IViewModelService
    {
        Task<IndexViewModel> GetIndexViewModel();
        Task DeleteVehicle(int Id);
    }
}
