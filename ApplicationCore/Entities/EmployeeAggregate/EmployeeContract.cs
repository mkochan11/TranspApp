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
        public float Salary { get; set; }

        public bool IsActive()
        {
            if(this.StartDate < DateTime.Now && (this.EndDate >= DateTime.Now || this.EndDate is null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public EmployeeContract(){}
    }
}
