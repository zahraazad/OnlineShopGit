using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Facade.Models
{
    public class AddProductParams
    {
        public int GroupId { get; set; }
        //public ProductGroup Group { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityOnHand { get; set; }
        public string ImagePath { get; set; }
    }
}
