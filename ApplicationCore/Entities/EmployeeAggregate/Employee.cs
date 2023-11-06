using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.EmployeeAggregate
{
    public class Employee : BaseEntity, IAggregateRoot
    {
        public Guid? EmployeeAccountId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string DriverLicense { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;

        private List<EmployeeContract> _employeeContracts = new List<EmployeeContract>();
        private List<EmployeeActivity> _employeeActivities = new List<EmployeeActivity>();
        public IEnumerable<EmployeeContract> EmployeeContracts => _employeeContracts.AsReadOnly();
        public IEnumerable<EmployeeActivity> EmployeeActivities => _employeeActivities.AsReadOnly();

    }
}
