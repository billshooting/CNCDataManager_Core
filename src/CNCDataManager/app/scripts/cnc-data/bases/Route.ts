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
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/hub-shaped-couplings.html',
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
            .state('cncdata.list.NeedleThrustRollerBearings', {
                url: '/needlethrustrollerbearings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/needle-thrust-roller-bearings.html',
                        controller: 'NeedleThrustRollerBearingsCtrl'
                    }
                }
            })
            .state('cncdata.list.OldhamCouplings', {
                url: '/oldhamcouplings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/oldham-couplings.html',
                        controller: 'OldhamCouplingsCtrl'
                    }
                }
            })
            .state('cncdata.list.PlumShapedFlexibleCouplings', {
                url: '/plumshapedflexiblecouplings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/plum-shaped-flexible-couplings.html',
                        controller: 'PlumShapedFlexibleCouplingsCtrl'
                    }
                }
            })
            .state('cncdata.list.PMServoMotorDrivers', {
                url: '/pmservomotordrivers',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/pmservo-motor-drivers.html',
                        controller: 'PMServoMotorDriversCtrl'
                    }
                }
            })
            .state('cncdata.list.PMServoMotorTechParameters', {
                url: '/pmservomotortechparameters',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/pmservo-motor-tech-parameters.html',
                        controller: 'PMServoMotorTechParametersCtrl'
                    }
                }
            })
            .state('cncdata.list.RotaryTables', {
                url: '/rotarytables',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/rotary-tables.html',
                        controller: 'RotaryTablesCtrl'
                    }
                }
            })
            .state('cncdata.list.SpindleBeltLengthParameters', {
                url: '/spindlebeltlengthparameters',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/spindle-belt-length-parameters.html',
                        controller: 'SpindleBeltLengthParametersCtrl'
                    }
                }
            })
            .state('cncdata.list.SpindleBeltTechParameters', {
                url: '/spindlebelttechparameters',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/spindle-belt-tech-parameters.html',
                        controller: 'SpindleBeltTechParametersCtrl'
                    }
                }
            })
            .state('cncdata.list.SpindleBeltSizeParameters', {
                url: '/spindlebeltsizeparameters',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/spindle-belt-size-parameters.html',
                        controller: 'SpindleBeltSizeParametersCtrl'
                    }
                }
            })
            .state('cncdata.list.SpindleServoMotorDrivers', {
                url: '/spindleservomotordrivers',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/spindle-servo-motor-drivers.html',
                        controller: 'SpindleServoMotorDriversCtrl'
                    }
                }
            })
            .state('cncdata.list.SpindleServoMotorTechParameters', {
                url: '/spindleservomotortechparameters',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/spindle-servo-motor-tech-parameters.html',
                        controller: 'SpindleServoMotorTechParametersCtrl'
                    }
                }
            })
            .state('cncdata.list.SpurGears', {
                url: '/spurgears',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/spur-gears.html',
                        controller: 'SpurGearsCtrl'
                    }
                }
            })
            .state('cncdata.list.ServoDriverBrakeResistors', {
                url: '/servodriverbrakeresistors',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/servo-driver-brake-resistors.html',
                        controller: 'ServoDriverBrakeResistorsCtrl'
                    }
                }
            })
            .state('cncdata.list.ServoDriverReactors', {
                url: '/servodriverreactors',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/servo-driver-reactors.html',
                        controller: 'ServoDriverReactorsCtrl'
                    }
                }
            })
            .state('cncdata.list.ServoDriverTransformers', {
                url: '/servodrivertransformers',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/servo-driver-transformers.html',
                        controller: 'ServoDriverTransformersCtrl'
                    }
                }
            })
            .state('cncdata.list.StraightBevelGears', {
                url: '/straightbevelGears',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/straight-bevel-gears.html',
                        controller: 'StraightBevelGearsCtrl'
                    }
                }
            })
            .state('cncdata.list.TaperedRollerBearings', {
                url: '/taperedrollerbearings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/tapered-roller-bearings.html',
                        controller: 'TaperedRollerBearingsCtrl'
                    }
                }
            })
            .state('cncdata.list.AcrossTaperedRollerBearings', {
                url: '/acrosstaperedrollerbearings',
                views: {
                    'list@cncdata.list': {
                        templateUrl: './views/cnc-data/controller-tpls/cncdata/list/across-tapered-roller-bearings.html',
                        controller: 'AcrossTaperedRollerBearingsCtrl'
                    }
                }
            })
            ;

        $urlRouterProvider.otherwise('/home')
    });
};
registerRoute.$inject = ['$locationProvider', '$stateProvider', '$urlRouterProvider'];
