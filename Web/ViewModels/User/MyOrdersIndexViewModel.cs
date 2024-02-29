using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewModels.User
{
    public class MyOrdersIndexViewModel
    {
        public List<MyOrdersItemViewModel> OrderItems { get; set; } = new List<MyOrdersItemViewModel>();
        public List<SelectListItem>? Addresses { get; set; } = new List<SelectListItem>();
        public List<SelectListItem>? Vehicles { get; set; } = new List<SelectListItem>();
        public List<MyOrdersDetailedItemViewModel> OrdersDetails { get; set; } = new List<MyOrdersDetailedItemViewModel>();
    }
}
