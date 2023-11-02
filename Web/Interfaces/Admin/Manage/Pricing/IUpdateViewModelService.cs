using ApplicationCore.Entities;

namespace Web.Interfaces.Admin.Manage.Pricing
{
    public interface IUpdateViewModelService
    {
        Task<VehicleType> GetVehicleTypeByIdAsync(int id);
    }
}
