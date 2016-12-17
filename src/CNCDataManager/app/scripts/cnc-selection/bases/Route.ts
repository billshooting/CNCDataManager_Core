import * as angular from 'angular';
import 'angular-ui-router';

export default function registerSelectionRoute(app: angular.IModule): void
{
    app.config(($locationProvider: angular.ILocationProvider,
        $stateProvider: angular.ui.IStateProvider,
        $urlRouterProvider: angular.ui.IUrlRouterProvider) => {

        $locationProvider.hashPrefix('!');

        $stateProvider
            .state('selection', {
                url: '/selection',
                templateUrl: './views/cnc-selection/controller-tpls/selection.html',
                controller: 'SelectionCtrl'
            });

        $urlRouterProvider.otherwise('/home');
    });
}