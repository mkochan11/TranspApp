using ApplicationCore.Entities.EmployeeAggregate;

namespace Web.ViewModels.Admin.Manage.Employees
{
    public class DetailedEmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string DriverLicense { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
