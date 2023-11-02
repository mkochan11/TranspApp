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
            var checkVehicleTypeResult = await CheckVehicleTypeAsync(type.Type);
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

        public Task<ValidationResult> UpdateAsync(VehicleType type)
        {
            throw new NotImplementedException();
        }

        private async Task<ValidationResult> CheckVehicleTypeAsync(string vehicleType)
        {
            var vehicleTypes = await _vehicleTypeRepository.ListAsync();
            bool typeExists = false;
            foreach (var type in vehicleTypes)
            {
                if (type.Type == vehicleType)
                {
                    typeExists = true;
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
