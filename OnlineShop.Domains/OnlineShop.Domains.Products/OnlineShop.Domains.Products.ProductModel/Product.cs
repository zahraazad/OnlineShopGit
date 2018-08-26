
namespace OnlineShop.Domains.Products.ProductModel
{
    public class Product
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityOnHand { get; set; }
        public string ImagePath { get; set; }
    }
}
