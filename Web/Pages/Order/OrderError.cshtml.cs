using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Order
{
    public class OrderErrorModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost() {
            return RedirectToPage("./Index");
        }

    }
}
