using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.EmployeeAggregate
{
    public class EmployeeContract : BaseEntity, IAggregateRoot
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Salary { get; set; }

        public EmployeeContract(){}
    }
}
