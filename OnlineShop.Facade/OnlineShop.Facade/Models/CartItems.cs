using System;

namespace OnlineShop.Facade.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
    }
}
