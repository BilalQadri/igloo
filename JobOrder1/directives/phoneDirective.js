
jobOrder.directive('phoneInput', function ($filter, $browser) {
    return {
        require: 'ngModel',
        link: function ($scope, $element, $attrs, ngModelCtrl) {


            var listener = function () {

                var value = $element.val().replace(/[^0-9]/g, '');
                $element.val($filter('phone')(value, false));
            };

            ngModelCtrl.$parsers.push(function (viewValue) {
                viewValue = viewValue.replace(/[^0-9]/g, '').slice(0, 10);
                if (viewValue.length < 10) {
                    ngModelCtrl.$setValidity('lengthValidator',false);
                } else {
                    ngModelCtrl.$setValidity('lengthValidator',true);
                }

                return viewValue;
            });

            

            ngModelCtrl.$render = function () {
                $element.val($filter('phone')(ngModelCtrl.$viewValue, false));
            };

            $element.bind('change', listener);
            $element.bind('keydown', function (event) {
                var key = event.keyCode;
                // If the keys include the CTRL, SHIFT, ALT, or META keys, or the arrow keys, do nothing.
                // This lets us support copy and paste too
                if (key == 91 || (15 < key && key < 19) || (37 <= key && key <= 40)) {
                    return;
                }
                $browser.defer(listener); // Have to do this or changes don't get picked up properly
            });

            $element.bind('paste cut', function () {
                $browser.defer(listener);
            });
        }
    }

});