using ApplicationCore.Entities;

namespace Web.Interfaces.Admin.ManageFleet
{
    public interface IUpdateViewModelService
    {
        Task<Vehicle> GetVehicleByIdAsync(int Id);
    }
}
