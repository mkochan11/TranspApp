using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Interfaces.Admin.Manage.Contracts;
using Web.ViewModels.Admin.Manage.Contracts;

namespace Web.Pages.Admin.Manage.Contracts
{
    public class IndexModel : PageModel
    {
        private readonly IManageContractsViewModelService _viewModelService;
        public IndexModel(IManageContractsViewModelService viewModelService) {
            _viewModelService = viewModelService;
        } 

        public IndexViewModel ViewModel { get; set; } = new IndexViewModel();
        public async Task OnGet()
        {
            ViewModel = await _viewModelService.getViewModel();
        }

        public IActionResult OnGetEmployeeDetails(int id)
        {
            return RedirectToPage("/Admin/Manage/Employees/EmployeeDetails/Index", new { id });
        }
    }
}
