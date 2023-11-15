using ApplicationCore.Entities.EmployeeAggregate;
using ApplicationCore.Interfaces;
using Web.Interfaces.Admin.Manage.Employees;
using Web.ViewModels.Admin.Manage.Employees;

namespace Web.Services.Admin.Manage.Employees
{
    public class ManageEmployeesViewModelService : IManageEmployeesViewModelService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IEmployeeService _employeeService;

        public ManageEmployeesViewModelService(IRepository<Employee> employeeRepository, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }
        public async Task<IndexViewModel> GetEmployees()
        {
            var employees = await _employeeRepository.ListAsync();

            foreach (var employee in employees)
            {
                await _employeeService.UpdateEmployeeActivityStatus(employee.Id);
            }

            var vm = new IndexViewModel()
            {
                Employees = employees.Select(i => new IndexItemViewModel
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    EmailAddress = i.EmailAddress,
                    HasAccount = i.HasAccount,
                    IsActive = i.IsActive,
                }).ToList(),
            };

            return vm;
        }
    }
}
