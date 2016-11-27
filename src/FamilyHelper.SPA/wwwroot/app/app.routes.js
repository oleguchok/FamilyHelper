(function() {
    'use strict';

    angular.module('familyHelper')
        .config(function($stateProvider, $urlRouterProvider) {

            $urlRouterProvider.otherwise('/');

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/app/partial-home.html'
                })

                .state('login', {
                    url: '/login',
                    templateUrl: '/app/account/login.html'
                });

        });
})();