using System;

namespace Onlineshop.Domains.Sales.SalesModel
{
    public class ShoppingCart
    {
        public Guid CartKey { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ExpiryDateTime { get; set; }
        public bool IsPayed { get; set; }
    }
}
