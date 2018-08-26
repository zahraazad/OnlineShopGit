using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Facade.Models
{
    public class CartItemsResponse
    {
        public Guid CartKey { get; set; }
        public List<CartItem> Products { get; set; }
    }
}
