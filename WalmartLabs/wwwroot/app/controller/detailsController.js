(function () {
    'use strict';

    angular
        .module('walmartApp')
        .controller('detailsController', detailsController);

    detailsController.$inject = ['$scope', '$stateParams', 'productService'];

    function detailsController($scope, $stateParams, productService) {

        $scope.load = function() {
            if ($stateParams.itemId && !isNaN($stateParams.itemId)) {

                var ids = [parseInt($stateParams.itemId)];

                productService.getProductDetails(ids)
                    .then(function (response) {

                        if (response && response.data && response.data.productDetailsList.length > 0) {

                            var obj = response.data.productDetailsList[0];
                            obj.isTwoDayShippingEligible = (obj.isTwoDayShippingEligible === true) ? "Yes" : "No";
                            obj.availableOnline = (obj.availableOnline === true) ? "Yes" : "No";
                            $scope.data.currentDetails = obj;
                        }
                    })
                    .catch(function (error) {
                        console.log(error);
                        throw new Error("System could not process the request. Try again later.");
                    });
            }
        }

        $scope.recommendations = function () {
            var itemIds = [];
            $scope.data.showRecommendations = false;

            if ($stateParams.itemId && !isNaN($stateParams.itemId)) {

                productService.getProductRecommendations($stateParams.itemId)
                    .then(function (response) {
                        if (response.data && response.data.products && response.data.products.length > 0) {
                            $scope.data.showRecommendations = true;
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
        }
    }
})();
