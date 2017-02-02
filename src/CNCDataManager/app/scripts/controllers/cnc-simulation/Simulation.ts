import * as angular from 'angular';
import { ISimulationScope } from '../../types/CncSimulation';
import HttpProxy from '../../services/HttpProxy';

export default class Simulation {
    public constructor($scope: ISimulationScope, 
                       $stateParams: angular.ui.IStateParamsService,
                       httpProxy: HttpProxy) 
    {
        $scope.setDefaultMotorPara = () => {
            $scope.data.motor = {
                rotorMomentInertia: 0.915,   
                polePairs: 1,
                statorResistance: 0.3567,
                statorStrayInductance: 0.000106,
                mainFieldInductanceDaxis: 0.002316,
                mainFieldInductanceQaxis: 0.002316,
                opposingElectromotiveForce: 110,
            };
        };

        $scope.setDefaultDriverPara = () => {
            $scope.data.driver = {
                nominalVoltage: 311,
                PWMCircle: 0.0001,
                KS: 60,
                KV: 0.5,
                polePairs: 1,
                cellVoltage: 311,
                KD: 2.7432,
                TD: 0.004085,
                TV: 0.015,
            };
        };

        $scope.setDefaultMechanicalPara = () => {
            $scope.data.ballscrew = {  
                diameter: 0.04,
                modulusofElasticty: 2.1e11,
                shaftDistance: 0.8,
                pitch: 0.012,
                length: 0.766,
                density: 7850,
                shearModulusofElasticty: 6.2e10,
                campingCoefficient: 0.09,
            };
            $scope.data.guide = {
                frictionFactor: 0.01,
                viscosityFriction: 56.6223,
            };
            $scope.data.bearings = {
                axisalStiffness: 7.6e8,
                startingMoment: 0.15,
            };
            $scope.data.coupling = {
                stiffness: 96389.8,
                momentInertia: 4e-5,
            };
            $scope.data.worktable = {
                mass: 100,
                tighteningEfficiency: 0.952,
                contactStiffness: 1.15e9,
                dynamicLoadRating: 25988,
            };
        };
        
        $scope.setDefaultSimulationSettings = () => {
            $scope.data.setting={
                signal: 'Sine',
                startTime: 0,
                endTime: 1,
                stepSize: 0.002,
                stepNum: 500,
                alg: 'Dass1',
                precision:0.001,
            }
        };

        $scope.startSimulation = () => {
            httpProxy.http('Simulation/StartSimulation')
                     .post($scope.data)
                     .then((response: any) => console.log(response));
        }

        $scope.data = {} as any;
        $scope.data.axisID = $stateParams['axisID'];
        $scope.setDefaultMotorPara();
        $scope.setDefaultDriverPara();
        $scope.setDefaultMechanicalPara();
        $scope.setDefaultSimulationSettings();
    }
};

Simulation.$inject = ['$scope', '$stateParams', 'HttpProxy'];