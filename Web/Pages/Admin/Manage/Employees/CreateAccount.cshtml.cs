using ApplicationCore.Entities.VehicleAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Admin.Manage.Employees
{
    [Authorize(Policy = "Admin")]
    public class CreateAccountModel : PageModel
    {
        public static int EmployeeId;
        public void OnGet()
        {
            if (TempData.ContainsKey("EmployeeId") && TempData["EmployeeId"] is int Id)
            {
                EmployeeId = Id;
            }
        }
    }
}
