jobOrder.filter('phone', function () {

    return function (phone) {

        //console.log(phone);
        if (!phone) { return ''; }

        var value = phone.toString().trim().replace(/^\+/, '');
        if (value.match(/[^0-9]/)) {
            return phone;
        }

        var city, number;

        if (value.length < 4) {

            city = value;
        } else {

            city = value.slice(0, 3);
            number = value.slice(3);
        }


        if (number) {

            if (number.length > 4) {

                number = number.slice(0, 4) + ' ' + number.slice(4,7);
            }

            return (city + " " + number).trim();

        } else {
            return city;
        }

    };

});