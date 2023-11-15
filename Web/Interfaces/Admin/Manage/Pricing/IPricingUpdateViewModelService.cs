using ApplicationCore.Entities.VehicleAggregate;

namespace Web.Interfaces.Admin.Manage.Pricing
{
    public interface IPricingUpdateViewModelService
    {
        Task<VehicleType> GetVehicleTypeByIdAsync(int id);
    }
}
