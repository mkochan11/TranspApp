using ApplicationCore.Entities;

namespace Web.ViewModels.Admin.Manage.Fleet
{
    public class IndexViewModel
    {
        public List<ItemViewModel> Vehicles { get; set; } = new List<ItemViewModel>();
        public List<DetailedItemViewModel> DetailedVehicles { get; set; } = new List<DetailedItemViewModel>();
        public List<VehicleTypeViewModel> VehicleTypes { get; set; } = new List<VehicleTypeViewModel>();
    }
}
