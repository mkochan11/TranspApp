using Web.ViewModels.Admin.Manage.Employees;

namespace Web.Interfaces.Admin.Manage.Employees
{
    public interface IManageEmployeesViewModelService
    {
        Task<IndexViewModel> GetEmployees();
    }
}
