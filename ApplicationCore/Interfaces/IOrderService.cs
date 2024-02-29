
using ApplicationCore.Entities.OrderAggregate;
using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task<Address> CreateAddress(string country, string city, string postalCode, string street, string houseNumber);
        Task<Order> CreateOrder(string username, int startAddressId, int destAddressId, float weight, DateTime date);
        Task<bool> CheckIfOrderExists(int Id);
    }
}
