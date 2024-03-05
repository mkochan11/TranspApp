using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.Admin;

namespace Web.Pages.Shared.Components.OrdersComponent
{
    public class Orders : ViewComponent
    {
        private readonly IOrderService _orderService;

        public Orders(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new AdminHeaderNewOrdersViewModel
            {
                ItemsCount = await CountTotalNewOrderItems()
            };
            return View(vm);
        }

        private async Task<int> CountTotalNewOrderItems()
        {
            return await _orderService.CountTotalUnconfirmedOrderItems();
        }
    }
}
