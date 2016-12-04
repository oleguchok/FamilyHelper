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
                    templateUrl: '/app/account/login.html',
                    controller: 'loginController',
                   // resolve: { returnTo: returnTo }
                })

                .state('register', {
                    url: '/register',
                    templateUrl: '/app/account/register.html'
                });

        });

    function returnTo($transition$) {
        //if ($transition$.redirectedFrom() != null) {
        //    return $transition$.redirectedFrom().TargetState();
        //}

        //var $state = $transition$.router.stateService;

        //// The user was not redirected to the login state; they directly activated the login state somehow.
        //// Return them to the state they came from.
        //if ($transition$.from().name !== '')
        //{
        //    return $state.target($transition$.from(), $transition$.params("from"));
        //}

        //// If the fromState's name is empty, then this was the initial transition. Just return them to the home state
        //return $state.target('home');
    }
})();