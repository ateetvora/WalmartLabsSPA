(function () {
    'use strict';

    angular
        .module('walmartApp')
        .controller('appController', appController);

    appController.$inject = ['$scope', 'productService'];

    function appController($scope, productService) {

        /*
        $scope.getSearchResults = function (searchCriteria) {

            $scope.data.headers = ['Image', 'Name', 'Short Description', 'Sale Price'];

            productService.getProducts(searchCriteria)
                .then(function (response) {
                    if (response.data && response.data.products && response.data.products.length > 0) {
                        $scope.data.products = [];
                        $scope.data.products = response.data.products;
                    }
                })
                .catch(function(error) {
                    console.log(error);
                    throw new Error("System could not process the request. Try again later.");
                });
        };

        $scope.getSearchResultsWithDetails = function(searchCriteria) {

            var itemIds = [];
            $scope.data.headers = ['Image', 'Name', 'Short Description', 'Sale Price', 'Brand', 'Model Number', 'Customer Rating', 'In Stock', 'Eligible for 2 Day Shipping'];

            productService.getProducts(searchCriteria)
                .then(function (response) {
                    if (response.data && response.data.products && response.data.products.length > 0) {
                        var products = response.data.products.slice(0, 10);
                        itemIds = products.map(elem => elem.itemId);
                        return itemIds;
                    }
                    return itemIds;
                })
                .then(function(ids) {
                    if (ids && ids.length > 0) {
                        productService.getProductDetails(ids)
                            .then(function(response) {

                                if (response && response.data && response.data.productDetailsList.length > 0) {
                                    $scope.data.productDetailsList = [];
                                    $scope.data.productDetailsList = response.data.productDetailsList;
                                }
                            })
                            .catch(function(error) {
                                console.log(error);
                                throw new Error("System could not process the request. Try again later.");
                            });
                    }
                })
                .catch(function (error) {
                    console.log(error);
                    throw new Error("System could not process the request. Try again later.");
                });
        }

        $scope.getProductRecommendations = function (productId) {
            var itemIds = [];
            debugger;
            if (productId && !isNaN(productId)) {
                productService.getProductRecommendations(productId)
                    .then(function (response) {
                        if (response.data && response.data.products && response.data.products.length > 0) {
                            var products = response.data.products.slice(0, 10);
                            itemIds = products.map(elem => elem.itemId);
                            return itemIds;
                        }
                        return itemIds;
                    })
                    .then(function (ids) {
                        if (ids && ids.length > 0) {
                            productService.getProductDetails(ids)
                                .then(function (response) {

                                    if (response && response.data && response.data.productDetailsList.length > 0) {
                                        $scope.data.recommendations = [];
                                        $scope.data.recommendations = response.data.productDetailsList;
                                    }
                                })
                                .catch(function (error) {
                                    console.log(error);
                                    throw new Error("System could not process the request. Try again later.");
                                });
                        }
                    })
                    .catch(function (error) {
                        console.log(error);
                        throw new Error("System could not process the request. Try again later.");
                    });
            }
        }*/

        $scope.reset = function() {
            $scope.data = null;
        }
    }
})();