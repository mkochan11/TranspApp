using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Order
{
    public class OrderConfirmationModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost() {
            return RedirectToPage("./MyOrders");
        }

    }
}
