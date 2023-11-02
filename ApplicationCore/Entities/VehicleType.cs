using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("VehicleTypes")]
    public class VehicleType : BaseEntity, IAggregateRoot
    {
        public string Type { get; set; } = string.Empty;
        public float PricePer100km { get; set; }
        public VehicleType(string type, float pricePer100km)
        {
            Type = type;
            PricePer100km = pricePer100km;
        }

        public VehicleType() { }
    }
}
