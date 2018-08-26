using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Facade.Models
{
    public class CartItemParams
    {
        public Guid CartKey { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
