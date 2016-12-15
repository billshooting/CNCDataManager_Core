import * as angular from 'angular';
import 'angular-ui-router';

export default function registerRoute(app: angular.IModule): void {
    app.config(($locationProvider: angular.ILocationProvider,
                $stateProvider: angular.ui.IStateProvider,
                $urlRouterProvider: angular.ui.IUrlRouterProvider) => {

        $locationProvider.hashPrefix('!');

        $stateProvider
            .state('home', {
                url: '/home',
                templateUrl: './views/cnc-data/controller-tpls/home/home.html',
                controller: 'HomeCtrl'
            })
            .state('about', {
                url: '/about',
                templateUrl: './views/cnc-data/controller-tpls/home/about.html',
                controller: 'AboutCtrl'
            })
            .state('contact', {
                url: '/contact',
                templateUrl: './views/cnc-data/controller-tpls/home/contact.html',
                controller: 'ContactCtrl'
            })
            .state('cncdata', {
                url: '/cncdata',
                views: {
                    '': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/cncdata.html',
                        controller: 'CNCDataCtrl'
                    },
                    'leftside@cncdata': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/cncdata-leftside.html',
                        controller: 'CncDataLeftSideCtrl'
                    },
                    'content@cncdata': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/cncdata-description.html',
                        controller: 'CncDataDescCtrl'
                    }
                }
            })
            .state('cncdata.list', {
                url: '/list',
                views: {
                    'content@cncdata': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/cncdata-list.html',
                    }
                }
            })
            .state('cncdata.list.AligningBallBearings', {
                url: '/aligningballbearings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/aligning-ball-bearings.html',
                        controller: 'AligningBallBearingCtrl'
                    }
                }
            })
            .state('cncdata.list.AligningRollerBearings', {
                url: '/aligningrollerbearings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/aligning-roller-bearings.html',
                        controller: 'AligningRollerBearingsCtrl'
                    }
                }
            })
            .state('cncdata.list.AngularContactBallBearings', {
                url: '/angularcontactballBearings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/angular-contact-ball-bearings.html',
                        controller: 'AngularContactBallBearingsCtrl'
                    }
                }
            })
            .state('cncdata.list.ArcCylindricalWormGears', {
                url: '/arccylindricalwormgears',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/arc-cylindrical-wormgears.html',
                        controller: 'ArcCylindricalWormGearsCtrl'
                    }
                }
            })
            .state('cncdata.list.BallLeadingScrewSupportingBearings', {
                url: '/ballleadingscrewsupportingbearings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/ball-leading-screw-supporting-bearings.html',
                        controller: 'BallLeadingScrewSupportingBearingsCtrl'
                    }
                }
            })
            .state('cncdata.list.BWElasticSleevePinCouplings', {
                url: '/bwelasticsleevepincouplings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/bwelastic-sleeve-pin-couplings.html',
                        controller: 'BWElasticSleevePinCouplingsCtrl'
                    }
                }
            })
            .state('cncdata.list.Cables', {
                url: '/cables',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/cables.html',
                        controller: 'CablesCtrl'
                    }
                }
            })
            .state('cncdata.list.CylindricalRollerBearings', {
                url: '/cylindricalrollerbearings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/cylindrical-roller-bearings.html',
                        controller: 'CylindricalRollerBearingsCtrl'
                    }
                }
            })
            .state('cncdata.list.DeepGrooveBallBearings', {
                url: '/deepgrooveballbearings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/deep-groove-ball-bearings.html',
                        controller: 'DeepGrooveBallBearingsCtrl'
                    }
                }
            })
            .state('cncdata.list.DoubleRowCylindricalRollerBearings', {
                url: '/doublerowcylindricalrollerbearings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/double-row-cylindrical-roller-bearings.html',
                        controller: 'DoubleRowCylindricalRollerBearingsCtrl'
                    }
                }
            })
            .state('cncdata.list.DoubleThrustAngularContactBallBearings', {
                url: '/doublethrustangularcontactballbearings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/double-thrust-angular-contact-ball-bearings.html',
                        controller: 'DoubleThrustAngularContactBallBearingsCtrl'
                    }
                }
            })
            .state('cncdata.list.ElasticSleevePinCouplings', {
                url: '/elasticsleevepincouplings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/elastic-sleeve-pin-couplings.html',
                        controller: 'ElasticSleevePinCouplingsCtrl'
                    }
                }
            })
            .state('cncdata.list.ElectronicSpindleTechParameters', {
                url: '/electronicspindletechparameters',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/electronic-spindle-tech-parameters.html',
                        controller: 'ElectronicSpindleTechParametersCtrl'
                    }
                }
            })
            .state('cncdata.list.FlangeCouplings', {
                url: '/flangecouplings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/flange-couplings.html',
                        controller: 'FlangeCouplingsCtrl'
                    }
                }
            })
            .state('cncdata.list.FlexiblePinCouplings', {
                url: '/FlexiblePinCouplings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/flexible-pin-couplings.html',
                        controller: 'FlexiblePinCouplingsCtrl'
                    }
                }
            })
            .state('cncdata.list.GearCouplings', {
                url: '/gearcouplings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/gear-couplings.html',
                        controller: 'GearCouplingsCtrl'
                    }
                }
            })
            .state('cncdata.list.HelicalCylindricalGears', {
                url: '/helicalcylindricalgears',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/helical-cylindrical-gears.html',
                        controller: 'HelicalCylindricalGearsCtrl'
                    }
                }
            })
            .state('cncdata.list.HubShapedCouplings', {
                url: '/hubshapedcouplings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/Hub-Shaped-couplings.html',
                        controller: 'HubShapedCouplingsCtrl'
                    }
                }
            })
            .state('cncdata.list.LinearRollingGuides', {
                url: '/linearrollingguides',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/linear-rolling-guides.html',
                        controller: 'LinearRollingGuidesCtrl'
                    }
                }
            })
            .state('cncdata.list.NCSystemFunctionalOptions', {
                url: '/ncsystemfunctionaloptions',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/ncsystem-functional-options.html',
                        controller: 'NCSystemFunctionalOptionsCtrl'
                    }
                }
            })
            .state('cncdata.list.NCSystemIOUnits', {
                url: '/ncsystemiounits',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/ncsystem-io-units.html',
                        controller: 'NCSystemIOUnitsCtrl'
                    }
                }
            })
            .state('cncdata.list.NCSystemManuals', {
                url: '/ncsystemmanuals',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/ncsystem-manuals.html',
                        controller: 'NCSystemManualsCtrl'
                    }
                }
            })
            .state('cncdata.list.NCSystemPowerUnits', {
                url: '/ncsystempowerunits',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/ncsystem-power-units.html',
                        controller: 'NCSystemPowerUnitsCtrl'
                    }
                }
            })
            ;

        $urlRouterProvider.otherwise('/home')
    });
};
registerRoute.$inject = ['$locationProvider', '$stateProvider', '$urlRouterProvider'];
