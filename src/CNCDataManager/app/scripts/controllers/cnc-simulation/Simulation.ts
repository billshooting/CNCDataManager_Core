import * as angular from 'angular';
import { ISimulationScope } from '../../types/CncSimulation';
import HttpProxy from '../../services/HttpProxy';
import SimulationNotification from '../../services/SimulationNotification';
import SelectionNotification from '../../services/SelectionNotification';
import User from '../../services/User';
import MessageTips from '../../services/MessageTips';

export default class Simulation 
{
    public constructor($scope: ISimulationScope, 
                       $stateParams: angular.ui.IStateParamsService,
                       $state: angular.ui.IStateService,
                       httpProxy: HttpProxy,
                       selecNotifier: SelectionNotification,
                       simuNotifier: SimulationNotification,
                       user: User,
                       message: MessageTips) 
    {
        $scope.setDefaultMotorPara = () => 
        {
            $scope.data.motor = 
            {
                rotorMomentInertia: 0.915,   
                polePairs: 1,
                statorResistance: 0.3567,
                statorStrayInductance: 0.000106,
                mainFieldInductanceDaxis: 0.002316,
                mainFieldInductanceQaxis: 0.002316,
                opposingElectromotiveForce: 110,
            };
        };

        $scope.setDefaultDriverPara = () => 
        {
            $scope.data.driver = 
            {
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

        $scope.setDefaultMechanicalPara = () => 
        {
            $scope.data.ballscrew = 
            {  
                diameter: 0.04,
                modulusofElasticty: 210,
                shaftDistance: 0.8,
                pitch: 0.012,
                length: 0.766,
                density: 7850,
                shearModulusofElasticty: 62,
                campingCoefficient: 0.09,
            };
            $scope.data.guide = 
            {
                frictionFactor: 0.01,
                viscosityFriction: 56.6223,
            };
            $scope.data.bearings = 
            {
                axisalStiffness: 7.6e8,
                startingMoment: 0.15,
            };
            $scope.data.coupling = 
            {
                stiffness: 96389.8,
                momentInertia: 4e-5,
            };
            $scope.data.worktable = 
            {
                mass: 100,
                tighteningEfficiency: 0.952,
                contactStiffness: 1.15e9,
                dynamicLoadRating: 25988,
            };
        };
        
        $scope.setDefaultSimulationSettings = () => 
        {
            $scope.data.setting = 
            { 
                signal: 'Sine',
                startTime: 0,
                endTime: 1,
                stepSize: 0.0002,
                stepNum: 5000,
                alg: 'Rkfix4',
                precision:0.001,
            }
        };

        //由于一个未知的Bootstrap modal的bug: 如果用data-*标签的方式调用modal会出现两个<div class='modal-backdrop'>，而且会导致整个页面在modal消失之后左移17px
        //只能用js手动调用了
        $scope.confirmStart = () => { (angular.element('#startModal') as any).modal({focus: true}); };
        $scope.startSimulation = () => 
        {
            (angular.element('#startModal') as any).modal('hide');

            if(selecNotifier.isAllSelected()) 
            {
                /** 检测是否登陆 */
                if(!user.IsAuthenticated) 
                {
                    message.showError('请先登陆后再尝试');
                    return;
                }
                /** 处理因单位不同的数据 GPa->Pa */
                $scope.data.ballscrew.modulusofElasticty = $scope.data.ballscrew.modulusofElasticty * 1e9;
                $scope.data.ballscrew.shearModulusofElasticty = $scope.data.ballscrew.modulusofElasticty * 1e9;
                
                let fileID = simuNotifier.getCurrentTime();
                let simulationUrl = httpProxy.getRelativeUrl('Simulation/StartSimulation', { fileID: fileID, userName: user.Name });
                httpProxy.http(simulationUrl).post($scope.data, { timeout: 1000 * 60 * 5}).catch(
                    response => { if(response.status === 401) simuNotifier.notifyFailure('账户尚未登陆或者权限不够'); });

                let pollingUrl = httpProxy.getRelativeUrl('Simulation/PollingSimulation', { fileID: fileID, userName: user.Name });
                let pollingID = httpProxy.http(pollingUrl).polling(
                    response => simuNotifier.notifyComplement(response.data),
                    response => 
                    {
                        if(response.status === 401) simuNotifier.notifyFailure('账户尚未登陆或者权限不够');
                        else simuNotifier.notifyFailure(response.statusText || '糟糕，连不上服务器')
                    });

                simuNotifier.resetFileID(); //清除已经存在的fileID
                setTimeout(() => $state.go('simulation.Chart'), 700);
                setTimeout(() => simuNotifier.notifyStart(), 1200); //由于此时结果页面的scope还没生成,所以要等一会儿               
            }
            else alert('选型尚未完成，请继续');
        };

        $scope.changeStepNum = () => 
        {
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

Simulation.$inject = ['$scope', '$stateParams', '$state', 'HttpProxy', 'SelectionNotification', 'SimulationNotification', 'User', 'MessageTips'];