using ApplicationCore.Entities;
using ApplicationCore.Validation.Results;

namespace ApplicationCore.Interfaces
{
    public interface IVehicleService
    {
        Task<ValidationResult> CreateAsync(Vehicle vehicle, string vehicleType);
        Task<ValidationResult> UpdateAsync(Vehicle vehicle, string vehicleType);

    }
}
