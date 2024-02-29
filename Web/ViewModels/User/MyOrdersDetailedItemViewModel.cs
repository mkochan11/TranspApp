using ApplicationCore.Entities.VehicleAggregate;

namespace Web.ViewModels.User
{
    public class MyOrdersDetailedItemViewModel
    {
        public int Id { get; set; }
        public string Comments { get; set; } = string.Empty;
        public Vehicle? Vehicle { get; set; }
    }
}
