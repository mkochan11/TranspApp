using ApplicationCore.Entities;
using ApplicationCore.Validation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IVehicleTypeService
    {
        Task<ValidationResult> CreateAsync(VehicleType type);
        Task<ValidationResult> UpdateAsync(VehicleType type);
    }
}
