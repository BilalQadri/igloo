jobOrder.filter('mobile', function () {

    return function (mobile) { 

        //console.log(mobile);
        if (!mobile) { return ''; }

        var value = mobile.toString().trim().replace(/^\+/, '');
        if (value.match(/[^0-9]/)) {
            return mobile;
        }

        var code, number;

        if (value.length < 5) {

            code = value;
        } else {

            code = value.slice(0, 4);
            number = value.slice(4);
        }


        if (number) {

            if (number.length > 4) {

                number = number.slice(0, 4) + ' ' + number.slice(4,7);
            }

            return (code + " " + number).trim();

        } else {
            return code;
        }

    };

});