using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations;
using Web.Interfaces;
using Web.ViewModels;
using Ardalis.Specification;
using Ardalis.GuardClauses;

namespace Web.Services
{
    public class FleetItemViewModelService : IFleetItemViewModelService
    {
        private readonly IRepository<Vehicle> _fleetItemRepository;

        public FleetItemViewModelService(IRepository<Vehicle> fleetItemRepository)
        {
            _fleetItemRepository = fleetItemRepository;
        }

        public async Task UpdateFleetItem(FleetItemViewModel viewModel)
        {
            //var existingFleetItem = await _fleetItemRepository.GetByIdAsync(viewModel.Id);

            //Guard.Against.Null(existingFleetItem, nameof(existingFleetItem));
        }
    }
}
