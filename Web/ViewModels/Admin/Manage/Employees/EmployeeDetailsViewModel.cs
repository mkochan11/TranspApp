namespace Web.ViewModels.Admin.Manage.Employees
{
    public class EmployeeDetailsViewModel
    {
        public DetailedEmployeeViewModel Employee { get; set; } = new DetailedEmployeeViewModel();
        public List<EmployeeActivityViewModel> Activities { get; set; } = new List<EmployeeActivityViewModel>();
        public List<EmployeeContractViewModel> Contracts { get; set; } = new List<EmployeeContractViewModel>();
    }
}
