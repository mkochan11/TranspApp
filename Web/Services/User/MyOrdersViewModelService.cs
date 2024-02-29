using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Entities.VehicleAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications.Employee;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Interfaces.User;
using Web.ViewModels.User;

namespace Web.Services.User
{
    public class MyOrdersViewModelService : IMyOrdersViewModelService
    {
        private readonly IRepository<Order> _ordersRepository;
        private readonly IRepository<Address> _addressesRepository;
        private readonly IRepository<Vehicle> _vehiclesRepository;

        public MyOrdersViewModelService(IRepository<Order> ordersRepository, IRepository<Address> addressesRepository, IRepository<Vehicle> vehiclesRepository)
        {
            _ordersRepository = ordersRepository;
            _addressesRepository = addressesRepository;
            _vehiclesRepository = vehiclesRepository;
        }

        public async Task<MyOrdersIndexViewModel> GetMyOrdersItems(string UserName)
        {
            var _orderSpec = new FindOrderByUserName(UserName);
            var orders = await _ordersRepository.ListAsync(_orderSpec);

            var vm = new MyOrdersIndexViewModel()
            {
                Addresses = (await GetAddresses()).ToList(),

                Vehicles = (await GetVehicles()).ToList(),

                OrderItems = orders.Select(i => new MyOrdersItemViewModel
                {
                    Id = i.Id,
                    PlacementTime = i.PlacementTime,
                    ExecutionDate = i.ExecutionDate,
                    StartAddress = i.StartAddress,
                    EndAddress = i.EndAddress,
                    TotalCost = i.TotalCost,
                    OrderWeight = i.OrderWeight,
                    IsCompleted = i.IsCompleted,
                    IsConfirmed = i.IsConfirmed,
                    IsPaid = i.IsPaid,
                }).ToList(),

                OrdersDetails = orders.Select(i => new MyOrdersDetailedItemViewModel
                {
                    Id = i.Id,
                    Comments = i.Comments,
                    Vehicle = i.Vehicle,
                }).ToList(),
            };

            return vm;
            
        }

        private async Task<IEnumerable<SelectListItem>> GetAddresses()
        {
            var addresses = await _addressesRepository.ListAsync();

            var items = addresses
                .Select(address => new SelectListItem()
                {
                    Value = address.Id.ToString(),
                    Text = address.Country + ", " + address.City + ", " + address.Street + ", " + address.HouseNumber
                })
                .OrderBy(b => b.Value)
                .ToList();

            var allItem = new SelectListItem() { Value = null, Text = "All", Selected = true };
            items.Insert(0, allItem);

            return items;
        }

        private async Task<IEnumerable<SelectListItem>> GetVehicles()
        {
            var vehicles = await _vehiclesRepository.ListAsync();

            var items = vehicles
                .Select(vehicle => new SelectListItem()
                {
                    Value = vehicle.Id.ToString(),
                    Text = vehicle.Brand
                })
                .OrderBy(b => b.Value)
                .ToList();

            var allItem = new SelectListItem() { Value = null, Text = "All", Selected = true };
            items.Insert(0, allItem);

            return items;
        }
    }
}
