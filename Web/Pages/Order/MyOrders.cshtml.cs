using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Interfaces.User;
using Web.ViewModels.User;

namespace Web.Pages.Order
{
    [Authorize(Policy = "User")]
    public class MyOrdersModel : PageModel
    {
        private readonly IMyOrdersViewModelService _viewModelService;
        private readonly IOrderService _orderService;

        public required MyOrdersIndexViewModel OrdersVM { get; set; } = new MyOrdersIndexViewModel();

        public MyOrdersModel(IMyOrdersViewModelService viewModelService, IOrderService orderService)
        {
            _viewModelService = viewModelService;
            _orderService = orderService;
        }

        public async Task OnGet()
        {
            string UserName = HttpContext.User.Identity.Name;
            OrdersVM = await _viewModelService.GetMyOrdersItems(UserName);
        }

        public async Task<IActionResult> OnPostCancel(int Id)
        {
            await _orderService.DeleteOrder(Id);
            return RedirectToPage("./MyOrders");
        }
    }
}
