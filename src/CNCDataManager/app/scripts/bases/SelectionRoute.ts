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
            })
            .state('selection.MachineType', {
                url: '/machinetype',
                views: {
                    '':{
                        templateUrl: './views/cnc-selection/controller-tpls/selection.html',
                    },
                    'leftside@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/machine-type/machine-type-leftside.html',
                    },
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/machine-type/machine-type-content.html',
                        controller: 'MachineTypeCtrl'
                    }
                }
            })
            .state('selection.MachineType.WorkingConditions', {
                url: '/workingconditions',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/machine-type/working-conditions-content.html',
                        controller: 'MachineDetailsCtrl'
                    }
                }
            })
            .state('selection.CNCSystem', {
                url: '/cncsystem',
                views: {
                    '': {
                        templateUrl: './views/cnc-selection/controller-tpls/selection.html',
                    },
                    'leftside@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/cncsystem/cncsystem-leftside.html',
                    },
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/cncsystem/cncsystem-content.html',
                    }
                }
            })
            .state('selection.CNCSystem.Accessories', {
                url: '/accessories',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/cncsystem/accessories-content.html',
                    }
                }
            })
            .state('selection.FeedSystem', {
                url: '/feedsystem/{axis}',
                views: {
                    '': {
                        templateUrl: './views/cnc-selection/controller-tpls/selection.html',
                    },
                    'leftside@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/feed-system-leftside.html',
                    },
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/guides/guides-table-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.Guides', {
                url: '/guides',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/guides/guides-table-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.Guides.Details', {
                url: '/details/{id}',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/guides/guides-details-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.ScrewNuts', {
                url: '/screwnuts',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/screw-nuts/screw-nuts-table-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.ScrewNuts.Details', {
                url: '/details/{id}',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/screw-nuts/screw-nuts-details-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.Bearings', {
                url: '/bearings',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/bearings/bearings-table-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.Bearings.Details', {
                url: '/details/{id}',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/bearings/bearings-details-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.Couplings', {
                url: '/couplings',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/couplings/couplings-table-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.Couplings.Details', {
                url: '/details/{id}',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/couplings/couplings-details-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.ServoMotors', {
                url: '/servomotors',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/servo-motors/servo-motors-table-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.ServoMotors.Details', {
                url: '/details/{id}',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/servo-motors/servo-motors-details-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.ServoDrivers', {
                url: '/servodrivers',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/servo-drivers/servo-drivers-table-content.html',
                    }
                }
            })
            .state('selection.FeedSystem.ServoDrivers.Details', {
                url: '/details/{id}',
                views: {
                    'content@selection': {
                        templateUrl: './views/cnc-selection/controller-tpls/feed-system/servo-drivers/servo-drivers-details-content.html',
                    }
                }
            })
            ;

        $urlRouterProvider.otherwise('/home');
    });
}