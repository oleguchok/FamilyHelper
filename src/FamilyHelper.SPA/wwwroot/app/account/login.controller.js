(function() {
    'use strict';

    angular.module('familyHelper')
        .controller('loginController', loginController);

    loginController.$inject = ["$scope", "apiService"];
    
    function loginController($scope, apiService) {
        $scope.login = function() {
            
        }
    }
})();