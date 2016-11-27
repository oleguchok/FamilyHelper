(function() {
    'use strict';

    angular.module('familyHelper')
        .factory('authInterceptor', authInterceptor);

    authInterceptor.$inject = ['localStorageService'];

    function authInterceptor(localStorageService) {
        return {
            request: function (config) {

                config.headers = config.headers || {};

                var authData = localStorageService.get('authorizationData');
                if (angular.equals(authData, {})) {
                    config.headers.Authorization = 'Bearer ' + authData;
                }

                return config;
            },
            response: function(response) {
                return response;
            }
        }
    }
})();