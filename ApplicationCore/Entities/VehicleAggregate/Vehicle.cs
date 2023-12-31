﻿using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.VehicleAggregate
{
    [Table("Vehicles")]
    public class Vehicle : BaseEntity, IAggregateRoot
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int ProductionYear { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public int VehicleTypeId { get; set; }
        public VehicleType? VehicleType { get; set; }
        public int Capacity { get; set; }
        public string? PictureUri { get; set; }

        private List<VehicleActivity> _vehicleActivities = new List<VehicleActivity>();

        public IEnumerable<VehicleActivity> VehicleActivities => _vehicleActivities.AsReadOnly();

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
