import * as angular from 'angular';

let ContentEditable: angular.IDirectiveFactory = ($sce: angular.ISCEService): angular.IDirective => {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: (scope: angular.IScope | any, element: JQuery, attrs: any, ngModelCtrl: angular.INgModelController) => {
            if (!ngModelCtrl) { return; }

            ngModelCtrl.$render = function () {
                element.html($sce.getTrustedHtml(ngModelCtrl.$viewValue || ''));
            };

            var read = function () {
                var value = element.html();
                if (attrs.type !== 'number' && attrs.type !== 'text') {
                    ngModelCtrl.$render();
                }
                else {
                    ngModelCtrl.$setViewValue(value);
                }
            };

            if (attrs.type === 'number') {
                ngModelCtrl.$parsers.push(function (value) { return parseFloat(value); });
            }
            if (attrs.type === 'text') {
                ngModelCtrl.$parsers.push(function (value) { return value.toString(); });
            }

            element.on('blur keyup change', function () {
                scope.$apply(read);
            });
        }
    };
};

ContentEditable.$inject = ['$sce'];

export default ContentEditable;