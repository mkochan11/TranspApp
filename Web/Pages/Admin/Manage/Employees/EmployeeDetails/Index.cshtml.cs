using ApplicationCore.Entities.EmployeeAggregate;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Interfaces.Admin.Manage.Employees;
using Web.ViewModels.Admin.Manage.Employees;

namespace Web.Pages.Admin.Manage.Employees
{
    [Authorize(Policy = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeDetailsViewModelService _viewModelService;
        private readonly IEmployeeContractService _employeeContractService;

        public DetailsModel(IEmployeeDetailsViewModelService viewModelService, IEmployeeContractService employeeContractService)
        {
            _viewModelService = viewModelService;
            _employeeContractService = employeeContractService;
        }


        public static int EmployeeId {  get; set; }
        public EmployeeDetailsViewModel ViewModel {  get; set; } = new EmployeeDetailsViewModel();

        
        public async Task OnGet(int id)
        {
            EmployeeId = id;
            ViewModel = await _viewModelService.GetViewModel(EmployeeId);
        }

        public async Task<IActionResult> OnPostTerminateContract(int id, int employeeId)
        {
            var res = await _employeeContractService.TerminateContract(id);
            if (res.IsSuccess)
            {
                return RedirectToPage("./Index", new { id=employeeId });
            }
            else
            {
                return RedirectToPagePermanent("/Error");
            }
        }

        public async Task<IActionResult> OnPostRenewContract(int id, int employeeId)
        {
            var res = await _employeeContractService.RenewContract(id);
            if (res.IsSuccess)
            {
                return RedirectToPage("./Index", new { id=employeeId });

            }
            else
            {
                return RedirectToPage("/Error");
            }
        }

        public async Task<IActionResult> OnPostDeleteContract(int id, int employeeId)
        {
            var res = await _employeeContractService.DeleteContract(id);
            if (res.IsSuccess)
            {
                return RedirectToPage("./Index", new { id = employeeId });

            }
            else
            {
                return RedirectToPage("/Error");
            }
        }

        public async Task<IActionResult> OnPostAddContract(int employeeId, DateTime startDate, DateTime endDate, float salary)
        {
            var res = await _employeeContractService.CreateContract(employeeId, startDate, endDate, salary);
            if (res.IsSuccess)
            {
                return RedirectToPage("./Index", new { id = employeeId });
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }

        public async Task<IActionResult> OnPostEditContract(int id, int employeeId, DateTime startDate, DateTime endDate, float salary)
        {
            var res = await _employeeContractService.UpdateContract(id, employeeId, startDate, endDate, salary);
            if (res.IsSuccess)
            {
                return RedirectToPage("./Index", new { id = employeeId });
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }

        public async Task<IActionResult> OnPostActivateContract(int id, int employeeId)
        {
            var res = await _employeeContractService.ActivateContract(id);
            if (res.IsSuccess)
            {
                return RedirectToPage("./Index", new { id = employeeId });
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
