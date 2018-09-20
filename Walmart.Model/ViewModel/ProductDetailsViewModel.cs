using System;
using System.Collections.Generic;
using System.Text;

namespace WalmartLabs.Model.ViewModel
{
    public class ProductDetailsViewModel: ApiResponse
    {
        public IEnumerable<ProductDetails> ProductDetailsList { get; set; }
    }
}
