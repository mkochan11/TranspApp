using Web.ViewModels.User;

namespace Web.Interfaces.User
{
    public interface IMyOrdersViewModelService
    {
        Task<MyOrdersIndexViewModel> GetMyOrdersItems(string UserName);
    }
}
