namespace Web.ViewModels.Admin.Manage.Pricing
{
    public class ItemViewModel
    {   
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public float PricePer100km { get; set; }
    }
}
