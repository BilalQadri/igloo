var navbarController = function ($rootScope, $scope, $state) {

    var preType = "";
    var vm = this;
    var rs = $rootScope;
    
    
    vm.navChange = function (view) {

        $state.go(view);
    }



    $scope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
        
        vm.call(toState.url.split('/')[1]);
    });




    vm.activeOrNot = function (id,preId) {

        $(id).removeClass("hover-fill-gray").addClass("blue").addClass("active");
           
        $(preId).addClass("hover-fill-gray").removeClass("blue").removeClass("active");
                            

    }

    vm.call = function (type) {
        if (type == undefined) {
            var type = rs.getType();
        }
        
        if (preType != type) {
            vm.activeOrNot("#" + type + "Nav", "#" + preType + "Nav");
            preType = type;
        }

    }

    // onInit function

    vm.$onInit = function () {

        vm.call();
    }
}






angular.module('jobOrder').component('navbarComponent', {

    templateUrl: 'components/navbar/navbarcomponent.html',
    controller: navbarController,
    controllerAs: 'vm'
});