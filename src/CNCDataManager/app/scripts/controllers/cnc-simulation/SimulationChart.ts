import * as angular from 'angular';
import Highcharts from 'highcharts';
import HighchartsExporting from 'highchart-exporting';
import { ISimulationChartScope } from '../../types/CncSimulation';
import HttpProxy from '../../services/HttpProxy';
import SimulationNotification from '../../services/SimulationNotification';

HighchartsExporting(Highcharts);
export default class SimulationChart
{
    public constructor($scope: ISimulationChartScope,
                       $interval: angular.IIntervalService,
                       $timeout: angular.ITimeoutService,
                       httpProxy: HttpProxy,
                       notifier: SimulationNotification) 
    {
        $scope.simulationStarted = () => {
            $scope.state.isStarted = true;
            $scope.state.isCompleted = false;
            $scope.state.progress = 0;
        }

        $scope.simulationCompleted = (): void =>
        {
            $scope.state.isStarted = false;
            $scope.state.isCompleted = true;
            $scope.state.progress = 100;
            $scope.state.stateText = '仿真结束';            
            $interval.cancel(intervalID);
        };

        $scope.simulationFailed = (errorMsg: string): void => {
            $scope.state.isStarted = false;
            $scope.state.isCompleted = false;
            $scope.state.progress = 0;
            $scope.state.stateText = errorMsg;
            $interval.cancel(intervalID);
        }

        $scope.showData = (simulationType: string): void => {
            let simuTypeStr: string = null;
            let plotData = notifier.plotData;
            let thisData = plotData[simulationType];
            let containerID = simulationType + '-chart';
            let chartOptions: Highcharts.Options = {
                chart: { zoomType: 'x' },
                title: { text: '速度-时间仿真结果' },
                subtitle: { text: document.ontouchstart === undefined ? '鼠标拖动可以进行缩放' : '手势操作进行缩放' },
                xAxis: {
                    title: { text: '时间 (s)' }
                },
                yAxis: { 
                    title: { text: '速度 (m/s)' }
                },
                tooltip: { valueSuffix: 'm/s' },
                legend: { enabled: false },
                plotOptions: {
                    area: {
                        fillColor: {
                            linearGradient: {
                                x1: 0,
                                y1: 0,
                                x2: 0,
                                y2: 1
                            },
                            stops: [
                                [0, Highcharts.getOptions().colors[0]],
                                [1, (Highcharts.Color(Highcharts.getOptions().colors[0]) as Highcharts.Gradient).setOpacity(0).get('rgba')]
                            ]
                        },
                        marker: {
                            radius: 2
                        },
                        lineWidth: 1,
                        states: {
                            hover: {
                                lineWidth: 1
                            }
                        },
                        threshold: null
                    }
                },
                series: [{
                    type: 'area',
                    name: null,
                    data: null,
                }]
            };
            switch(simulationType){
                case 'displacement':{
                    simuTypeStr = 'X';
                    chartOptions.title.text = '位移-时间仿真结果';
                    (chartOptions.yAxis as any).title.text = '位移 (m)'
                    chartOptions.tooltip.valueSuffix = 'm';
                    chartOptions.series[0].name = 'x-t';
                    break;
                }
                case 'velocity':{
                    simuTypeStr = 'v';
                    chartOptions.title.text = '速度-时间仿真结果';
                    (chartOptions.yAxis as any).title.text = '速度 (m/s)'
                    chartOptions.tooltip.valueSuffix = 'm/s';
                    chartOptions.series[0].name = 'v-t';
                    break;
                }
                case 'acceleration':{
                    simuTypeStr = 'a';
                    chartOptions.title.text = '加速度-时间仿真结果';
                    (chartOptions.yAxis as any).title.text = '加速度 (m/s^2)'
                    chartOptions.tooltip.valueSuffix = 'm/s^2';
                    chartOptions.series[0].name = 'a-t';
                    break;
                }
                default: break;
            }
            if(thisData){
                chartOptions.series[0].data = thisData;
                $timeout(() => {
                    let chart = Highcharts.chart(containerID, chartOptions);
                }, 300);
            }
            else{
                httpProxy.http('Simulation/SimulationResults').get({
                    fileID: notifier.fileID,
                    type: simuTypeStr,
                }).then(response => {
                    /** 将string类型的数据转换为number */
                    let stringData = response.data.data as [string, string][];
                    notifier.plotData[simulationType] = stringData.map(twoEleArray => {
                        return <[number, number]>[parseFloat(twoEleArray[0]), parseFloat(twoEleArray[1])];
                    });
                    chartOptions.series[0].data = notifier.plotData[simulationType];
                    $timeout(() => {
                        let chart = Highcharts.chart(containerID, chartOptions);
                    }, 300);
                    // let svg: string = chart.getSVG();
                    // let url = httpProxy.getRelativeUrl('Report/UploadSvg', { fileID: notifier.fileID });
                    // httpProxy.http(url).post({
                    //     FileName: 'v-t',
                    //     Type: 'image/png',
                    //     Width: 800,
                    //     SvgStr: svg
                    // });
                });
            }

        }

        /** 初始化 */
        /** 注册通知 */
        notifier.registerNotification($scope);
        var intervalID: angular.IPromise<any> = null;
        $scope.state = 
        {
            isCompleted: false,
            isStarted: false,
            progress: 0,
            stateText: '尚未开始仿真',
        };

        /** 进度条设置 */
        intervalID = $interval(() => {
            if($scope.state.isStarted === false) $scope.state.stateText = '尚未开始仿真';
            if($scope.state.isStarted === true && $scope.state.isCompleted === false)
            {
                if($scope.state.progress <= 3) $scope.state.stateText = '(请勿离开此页面)正在与服务器建立连接...';
                else if($scope.state.progress <= 8) $scope.state.stateText = '(请勿离开此页面)正在处理选型数据...';
                else if($scope.state.progress <= 13) $scope.state.stateText = '(请勿离开此页面)正在替换模板模型...';
                else if($scope.state.progress <= 20) $scope.state.stateText = '(请勿离开此页面)正在编译模型...';
                else if($scope.state.progress <= 50) $scope.state.stateText = '(请勿离开此页面)正在生成求解器...';
                else if($scope.state.progress < 100) $scope.state.stateText = '(请勿离开此页面)正在运行求解器...';
                $scope.state.progress += 2;               
            }
        }, 500);
        /** 如果已经有数据了 */
        if(notifier.fileID && notifier.fileID.length === 36) $scope.simulationCompleted();
    }
};

SimulationChart.$inject = ['$scope', '$interval', '$timeout', 'HttpProxy', 'SimulationNotification'];