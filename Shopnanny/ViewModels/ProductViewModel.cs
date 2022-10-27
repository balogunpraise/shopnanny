
namespace Shopnanny.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProductImageUrl { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int MinOrderQuantity { get; set; }
        public int LowStockQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
