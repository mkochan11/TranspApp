using ApplicationCore.Entities;

namespace Web.Interfaces.Admin.Manage.Fleet
{
    public interface IUpdateViewModelService
    {
        Task<Vehicle> GetVehicleByIdAsync(int Id);
    }
}
