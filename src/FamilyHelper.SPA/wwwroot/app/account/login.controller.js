(function() {
    'use strict';

    angular.module('familyHelper')
        .controller('loginController', loginController);

    loginController.$inject = ["$scope", "apiService", "ngConstantSettings", "authService"];
    
    function loginController($scope, apiService, ngConstantSettings, authService) {
        var serviceBase = ngConstantSettings.apiServiceBaseUri;
        $scope.user = {};
        $scope.user.grant_type = "password";

        $scope.login = function () {
            //apiService.post('http://localhost:54956' + '/connect/token', $scope.user, success, failure);
            authService.login($scope.user);
        }

        $scope.test = function() {
            apiService.get(serviceBase + '/connect/authorize',
                {
                    headers: { 'client_id': 'Angular.OpenIdConnect' }
                },
                success,
                failure);
        }

        function success(result) {
            if (result) {
                alert('!');
            }
        }

        function failure(error) {
            alert('Error!');
        }
    }
})();