using Web.ViewModels.Admin.ManageFleet;
namespace Web.Interfaces.Admin.ManageFleet
{
    public interface IViewModelService
    {
        Task<IndexViewModel> GetIndexViewModel();
        Task DeleteVehicle(int Id);
    }
}
