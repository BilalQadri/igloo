var transferController = function ($state, $scope, $rootScope) {

    var vm = this;
    var rs = $rootScope;

    vm.jobSpecMenu = function () {

        // $(".jobspecmenu").removeClass("hide").addClass("animate");
    }

    $scope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {

        console.log(toState);
    });



    vm.call = function () {

    }

    // onInit function

    vm.$onInit = function () {

        vm.call();
    }

}




angular.module('jobOrder').component('transferComponent', {

    templateUrl: 'components/transfer/transfercomponent.html',
    controller: transferController,
    controllerAs: 'vm'
});