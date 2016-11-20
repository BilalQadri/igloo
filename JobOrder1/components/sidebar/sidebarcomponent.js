var sidebarController = function ($state, $scope, $rootScope) {

    var preType = "";
    var vm = this;
    var rs = $rootScope;

    vm.jobSpecMenu = function () {

       // $(".jobspecmenu").removeClass("hide").addClass("animate");
    }

    $scope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {

        vm.call(toState.url.split('/')[1]);
    });

    
    

    vm.hideShow = function (id) {

        $("#hangMenu > ul").each(function () {
            
            var elm = $(this);

            if (elm.attr('id') == id) {
                elm.removeClass("hide");
            } else {
                elm.addClass("hide");
            }

        });
    }

    vm.call = function (type) {

        if (type == undefined) {
            var type = rs.getType();
        }
        if (preType != type) {
            vm.hideShow(type + "Menu");
            preType = type;
        }
        
    }

    // onInit function

    vm.$onInit = function () {

        vm.call();
    }

}






angular.module('jobOrder').component('sidebarComponent', {

    templateUrl: 'components/sidebar/sidebarcomponent.html',
    controller: sidebarController,
    controllerAs: 'vm'
});