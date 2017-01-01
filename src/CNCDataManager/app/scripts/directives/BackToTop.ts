import * as angular from 'angular';


let BackToTop: angular.IDirectiveFactory = (): angular.IDirective => {
    return {
        templateUrl: './views/directives/back-to-top.html',
        restrict: 'E',
        scope: true,
        link: (scope: angular.IScope | any, ele: Element, attr: Attr) => {
            scope.backToTop = (): void =>
            {
                angular.element('body,html').animate({ scrollTop: 0 }, 300);
            }
        }
    };
};
export default BackToTop;