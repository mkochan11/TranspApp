using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Validation.Errors;
using ApplicationCore.Validation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {

        private readonly IRepository<VehicleType> _vehicleTypeRepository;

        public VehicleTypeService(IRepository<VehicleType> vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }
        public async Task<ValidationResult> CreateAsync(VehicleType type)
        {
            var checkVehicleTypeResult = await CheckVehicleTypeAsync(type);
            if (checkVehicleTypeResult.Succeeded)
            {
                await _vehicleTypeRepository.AddAsync(type);
                return ValidationResult.Success;
            }
            else
            {
                return ValidationResult.Failed(checkVehicleTypeResult.Errors.ToArray());
            }
        }

        public async Task<ValidationResult> UpdateAsync(VehicleType type)
        {
            var checkVehicleTypeResult = await CheckVehicleTypeAsync(type);
            if (checkVehicleTypeResult.Succeeded)
            {
                await _vehicleTypeRepository.UpdateAsync(type);
                return ValidationResult.Success;
            }
            else
            {
                return ValidationResult.Failed(checkVehicleTypeResult.Errors.ToArray());
            }
        }

        private async Task<ValidationResult> CheckVehicleTypeAsync(VehicleType vehicleType)
        {
            var vehicleTypes = await _vehicleTypeRepository.ListAsync();
            bool typeExists = false;
            foreach (var type in vehicleTypes)
            {
                if (type.Type == vehicleType.Type)
                {
                    if(type == vehicleType)
                    {
                        typeExists = false;
                    }
                    else
                    {
                        typeExists = true;
                        break;
                    }
                    
                }
            }
            if (typeExists)
            {
                var error = new ValidationError
                {
                    Code = "vehicle_type_already_exists",
                    Description = "Vehicle type already exists."
                };

                var errors = new List<ValidationError> { error };
                return ValidationResult.Failed(errors.ToArray());
            }
            return ValidationResult.Success;
        }
    }
}
