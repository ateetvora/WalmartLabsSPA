using System;
using System.Collections.Generic;
using System.Text;

namespace WalmartLabs.Model.ViewModel
{
    public class ProductsViewModel: ApiResponse
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
