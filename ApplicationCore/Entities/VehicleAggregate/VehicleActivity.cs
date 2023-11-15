using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.VehicleAggregate
{
    public class VehicleActivity : BaseEntity, IAggregateRoot
    {
        public int VehicleId { get; set; }
        public int? OrderId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public Vehicle Vehicle { get; set; }
        public Order? Order { get; set; }
    }
}
