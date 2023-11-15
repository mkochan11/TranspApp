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
        public bool IsActive { get; set; }
        public bool HasAccount { get; set; }


        private List<EmployeeContract> _employeeContracts = new List<EmployeeContract>();
        private List<EmployeeActivity> _employeeActivities = new List<EmployeeActivity>();
        public List<EmployeeContract> EmployeeContracts => _employeeContracts;
        public List<EmployeeActivity> EmployeeActivities => _employeeActivities;

        public Employee(string firstName, string lastName, string emailAddress, string driverLicense, string phoneNumber, bool isActive, bool hasAccount)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.DriverLicense = driverLicense;
            this.PhoneNumber = phoneNumber;
            IsActive = IsActive;
            HasAccount = hasAccount;
        }
    }
}
