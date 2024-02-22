using ApplicationCore.Entities.OrderAggregate;

namespace Web.ViewModels.User
{
    public class MyOrdersItemViewModel
    {
        public int Id { get; set; }
        public DateTime PlacementTime { get; set; }
        public DateTime ExecutionDate { get; set; }
        public float TotalCost { get; set; }
        public float OrderWeight { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsPaid { get; set; }
        public Address StartAddress { get; set; }
        public Address EndAddress { get; set; }
    }
}
