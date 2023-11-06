using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.EmployeeAggregate
{
    public class EmployeeActivity : BaseEntity, IAggregateRoot
    {
        public int EmployeeId { get; set; }
        public int OrderId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public Employee Employee { get; set; }
        public Order Order { get; set; }
    }
}
