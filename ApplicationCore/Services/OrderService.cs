using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> _orderRepository;
        IRepository<Address> _addressRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Address> addressRepository)
        {
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
        }

        public async Task<Address> CreateAddress(string country, string city, string postalCode, string street, string houseNumber)
        {
            Address Address = new Address(country, city, postalCode, street, houseNumber);
            await _addressRepository.AddAsync(Address);
            return Address;
        }

        public async Task<Order> CreateOrder(string username, int startAddressId, int destAddressId, float weight, DateTime date)
        {
            Order Order = new Order(username, startAddressId, destAddressId, date, weight);
            await _orderRepository.AddAsync(Order);
            return Order;
        }

        public async Task<bool> CheckIfOrderExists(int Id)
        {
            Order? order = await _orderRepository.GetByIdAsync(Id);
            return order == null ? false : true;
        }

        public async Task<Order?> DeleteOrder(int Id)
        {
            Order? order = await _orderRepository.GetByIdAsync(Id);
            if (order != null)
            {
                Address? startAddress = await _addressRepository.GetByIdAsync(order.StartAddressId);
                Address? endAddress = await _addressRepository.GetByIdAsync(order.EndAddressId);
                await _orderRepository.DeleteAsync(order);
                await _addressRepository.DeleteAsync(startAddress);
                await _addressRepository.DeleteAsync(endAddress);
                
                return order;
            }
            return null;
        }

        public async Task<int> CountTotalUnconfirmedOrderItems()
        {
            var _orderSpec = new FindUnconfirmedOrderItems();
            var orders = await _orderRepository.ListAsync(_orderSpec);

            return orders.Count;
        }
    }
}
