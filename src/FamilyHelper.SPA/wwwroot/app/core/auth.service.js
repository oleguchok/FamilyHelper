(function () {
    'use strict';

    angular.module('familyHelper')
        .service('authService', authService);

    authService.$inject = ['$http', 'localStorageService'];

    function authService($http, localStorageService) {
        var self = this;

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
            return $http.post('http://localhost:54956' + '/connect/token', data,
            {
                 headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(success);
        }

        function success(response) {
            var data = response.data;
            localStorageService.set('authorizationData', { token: data.access_token });
        }
    }

})();