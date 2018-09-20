using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WalmartLabs.Model;
using WalmartLabs.Service.Abstract;

namespace WalmartLabs.Controllers
{
    [Route("api/product"), EnableCors("AppPolicy")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("search/{searchCriteria?}")]
        public async Task<IActionResult> GetProducts(string searchCriteria)
        {
            var result = await _productService.SearchProducts(searchCriteria);
            return Ok(result);
        }

        [HttpGet]
        [Route("details")]
        //public async Task<IActionResult> GetProductDetails([FromQuery(Name = "ids")]int[] ids)
        public async Task<IActionResult> GetProductDetails(string productIds)
        {
            var result = await _productService.GetProductDetails(productIds);
            return Ok(result);
        }

        [HttpGet]
        [Route("recommendations")]
        public async Task<IActionResult> GetProductRecommendations(int productId)
        {
            var result = await _productService.GetRecommendations(productId);
            return Ok(result);
        }
    }
}