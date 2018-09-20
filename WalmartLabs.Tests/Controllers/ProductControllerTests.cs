using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WalmartLabs.Controllers;
using WalmartLabs.Model;
using WalmartLabs.Model.ViewModel;
using WalmartLabs.Service.Abstract;

namespace WalmartLabs.Tests.Controllers
{
    [TestFixture()]
    public class ProductControllerTests
    {
        private ProductController _productController;
        private Mock<IProductService> _productService;

        [SetUp]
        public void Setup()
        {
            var products = new List<Product>
            {
                new Product {ItemId = 100}, new Product {ItemId = 101}, new Product {ItemId = 102}
            };
            var productsResult = new ProductsViewModel() {Products = products};

            var productDetails = new List<ProductDetails>
            {
                new ProductDetails()
                {
                    ItemId = 1, Name = "Product A"
                },
                new ProductDetails()
                {
                    ItemId = 2,
                    Name = "Product B"
                }
            };
            var productDetailsResult = new ProductDetailsViewModel() {ProductDetailsList = productDetails};

            var recommendations = new List<Product>
            {
                new Product {ItemId = 11}, new Product {ItemId = 22}, new Product {ItemId = 33}, new Product {ItemId = 44}
            };
            var productRecommendationResult = new ProductsViewModel() {Products = recommendations};

            _productService = new Mock<IProductService>();

            _productService.Setup(a => a.SearchProducts(It.IsAny<string>()))
                .Returns(Task.FromResult(productsResult));

            _productService.Setup(a => a.GetProductDetails(It.IsAny<string>()))
                .Returns(Task.FromResult(productDetailsResult));

            _productService.Setup(a => a.GetRecommendations(It.IsAny<int>()))
                .Returns(Task.FromResult(productRecommendationResult));
        }

        [Test]
        public void GetProducts_WhenCalled_ReturnsOkObjectResult()
        {
            _productController = new ProductController(_productService.Object);

            var result = _productController.GetProducts("Apple").Result;

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetProducts_WhenCalled_ExecutesProductServiceSearchProductsAPI()
        {
            _productController = new ProductController(_productService.Object);

            var result = _productController.GetProducts("Apple").Result;

            _productService.Verify(t => t.SearchProducts("Apple"), Times.Once);
        }

        [Test]
        public void GetProducts_WhenCalled_ReturnsAListOfProducts()
        {
            _productController = new ProductController(_productService.Object);

            var result = _productController.GetProducts("Apple").Result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ProductsViewModel>(result.Value);
            Assert.AreEqual(((ProductsViewModel)(result.Value)).Products.Count(), 3);
        }
        
        [Test]
        public void GetProductDetails_WhenCalled_ReturnsOkObjectResult()
        {
            _productController = new ProductController(_productService.Object);

            var result = _productController.GetProductDetails("").Result;

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetProductDetails_WhenCalled_ExecutesProductServiceGetProductDetailsAPI()
        {
            _productController = new ProductController(_productService.Object);

            var result = _productController.GetProductDetails("").Result;

            _productService.Verify(t => t.GetProductDetails(""), Times.Once);
        }

        [Test]
        public void GetProductDetails_WhenCalled_ReturnsAListOfProductDetails()
        {
            _productController = new ProductController(_productService.Object);

            var result = _productController.GetProductDetails("").Result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ProductDetailsViewModel>(result.Value);
            Assert.AreEqual(((ProductDetailsViewModel)(result.Value)).ProductDetailsList.Count(), 2);
        }

        [Test]
        public void GetProductRecommendations_WhenCalled_ReturnsOkObjectResult()
        {
            _productController = new ProductController(_productService.Object);

            var result = _productController.GetProductRecommendations(0).Result;

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetProductRecommendations_WhenCalled_ExecutesProductServiceGetRecommendationsAPI()
        {
            _productController = new ProductController(_productService.Object);

            var result = _productController.GetProductRecommendations(0).Result;

            _productService.Verify(t => t.GetRecommendations(0), Times.Once);
        }

        [Test]
        public void GetProductRecommendations_WhenCalled_ReturnsAllProductRecommendations()
        {
            _productController = new ProductController(_productService.Object);

            var result = _productController.GetProductRecommendations(0).Result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ProductsViewModel>(result.Value);
            Assert.AreEqual(((ProductsViewModel)(result.Value)).Products.Count(), 4);
        }
    }
}
