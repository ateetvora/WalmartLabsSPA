using System;
using System.Collections.Generic;
using System.Text;

namespace WalmartLabs.Model
{
    public class ProductDetails: Product
    {
        public string BrandName { get; set; }
        public string ModelNumber { get; set; }
        public string CustomerRating { get; set; }
        public string MediumImage { get; set; }
        public string LargeImage { get; set; }
        public string Stock { get; set; }
        public bool IsTwoDayShippingEligible { get; set; }
        public bool AvailableOnline { get; set; }
    }
}
