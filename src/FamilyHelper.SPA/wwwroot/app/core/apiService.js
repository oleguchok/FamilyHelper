(function() {
    'use strict';

    angular.module('familyHelper')
        .factory('apiService', apiService);

    apiService.$inject = ["$http", "$location"];

    function apiService($http, $location) {
        var service = {
            get: get,
            post: post
        };

        function get(url, config, success, failure) {
            return $http.get(url, config)
                .then(function(result) {
                        success(result);
                    },
                    function(error) {
                        if (error.status == '401') {

                        } else if (failure != null) {
                            failure(error);
                        }
                    });
        };

        function post(url, data, success, failure) {
            return $http.post(url, data,
                {
                    headers: {'client_id':'Angular.OpenIdConnect'}
                })
                .then(function(result) {
                        success(result);
                    },
                    function(error) {
                        if (error.status == '401') {

                        } else if (failure != null) {
                            failure(error);
                        }
                    });
        };

        return service;
    }
})();