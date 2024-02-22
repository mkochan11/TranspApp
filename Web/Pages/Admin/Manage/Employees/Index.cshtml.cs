using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Interfaces.Admin.Manage.Employees;
using Web.ViewModels.Admin.Manage.Employees;

namespace Web.Pages.Admin.Manage.Employees
{
    [Authorize(Policy = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IManageEmployeesViewModelService _viewModelService;

        public IndexModel(IManageEmployeesViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }
        public required IndexViewModel EmployeesModel { get; set; } = new IndexViewModel();
        public async Task OnGet()
        {
            EmployeesModel = await _viewModelService.GetEmployees();
        }

        public RedirectToPageResult OnGetCreateAccount(int id)
        {
            return RedirectToPage("./CreateAccount", new { id});
        }

        public RedirectToPageResult OnGetDetails(int id)
        {
            return RedirectToPage("./EmployeeDetails/Index", new { id });
        }
    }
}
