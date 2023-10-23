using ApplicationCore.Entities;

namespace Web.ViewModels
{
    public class FleetItemViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public int Capacity { get; set; }
        public VehicleType VehicleType { get; set; }
        //public string PictureUri { get; set; }
    }
}
