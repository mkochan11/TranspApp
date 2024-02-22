using ApplicationCore.Entities.OrderAggregate;
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

        public MyOrdersViewModelService(IRepository<Order> ordersRepository, IRepository<Address> addressesRepository)
        {
            _ordersRepository = ordersRepository;
            _addressesRepository = addressesRepository;
        }

        public async Task<MyOrdersIndexViewModel> GetMyOrdersItems(string UserName)
        {
            var _orderSpec = new FindOrderByUserName(UserName);
            var orders = await _ordersRepository.ListAsync(_orderSpec);

            var vm = new MyOrdersIndexViewModel()
            {
                Addresses = (await GetAddresses()).ToList(),

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
    }
}
