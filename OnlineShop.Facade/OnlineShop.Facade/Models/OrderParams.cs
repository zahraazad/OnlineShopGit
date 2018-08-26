using System;


namespace OnlineShop.Facade.Models
{
    public class OrderParams
    {
        public Guid CartKey { get; set; }
        public int BankCartKey { get; set; }
        public int SecurityKey { get; set; }
    }
}
