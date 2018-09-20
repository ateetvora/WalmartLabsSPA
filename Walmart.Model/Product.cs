using System;
using System.Collections.Generic;
using System.Text;

namespace WalmartLabs.Model
{
    public class Product
    {
        public long ItemId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal SalePrice { get; set; }
        public string ThumbnailImage { get; set; }
    }
}
