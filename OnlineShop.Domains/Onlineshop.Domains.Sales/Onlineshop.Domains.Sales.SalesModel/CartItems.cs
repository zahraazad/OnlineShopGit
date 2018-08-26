using System;

namespace Onlineshop.Domains.Sales.SalesModel
{
    public class CartItem
    {
        public Guid CartKey { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public decimal ProductPrice { get; set; }

    }
}
