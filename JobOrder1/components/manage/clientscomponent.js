var clientsController = function ($state, $scope, $rootScope, httpService) {

    var vm = this;
    var formStatus = false;
    vm.formData = {

        name: 'Bilal',
        email: 'kami@gmail.com',
        phone: '0515656567', 
        mobile: '03009764520',
        address: 'VPO ikhlas pindi Gheb'
    }

    vm.addClient = function () {

        httpService('GET', '/api/addClient?data='+encodeURIComponent(JSON.stringify(vm.formData)), vm, function (response) {

            console.log(response);

        }, function (response) {

            console.log(response);
        });
    }

    vm.onSubmit = function () {

        $("#mainError").text("");
        if ($scope.clientForm.$valid) {
            vm.addClient();
            $("#mainError").removeClass("danger").addClass("success").text("Submitted.");
        } else {
            $("#mainError").removeClass("success").addClass("danger").text("There are some errors.");
        }

    }

    vm.showHide = function () {

        if (formStatus == false) {
            $("#clientForm").removeClass("hide"); 
            formStatus = true;
        } else { 
            $("#clientForm").addClass("hide");
            formStatus = false;
        }
    }
}

angular.module('jobOrder').component('clientsComponent',{

    templateUrl: 'components/manage/clientscomponent.html',
    controller: clientsController,
    controllerAs: 'vm'
});