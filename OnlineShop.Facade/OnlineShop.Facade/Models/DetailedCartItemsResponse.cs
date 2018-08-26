using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Facade.Models
{
    public class DetailedCartItemsResponse
    {
        public Guid CartKey { get; set; }
        public List<DetailedCartItems> Products { get; set; }
    }
}
