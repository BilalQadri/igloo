var jobOrder = angular.module('jobOrder', ['ngMessages','ui.router']).controller('appCtrl', function ($rootScope) {

    $rootScope.getType = function () {

        return location.hash.split('/')[1];
    }
});

jobOrder.config(function ($stateProvider) {

    
    var worklist = {

        name: 'worklist',
        url: '/jobs/worklist',
        template: '<worklist-component></worklist-component>'
    }
    
    var search = {
         
        name: 'search',
        url: '/jobs/search',
        template: '<search-component></search-component>'
    }

    var transfer = {

        name: 'transfer',
        url: '/transfer/transfer',
        template: '<transfer-component></transfer-component>'
    }

    var clients = {

        name: 'clients',
        url: '/mng/clients',
        template: '<clients-component></clients-component>'
    }
   

    $stateProvider.state(worklist);
    $stateProvider.state(search);
    $stateProvider.state(transfer);
    $stateProvider.state(clients);
   
});



