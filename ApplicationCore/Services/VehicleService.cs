using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.Data.SqlClient;

namespace ApplicationCore.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IRepository<Vehicle> _vehicleRepository;

        public VehicleService(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            /*
            Guard.Against.NullOrEmpty(vehicle.Brand, nameof(vehicle.Brand));
            Guard.Against.NullOrEmpty(vehicle.Model, nameof(vehicle.Model));
            Guard.Against.OutOfRange(vehicle.ProductionYear, nameof(vehicle.ProductionYear), 1900, 2023);
            Guard.Against.OutOfRange(vehicle.Capacity, nameof(vehicle.Capacity), 0, 100000);
            Guard.Against.NullOrEmpty(vehicle.RegistrationNumber, nameof(vehicle.RegistrationNumber));
            Guard.Against.Null(vehicle.VehicleTypeId, nameof(vehicle.VehicleTypeId));
            */
            await _vehicleRepository.AddAsync(vehicle);
        }
    }
}
