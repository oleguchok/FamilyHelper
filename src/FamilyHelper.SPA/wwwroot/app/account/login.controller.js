(function() {
    'use strict';

    angular.module('familyHelper')
        .controller('loginController', loginController);

    loginController.$inject = ["$scope", "apiService", "ngConstantSettings"];
    
    function loginController($scope, apiService, ngConstantSettings) {
        var serviceBase = ngConstantSettings.apiServiceBaseUri;
        $scope.user = {};

        $scope.login = function () {
            apiService.post(serviceBase + '/api/token', $scope.user, success, failure);
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