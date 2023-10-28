using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Vehicles")]
    public class Vehicle : BaseEntity, IAggregateRoot
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string RegistrationNumber { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType? VehicleType { get; set; }
        public int Capacity { get; set; }
        public string? PictureUri { get; set; }

        public Vehicle(int vehicleTypeId,
            string brand,
            string model,
            int productionYear,
            string registrationNumber,
            int capacity
            //string pictureUri
            )
        {
            VehicleTypeId = vehicleTypeId;
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            RegistrationNumber = registrationNumber;
            Capacity = capacity;
            //PictureUri = pictureUri;
        }

        public Vehicle() { }


    }
}
