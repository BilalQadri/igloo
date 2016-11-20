var mainController = function ($state, $rootScope, $scope) {

    var vm = this;

    if (location.hash == '') {
        $state.go('worklist');
    }

   
}






angular.module('jobOrder').component('mainComponent', {

    templateUrl: 'components/main/maincomponent.html',
    controller: mainController,
    controllerAs: 'vm'
});