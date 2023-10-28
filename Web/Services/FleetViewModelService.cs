﻿
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class FleetViewModelService : IFleetViewModelService
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<VehicleType> _vehicleTypeRepository;

        public FleetViewModelService(IRepository<Vehicle> vehicleRepository, IRepository<VehicleType> vehicleTypeRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        public async Task<FleetIndexViewModel> GetFleetItems()
        {
            var vehiclesOnPage = await _vehicleRepository.ListAsync();

            var vm = new FleetIndexViewModel()
            {
                Types = (await GetVehicleTypes()).ToList(),

                FleetItems = vehiclesOnPage.Select(i => new FleetItemViewModel
                {
                    Id = i.Id,
                    Model = i.Model,
                    Brand = i.Brand,
                    ProductionYear = i.ProductionYear,
                    Capacity = i.Capacity,
                    VehicleType = i.VehicleType
                }).ToList(),

            };
            return vm;
        }

        public async Task<IEnumerable<SelectListItem>> GetVehicleTypes()
        {
            var vehicleTypes = await _vehicleTypeRepository.ListAsync();

            var items = vehicleTypes
                .Select(type => new SelectListItem() { Value = type.Id.ToString(), Text = type.Type })
                .OrderBy(b => b.Value)
                .ToList();

            var allItem = new SelectListItem() {  Value = null, Text = "All", Selected = true };
            items.Insert(0, allItem);

            return items;
        }

        public async Task DeleteFleetItem(int Id)
        {
            Vehicle? vehicle = await _vehicleRepository.GetByIdAsync(Id);
            if (vehicle != null)
            {
                await _vehicleRepository.DeleteAsync(vehicle);
            }
        }

        public async Task<List<VehicleType>> GetVehicleTypesList()
        {
            var vehicleTypes = await _vehicleTypeRepository.ListAsync();
            return vehicleTypes;
        }
    }
}
