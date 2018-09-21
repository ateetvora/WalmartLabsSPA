(function () {
    'use strict';

    angular
        .module('walmartApp')
        .controller('productsController', productsController);

    productsController.$inject = ['$scope', '$stateParams', 'productService'];

    function productsController($scope, $stateParams, productService) {

        //$scope.showResults = null;
        $scope.NoResults = "No search results to display";

        if ($stateParams.searchCriteria != null && $stateParams.searchCriteria !== "") {
            productService.getProducts($stateParams.searchCriteria)
                .then(function (response) {
                    if (response && response.data && response.data.products && response.data.products.length > 0) {
                        $scope.data.products = [];
                        $scope.data.products = response.data.products;
                        $scope.data.headers = ['Image', 'Name', 'Short Description', 'Sale Price'];
                        $scope.showResults = true;
                    } else
                        $scope.showResults = false;
                })
                .catch(function (error) {
                    $scope.data.showResults = false;
                    console.log(error);
                    throw new Error("System could not process the request. Try again later.");
                });
        }
        else
            $scope.showResults = false;
    }
})();
