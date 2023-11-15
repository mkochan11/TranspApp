using ApplicationCore.Entities.VehicleAggregate;

namespace Web.Interfaces.Admin.Manage.Fleet
{
    public interface IFleetUpdateViewModelService
    {
        Task<Vehicle> GetVehicleByIdAsync(int Id);
    }
}
