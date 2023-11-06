using ApplicationCore.Entities.VehicleAggregate;

namespace Web.ViewModels.User
{
    public class FleetItemViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int ProductionYear { get; set; }
        public int Capacity { get; set; }
        public VehicleType VehicleType { get; set; }
        //public string PictureUri { get; set; }
    }
}
