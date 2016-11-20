jobOrder.factory('httpService', ['$http', function ($http) {

    var total = 0;
    
    return function (method, url, ref, success, error ) {


	
	return $http({

	    method: method,
	    url: url
	}).then(function successCallback (response) {

	    console.log("total succeeded XHR calls: "+ ++total);
	    success.call(ref, response);
	    
	}, function errorCallback (response) {

	    error.call(ref, response);

	});

    }

}])
