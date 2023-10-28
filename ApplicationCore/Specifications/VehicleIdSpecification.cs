using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
    public class VehicleIdSpecification : Specification<Vehicle>, ISingleResultSpecification<Vehicle>

    {
        public VehicleIdSpecification()
        { }
        
    }
}
