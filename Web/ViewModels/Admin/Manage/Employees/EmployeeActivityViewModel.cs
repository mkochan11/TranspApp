namespace Web.ViewModels.Admin.Manage.Employees
{
    public class EmployeeActivityViewModel
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
