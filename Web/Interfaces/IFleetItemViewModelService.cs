using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IFleetItemViewModelService
    {
        Task UpdateFleetItem(FleetItemViewModel viewModel);
    }
}
