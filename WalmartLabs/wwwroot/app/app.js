var walmartApp = angular.module('walmartApp', ['ui.router']);

walmartApp.config([
    '$locationProvider', '$stateProvider', '$urlRouterProvider', '$urlMatcherFactoryProvider', '$compileProvider',
    function ($locationProvider, $stateProvider, $urlRouterProvider, $urlMatcherFactoryProvider, $compileProvider) {

        if (window.history && window.history.pushState) {
            $locationProvider.html5Mode({
                enabled: true,
                requireBase: true
            }).hashPrefix('!');
        };

        $urlMatcherFactoryProvider.strictMode(false);
        $compileProvider.debugInfoEnabled(false);

        $stateProvider
            .state('home',
                {
                    url: '/'
                })
            .state('products',
                {
                    url: '/products/:searchCriteria',
                    templateUrl: 'partial-products.html',
                    controller: 'productsController'
            })
            .state('details',
                {
                    url: '/details/:itemId',
                    templateUrl: 'partial-details.html',
                    controller: 'detailsController'
                })
            .state('otherwise',
                {
                    url: "/"
                });

        $urlRouterProvider.otherwise('/');
    }
]); 