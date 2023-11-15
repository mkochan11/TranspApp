using ApplicationCore.Entities.EmployeeAggregate;
using Web.ViewModels.Admin.Manage.Employees;

namespace Web.Interfaces.Admin.Manage.Employees
{
    public interface IEmployeeDetailsViewModelService
    {
        Task<EmployeeDetailsViewModel> GetViewModel(int employeeId);
        Task<Employee> GetEmployee(int employeeId);
    }
}
