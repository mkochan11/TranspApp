using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewModels
{
    public class FleetIndexViewModel
    {
        public List<FleetItemViewModel> FleetItems { get; set; }
        public List<SelectListItem>? Types { get; set; } = new List<SelectListItem>();
    }
}
