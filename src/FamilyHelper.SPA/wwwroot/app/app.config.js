(function() {
    'use strict';

    angular.module('familyHelper')
        .config([
            '$routeProvider', '$locationProvider',
            function config($routeProvider, $locationProvider) {
                $routeProvider
                    .when("/login",
                    {
                        templateUrl: "/app/account/login.html"
                    })
                    .when("/register",
                    {
                        templateUrl: "/app/account/register.html"
                    });

                $locationProvider.html5Mode({ enabled: true, requireBase: false });
            }
        ]);
})();