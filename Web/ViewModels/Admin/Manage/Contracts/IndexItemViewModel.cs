using ApplicationCore.Entities.EmployeeAggregate;

namespace Web.ViewModels.Admin.Manage.Contracts
{
    public class IndexItemViewModel
    {
        public int Id { get; set; } 
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
