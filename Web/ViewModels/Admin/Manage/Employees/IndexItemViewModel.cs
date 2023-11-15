namespace Web.ViewModels.Admin.Manage.Employees
{
    public class IndexItemViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool HasAccount { get; set; }
    }
}
