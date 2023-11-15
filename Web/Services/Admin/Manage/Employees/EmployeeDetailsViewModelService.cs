using ApplicationCore.Entities.EmployeeAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications.Employee;
using System.Runtime.CompilerServices;
using Web.Interfaces.Admin.Manage.Employees;
using Web.ViewModels.Admin.Manage.Employees;

namespace Web.Services.Admin.Manage.Employees
{
    public class EmployeeDetailsViewModelService : IEmployeeDetailsViewModelService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeActivity> _employeeActivityRepository;
        private readonly IRepository<EmployeeContract> _employeeContractRepository;


        public EmployeeDetailsViewModelService(IRepository<Employee> employeeRepository, IRepository<EmployeeActivity> employeeActivityRepository, IRepository<EmployeeContract> employeeContractRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeActivityRepository = employeeActivityRepository;
            _employeeContractRepository = employeeContractRepository;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
            {
                throw new NullReferenceException(nameof(employee));
            }
            return employee;

        }

        public async Task<EmployeeDetailsViewModel> GetViewModel(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);

            var _activitySpec = new EmployeeActivityFind(employeeId);
            var activities = await _employeeActivityRepository.ListAsync(_activitySpec);

            var _contractSpec = new EmployeeContractFind(employeeId);
            var contracts = await _employeeContractRepository.ListAsync(_contractSpec);


            var vm = new EmployeeDetailsViewModel()
            {
                Employee = new DetailedEmployeeViewModel
                {
                    Id = employeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    EmailAddress = employee.EmailAddress,
                    DriverLicense = employee.DriverLicense,
                    PhoneNumber = employee.PhoneNumber,
                },

                Activities = activities.Select(i => new EmployeeActivityViewModel
                {
                    Id = i.Id,
                    OrderId = i.OrderId,
                    StartTime = i.StartTime,
                    EndTime = i.EndTime,

                }).ToList(),

                Contracts = contracts.Select(i => new EmployeeContractViewModel
                {
                    EmployeeId = i.EmployeeId,
                    Id = i.Id,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate,
                    Salary = i.Salary,
                    IsActive = i.IsActive(),
                }).ToList(),

            };

            return vm;
        }
    }
}
