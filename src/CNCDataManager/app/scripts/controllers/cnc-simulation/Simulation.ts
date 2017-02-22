import * as angular from 'angular';
import { ISimulationScope } from '../../types/CncSimulation';
import HttpProxy from '../../services/HttpProxy';
import SimulationNotification from '../../services/SimulationNotification';
import SelectionNotification from '../../services/SelectionNotification';

export default class Simulation {
    public constructor($scope: ISimulationScope, 
                       $stateParams: angular.ui.IStateParamsService,
                       $state: angular.ui.IStateService,
                       httpProxy: HttpProxy,
                       selecNotifier: SelectionNotification,
                       simuNotifier: SimulationNotification) 
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
                modulusofElasticty: 210,
                shaftDistance: 0.8,
                pitch: 0.012,
                length: 0.766,
                density: 7850,
                shearModulusofElasticty: 62,
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
            $scope.data.setting = { 
                signal: 'Sine',
                startTime: 0,
                endTime: 1,
                stepSize: 0.0002,
                stepNum: 5000,
                alg: 'Rkfix4',
                precision:0.001,
            }
        };

        $scope.startSimulation = () => {
            if(selecNotifier.isAllSelected()) {
                /** 处理因单位不同的数据 GPa->Pa */
                $scope.data.ballscrew.modulusofElasticty = $scope.data.ballscrew.modulusofElasticty * 1e9;
                $scope.data.ballscrew.shearModulusofElasticty = $scope.data.ballscrew.modulusofElasticty * 1e9;

                let fileID = simuNotifier.getCurrentTime();
                let simulationUrl = httpProxy.getRelativeUrl('Simulation/StartSimulation', { fileID: fileID });
                httpProxy.http(simulationUrl).post($scope.data, { timeout: 1000 * 60 * 5});
                        // .then((response: any) => {
                        //     simuNotifier.notifyComplement(response.data);
                        // }, (response: any) => {
                        //     simuNotifier.notifyFailure(response.statusText || '糟糕，连不上服务器');
                        // });
                let pollingUrl = httpProxy.getRelativeUrl('Simulation/PollingSimulation', { fileID: fileID });
                let pollingID = httpProxy.http(pollingUrl).polling(
                    response => simuNotifier.notifyComplement(response.data),
                    response => simuNotifier.notifyFailure(response.statusText || '糟糕，连不上服务器'));
                simuNotifier.resetFileID(); //清除已经存在的fileID
                $state.go('simulation.Chart');
                setTimeout(() => simuNotifier.notifyStart(), 500); //由于此时结果页面的scope还没生成,所以要等一会儿
                angular.element('.modal-backdrop').remove(); //modal的bug,会出现两个<div class='modal-backdrop'>
            }
            else alert('选型尚未完成，请继续');
        };

        $scope.changeStepNum = () => {
            let interval = $scope.data.setting.endTime - $scope.data.setting.startTime;
            let stepSize = $scope.data.setting.stepSize;
            $scope.data.setting.stepNum = Math.round(interval / stepSize);
        }

        $scope.data = {} as any;
        $scope.data.axisID = $stateParams['axisID'];
        $scope.setDefaultMotorPara();
        $scope.setDefaultDriverPara();
        $scope.setDefaultMechanicalPara();
        $scope.setDefaultSimulationSettings();
    }
};

Simulation.$inject = ['$scope', '$stateParams', '$state', 'HttpProxy', 'SelectionNotification', 'SimulationNotification'];