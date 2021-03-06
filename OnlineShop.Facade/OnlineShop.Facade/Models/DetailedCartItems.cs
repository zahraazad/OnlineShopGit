﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Facade.Models
{
    public class DetailedCartItems
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImagePath { get; set; }
        public int ProductCount { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
