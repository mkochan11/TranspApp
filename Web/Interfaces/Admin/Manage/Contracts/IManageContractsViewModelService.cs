using Web.ViewModels.Admin.Manage.Contracts;

namespace Web.Interfaces.Admin.Manage.Contracts
{
    public interface IManageContractsViewModelService
    {
        Task<IndexViewModel> getViewModel();
    }
}
