using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WalmartLabs.Model;
using WalmartLabs.Model.ViewModel;
using WalmartLabs.Service.Abstract;

namespace WalmartLabs.Service.Concrete
{
    public class ProductService : IProductService
    {
        protected AppSettings AppSettings { get; set; }

        public ProductService(IOptions<AppSettings> settings)
        {
            AppSettings = settings.Value;
        }

        /// <summary>
        /// Search for products based on the search criteria text
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns></returns>
        public async Task<ProductsViewModel> SearchProducts(string searchCriteria)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri(
                    $"http://api.walmartlabs.com/v1/search?apiKey={AppSettings.APIKey}&query={searchCriteria}&numItems=25&format=json");
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new ProductsViewModel()
                    {
                        StatusCode = (int) response.StatusCode,
                        Message = GetDefaultMessageForStatusCode((int) response.StatusCode)
                    };
                }

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(json))
                    {
                        var responseDoc = JToken.Parse(json);
                        if (responseDoc["totalResults"] != null && int.Parse(responseDoc["totalResults"].ToString()) > 0)
                        {
                            json = responseDoc["items"].ToString();
                        }
                        else
                        {
                            return new ProductsViewModel() { Products = new List<Product>() };
                        }
                    }
                }

                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                return new ProductsViewModel()
                {
                    Products = products
                };
            }
        }

        /// <summary>
        /// Get product details 
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        public async Task<ProductDetailsViewModel> GetProductDetails(string productIds)
        {
            //var input = string.Join(",", productIds);
            using (var client = new HttpClient())
            {
                var url = new Uri(
                    $"http://api.walmartlabs.com/v1/items?apiKey={AppSettings.APIKey}&itemId={productIds}&format=json");
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new ProductDetailsViewModel()
                    {
                        StatusCode = (int)response.StatusCode,
                        Message = GetDefaultMessageForStatusCode((int)response.StatusCode)
                    };
                }

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(json))
                    {
                        var responseDoc = JToken.Parse(json);
                        json = responseDoc["items"].ToString();
                    }
                }

                var details = JsonConvert.DeserializeObject<IEnumerable<ProductDetails>>(json);
                return new ProductDetailsViewModel() {ProductDetailsList = details};
            }
        }

        /// <summary>
        /// Get product recommendations
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<ProductsViewModel> GetRecommendations(int productId)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri(
                    $"http://api.walmartlabs.com/v1/nbp?apiKey={AppSettings.APIKey}&itemId={productId}&format=json");
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new ProductsViewModel()
                    {
                        StatusCode = (int)response.StatusCode,
                        Message = GetDefaultMessageForStatusCode((int)response.StatusCode)
                    };
                }

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                if (json.Contains("error"))
                {
                    return new ProductsViewModel { Products = new List<Product>() };
                }

                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                return new ProductsViewModel{Products = products};
            }
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return "Bad Request";
                case 401:
                    return "Unauthorized";
                case 403:
                    return "Forbidden";
                case 404:
                    return "Not Found";
                case 500:
                    return "Internal Server";
                case 501:
                    return "Not Implemented";
                case 502:
                    return "Bad Gateway";
                default:
                    return "Error";
            }
        }
    }
}
