using ApplicationCore.Interfaces;
using ApplicationCore.Validation.Results;
using ApplicationCore.Validation.Errors;
using ApplicationCore.Entities.VehicleAggregate;

namespace ApplicationCore.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<VehicleType> _vehicleTypeRepository;

        public VehicleService(IRepository<Vehicle> vehicleRepository, IRepository<VehicleType> vehicleTypeRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleTypeRepository = vehicleTypeRepository;
        }
        public async Task<ValidationResult> CreateAsync(Vehicle vehicle, string vehicleType)
        {
            var checkRegistrationNumberResult = await CheckRegistrationNumberAsync(vehicle.RegistrationNumber, vehicle);
            var checkVehicleTypeResult = await CheckVehicleTypeAsync(vehicleType);

            if (checkVehicleTypeResult.Succeeded)
            {
                vehicle.VehicleTypeId = await FindVehicleTypeID(vehicleType);
                if(checkRegistrationNumberResult.Succeeded)
                {
                    await _vehicleRepository.AddAsync(vehicle);
                    return ValidationResult.Success;
                }
                return ValidationResult.Failed(checkRegistrationNumberResult.Errors.ToArray());
            }
            else if (checkRegistrationNumberResult.Succeeded)
            {
                return ValidationResult.Failed(checkVehicleTypeResult.Errors.ToArray());
            }
            else
            {
                var errors = new List<ValidationError> { checkRegistrationNumberResult.Errors.First(), checkVehicleTypeResult.Errors.First() };
                return ValidationResult.Failed(errors.ToArray());
            }

        }

        public async Task<ValidationResult> UpdateAsync(Vehicle vehicle, string vehicleType)
        {
            var checkRegistrationNumberResult = await CheckRegistrationNumberAsync(vehicle.RegistrationNumber, vehicle);
            var checkVehicleTypeResult = await CheckVehicleTypeAsync(vehicleType);

            if (checkVehicleTypeResult.Succeeded)
            {
                vehicle.VehicleTypeId = await FindVehicleTypeID(vehicleType);
                if (checkRegistrationNumberResult.Succeeded)
                {
                    await _vehicleRepository.UpdateAsync(vehicle);
                    return ValidationResult.Success;
                }
                return ValidationResult.Failed(checkRegistrationNumberResult.Errors.ToArray());
            }
            else if (checkRegistrationNumberResult.Succeeded)
            {
                return ValidationResult.Failed(checkVehicleTypeResult.Errors.ToArray());
            }
            else
            {
                var errors = new List<ValidationError> { checkRegistrationNumberResult.Errors.First(), checkVehicleTypeResult.Errors.First() };
                return ValidationResult.Failed(errors.ToArray());
            }
        }

        private async Task<ValidationResult> CheckRegistrationNumberAsync(string registrationNumber, Vehicle Vehicle)
        {
            var vehicles = await _vehicleRepository.ListAsync();
            bool numberExists = false;
            foreach (var dbVehicle in vehicles)
            {
                if(dbVehicle.RegistrationNumber == registrationNumber)
                {
                    if(dbVehicle == Vehicle) { 
                        numberExists = false;
                    }
                    else
                    {
                        numberExists = true; break;
                    }
                }
            }
            if (numberExists)
            {
                var error = new ValidationError
                {
                    Code = "registration_number_exists",
                    Description = "Registration number already exists in database."
                };
                
                var errors = new List<ValidationError> { error };
                return ValidationResult.Failed(errors.ToArray());
            }
            return ValidationResult.Success;
        }

        private async Task<ValidationResult> CheckVehicleTypeAsync(string vehicleType)
        {
            var vehicleTypes = await _vehicleTypeRepository.ListAsync();
            bool typeExists = false;
            foreach (var vehicle in vehicleTypes)
            {
                if (vehicle.Type == vehicleType)
                {
                    typeExists = true;
                }
            }
            if (!typeExists)
            {
                var error = new ValidationError
                {
                    Code = "vehicle_type_non_existent",
                    Description = "Vehicle type not found."
                };

                var errors = new List<ValidationError> { error };
                return ValidationResult.Failed(errors.ToArray());
            }
            return ValidationResult.Success;
        }

        private async Task<int> FindVehicleTypeID(string type)
        {
            var vehicleTypes = await _vehicleTypeRepository.ListAsync();
            foreach (var vehicleType in vehicleTypes)
            {
                if (type == vehicleType.Type) return vehicleType.Id;
            }
            return 0;
        }
    }
}
