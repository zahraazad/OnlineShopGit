using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Facade.Models
{
    public class OrderResponse
    {
        public Guid CartKey { get; set; }
        public Order Order { get; set; }
    }
}
