import * as angular from 'angular';
import 'angular-ui-router';

export default function registerSimulationRoute(app: angular.IModule): void
{
    app.config(($locationProvider: angular.ILocationProvider,
        $stateProvider: angular.ui.IStateProvider,
        $urlRouterProvider: angular.ui.IUrlRouterProvider) => {

        $locationProvider.hashPrefix('!');

        $stateProvider
            .state('simulation', {
                url: '/simulation',
                templateUrl: './views/cnc-simulation/controller-tpls/simulation.html',
            })
            .state('simulation.Settings', {
                url: '/settings/{axis}',
                views: {
                    '':{
                        templateUrl: './views/cnc-simulation/controller-tpls/simulation.html',
                    },
                    'leftside@simulation': {
                        templateUrl: './views/cnc-simulation/controller-tpls/simulation-leftside.html',
                    },
                    'content@simulation': {
                        templateUrl: './views/cnc-simulation/controller-tpls/simulation-content.html',
                        controller: 'SimulationCtrl'
                    }
                }
            })
            .state('simulation.Chart', {
                url: '/chart',
                views: {
                    'content@simulation': {
                        templateUrl: './views/cnc-simulation/controller-tpls/simulation-chart.html',
                        controller: 'SimulationChartCtrl'
                    }
                }
            });

            $urlRouterProvider.otherwise('/home');
    });
};