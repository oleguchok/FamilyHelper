(function () {
    'use strict';

    angular.module('familyHelper')
        .service('authService', authService);

    authService.$inject = ['$http', '$q', 'localStorageService'];

    function authService($http, $q, localStorageService) {
        var self = this;
        
        self.authentication = {
            isAuth: false
        }

        self.register = function (userRegister) {
            return $http.post('http://localhost:54956' + '/api/account/register', userRegister);
        }

        self.login = function (userLogin) {
            var data = "username=" +
                userLogin.username +
                "&password=" +
                userLogin.password +
                "&grant_type=" +
                userLogin.grant_type;

            var deferred = $q.defer();

            $http.post('http://localhost:54956' + '/connect/token',
                    data,
                    {
                        headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                    })
                .success(function success(response) {
                    localStorageService.set('authorizationData', { token: response.access_token });

                    authentication.isAuth = true;

                    $rootScope.isAuth = true;

                    deferred.resolve(response);
                });

            return deferred.promise;
        }

        self.isAuthenticated = function() {
            return authentication.isAuth;
        }
    }

})();