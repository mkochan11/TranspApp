namespace Web.ViewModels.Admin.Manage.Employees
{
    public class EmployeeContractViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public float Salary { get; set; }
        public  bool IsActive { get; set; }
    }
}
