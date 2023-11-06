using ApplicationCore.Entities.VehicleAggregate;

namespace Web.Interfaces.Admin.Manage.Fleet
{
    public interface IUpdateViewModelService
    {
        Task<Vehicle> GetVehicleByIdAsync(int Id);
    }
}
