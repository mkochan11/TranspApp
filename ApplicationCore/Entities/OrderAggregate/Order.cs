using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities.EmployeeAggregate;
using ApplicationCore.Entities.VehicleAggregate;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities.OrderAggregate
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public int? VehicleId { get; set; }
        public int? EmployeeId { get; set; }
        public int? VehicleTypeId { get; set; }
        public int? StartAddressId { get; set; }
        public int? EndAddressId { get; set; }
        public DateTime PlacementTime { get; set; }
        public DateTime ExecutionDate { get; set; }
        public float TotalCost { get; set; }
        public float OrderWeight { get; set; }
        public bool IsCompleted { get; set; }
        public string Comments { get; set; } = string.Empty;


        public Vehicle? Vehicle { get; set; }
        public Employee? Employee { get; set; }
        public VehicleType? VehicleType { get; set; }
        public Address? StartAddress { get; set; }
        public Address? EndAddress { get; set; }

        public Order() { }

        public Order(Guid userId, int startAddressId, int endAddressId, DateTime executionDate, float orderWeight)
        {
            UserId = userId;
            StartAddressId = startAddressId;
            EndAddressId = endAddressId;
            ExecutionDate = executionDate;
            OrderWeight = orderWeight;
            PlacementTime = DateTime.Now;
        }

    }
}
