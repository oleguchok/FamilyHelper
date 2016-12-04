(function() {
    'use strict';

    angular.module('familyHelper')
        .controller('loginController', loginController);

    loginController.$inject = ["$scope", "$state", "apiService", "ngConstantSettings", "authService"];
    
    function loginController($scope, $state, apiService, ngConstantSettings, authService) {
        var serviceBase = ngConstantSettings.apiServiceBaseUri;
        $scope.user = {};
        $scope.user.grant_type = "password";

        $scope.login = function () {
            authService.login($scope.user).then(function(response) {
                $state.go('home');
            });
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