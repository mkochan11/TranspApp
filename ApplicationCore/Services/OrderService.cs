using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Interfaces;
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
                await _orderRepository.DeleteAsync(order);
                return order;
            }
            return null;
        }
    }
}
