using ApplicationCore.Entities;

namespace Web.ViewModels
{
    public class VehicleDetailsViewModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public int ProductionYear { get; set; }
        public int Capacity { get; set; }
        public VehicleType VehicleType { get; set; }

    }
}
