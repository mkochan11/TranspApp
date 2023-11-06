using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations;
using Web.ViewModels;
using Ardalis.Specification;
using Ardalis.GuardClauses;
using Web.Interfaces.User;
using ApplicationCore.Entities.VehicleAggregate;

namespace Web.Services.User
{
    public class FleetItemViewModelService : IFleetItemViewModelService
    {
        private readonly IRepository<Vehicle> _fleetItemRepository;

        public FleetItemViewModelService(IRepository<Vehicle> fleetItemRepository)
        {
            _fleetItemRepository = fleetItemRepository;
        }
    }
}
