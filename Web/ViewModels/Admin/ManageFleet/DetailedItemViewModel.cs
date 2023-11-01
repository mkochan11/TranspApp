﻿using ApplicationCore.Entities;

namespace Web.ViewModels.Admin.ManageFleet
{
    public class DetailedItemViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int ProductionYear { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public VehicleType VehicleType { get; set; }
        public int Capacity { get; set; }
    }
}
