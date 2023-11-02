using Web.ViewModels.Admin.Manage.Pricing;
namespace Web.Interfaces.Admin.Manage.Pricing
{
    public interface IViewModelService
    {
        Task<IndexViewModel> GetIndexViewModel();
    }
}
