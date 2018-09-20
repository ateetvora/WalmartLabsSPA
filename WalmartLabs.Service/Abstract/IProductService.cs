using System.Collections.Generic;
using System.Threading.Tasks;
using WalmartLabs.Model;
using WalmartLabs.Model.ViewModel;

namespace WalmartLabs.Service.Abstract
{
    public interface IProductService
    {
        Task<ProductsViewModel> SearchProducts(string searchCriteria);
        Task<ProductDetailsViewModel> GetProductDetails(string productIds);
        Task<ProductsViewModel> GetRecommendations(int productId);
    }
}