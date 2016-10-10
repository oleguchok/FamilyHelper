(function() {
    'use strict';

    angular.module('familyHelper')
        .controller('loginController', loginController);

    loginController.$inject = ["$scope", "apiService"];
    
    function loginController($scope, apiService) {
        $scope.user = {};

        $scope.login = function () {
            apiService.post('http://localhost:5000/api/account/login', $scope.user, success, failure);
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