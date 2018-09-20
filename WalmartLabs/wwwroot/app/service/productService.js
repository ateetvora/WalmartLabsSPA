(function () {
    'use strict';

    angular
        .module('walmartApp')
        .factory('productService', productService);

    productService.$inject = ['$http'];

    function productService($http) {
        var service = {
            getProducts: getProducts,
            getProductRecommendations: getProductRecommendations,
            getProductDetails: getProductDetails
        };

        return service;

        function getProducts(searchCriteria) {
            var url = 'api/product/search';

            if (searchCriteria)
                url += '/' + searchCriteria;

            return $http.get(url);
        }

        function getProductRecommendations(productId) {
            var url = 'api/product/recommendations';

            if (productId && !isNaN(productId))
                url += "?productId=" + productId;

            return $http.get(url);
        }

        function getProductDetails(arrProductIds) {
            var productItemIds = arrProductIds.join(",");

            var url = 'api/product/details';

            if (productItemIds) {
                url += '?productIds=' + productItemIds;
            }

            return $http.get(url);
        }
    }
})();