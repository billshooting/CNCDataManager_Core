import * as angular from 'angular';
import Highcharts from 'highcharts';
import HighchartsExporting from 'highchart-exporting';
import { ISimulationChartScope, IReportResult } from '../../types/CncSimulation';
import { ISelectionData } from '../../types/CncSelection';
import HttpProxy from '../../services/HttpProxy';
import SimulationNotification from '../../services/SimulationNotification';
import SelectionNotification from '../../services/SelectionNotification';

HighchartsExporting(Highcharts);
export default class SimulationChart
{
    public constructor($scope: ISimulationChartScope,
                       $interval: angular.IIntervalService,
                       $timeout: angular.ITimeoutService,
                       httpProxy: HttpProxy,
                       simuNotifier: SimulationNotification,
                       selecNotifier: SelectionNotification) 
    {
        /** 从localStorage 取组件数据 */
        let getComponentsFromData = function(data: IReportResult) {
            let results: { typeID: string; manufacturer: string; name: string}[] = [];
            let enToZh: any = { 
                Guide: '导轨', Ballscrew: '滚珠丝杠', Bearings: '轴承',
                Coupling: '联轴器', ServoMotor: '伺服电机', Driver: '伺服驱动器',
            };
            for(let key in data.FeedSystemX){
                if(enToZh[key]){
                    let componentName = 'X轴' + enToZh[key];
                    results.push({
                        typeID: data.FeedSystemX[key].TypeID,
                        manufacturer: data.FeedSystemX[key].Manufacturer,
                        name: componentName,
                    });
                }
            }
            for(let key in data.FeedSystemY){
                if(enToZh[key]){
                    let componentName = 'Y轴' + enToZh[key];
                    results.push({
                        typeID: data.FeedSystemX[key].TypeID,
                        manufacturer: data.FeedSystemX[key].Manufacturer,
                        name: componentName,
                    });
                }
            }
            for(let key in data.FeedSystemZ){
                if(enToZh[key]){
                    let componentName = 'Z轴' + enToZh[key];
                    results.push({
                        typeID: data.FeedSystemX[key].TypeID,
                        manufacturer: data.FeedSystemX[key].Manufacturer,
                        name: componentName,
                    });
                }
            }
            for(let i = 0; i < 10; i++){
                results.push({ typeID: null, manufacturer: null, name: null });
            }
            return results;
        };
        /** 得到HighChart的option */
        let getChartOption = function(simulationType: string): Highcharts.Options {
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
                    chartOptions.title.text = '位移-时间仿真结果';
                    (chartOptions.yAxis as any).title.text = '位移 (m)'
                    chartOptions.tooltip.valueSuffix = 'm';
                    chartOptions.series[0].name = 'x-t';
                    break;
                }
                case 'velocity':{
                    chartOptions.title.text = '速度-时间仿真结果';
                    (chartOptions.yAxis as any).title.text = '速度 (m/s)'
                    chartOptions.tooltip.valueSuffix = 'm/s';
                    chartOptions.series[0].name = 'v-t';
                    break;
                }
                case 'acceleration':{
                    chartOptions.title.text = '加速度-时间仿真结果';
                    (chartOptions.yAxis as any).title.text = '加速度 (m/s^2)'
                    chartOptions.tooltip.valueSuffix = 'm/s^2';
                    chartOptions.series[0].name = 'a-t';
                    break;
                }
                default: break;
            }
            return chartOptions;
        };
        /** 根据id和data类型画图 */
        let plotData = function(containerID: string, simulationType: string, isDownload: boolean = false): void {
            let simuTypeStr: string = null;
            let thisData = simuNotifier.plotData[simulationType];
            let chartOptions = getChartOption(simulationType);
            let chart: Highcharts.ChartObject = null;
            switch(simulationType){
                case 'displacement':{
                    simuTypeStr = 'X';
                    break;
                }
                case 'velocity':{
                    simuTypeStr = 'v';
                    break;
                }
                case 'acceleration':{
                    simuTypeStr = 'a';
                    break;
                }
                default: break;
            }
            if(thisData) {
                chartOptions.series[0].data = thisData;
                $timeout(() => {
                    chart = Highcharts.chart(containerID, chartOptions);
                    /** 如果需要上传 再下载*/
                    if(isDownload) {
                        let svg: string = chart.getSVG();
                        let url = httpProxy.getRelativeUrl('Report/UploadSvg', { fileID: simuNotifier.fileID });
                        httpProxy.http(url)
                        .post({
                            FileName: simuTypeStr + '-t',
                            Type: 'image/png',
                            Width: 800,
                            SvgStr: svg,
                        })
                        .catch(reponse => { 
                            let error: string = reponse.statusText || '网络连接问题';
                            alert('由于' + error + '导致仿真图片上传失败，如果需要下载文档，请再次点击文档预览重试');
                        });
                    }
                }, 300);
            }
            else {
                httpProxy.http('Simulation/SimulationResults').get({
                    fileID: simuNotifier.fileID,
                    type: simuTypeStr,
                }).then(response => {
                    /** 将string类型的数据转换为number */
                    let stringData = response.data.data as [string, string][];
                    simuNotifier.plotData[simulationType] = stringData.map(twoEleArray => {
                        return <[number, number]>[parseFloat(twoEleArray[0]), parseFloat(twoEleArray[1])];
                    });
                    chartOptions.series[0].data = simuNotifier.plotData[simulationType];
                    $timeout(() => {
                        chart = Highcharts.chart(containerID, chartOptions);
                        if(isDownload) {
                            let svg: string = chart.getSVG();
                            let url = httpProxy.getRelativeUrl('Report/UploadSvg', { fileID: simuNotifier.fileID });
                            httpProxy.http(url)
                            .post({
                                FileName: simuTypeStr + '-t',
                                Type: 'image/png',
                                Width: 800,
                                SvgStr: svg,
                            })
                            .catch(reponse => { 
                                let error: string = reponse.statusText || '网络连接问题';
                                alert('由于' + error + '导致仿真图片上传失败，如果需要下载文档，请再次点击文档预览重试');
                            });
                        }
                    }, 300);                   
                }, response => {
                    if(response.status === 404) console.log('incorrected fileID or data type.');
                    else console.log(response.status + ' ' + response.statusText);
                });
            }
        };

        $scope.simulationStarted = () => {
            $scope.state.isStarted = true;
            $scope.state.isCompleted = false;
            $scope.state.progress = 0;
        }

        $scope.simulationCompleted = (): void => {
            $scope.state.isStarted = false;
            $scope.state.isCompleted = true;
            $scope.state.progress = 100;
            $scope.state.stateText = '仿真结束';            
            $interval.cancel(intervalID);
            $scope.showData('displacement');
        };

        $scope.simulationFailed = (errorMsg: string): void => {
            $scope.state.isStarted = false;
            $scope.state.isCompleted = false;
            $scope.state.progress = 0;
            $scope.state.stateText = errorMsg;
            $interval.cancel(intervalID);
        };

        $scope.showData = (simulationType: string): void => {
            let containerID = simulationType + '-chart';
            plotData(containerID, simulationType);
        };

        $scope.reportToggle = () => { 
            if($scope.report.isShown === false)
            {
                let data = selecNotifier.getReportData();
                $scope.report.isShown = true; 
                $scope.report.CNCMachine = data.MachineType;
                $scope.report.CNCSystem = data.NCSystem;
                $scope.report.FeedSystemX = data.FeedSystemX;
                $scope.report.FeedSystemY = data.FeedSystemY;
                $scope.report.FeedSystemZ = data.FeedSystemZ;
                $scope.report.Spindle = data.Spindle;
                $scope.report.Components = getComponentsFromData(data);
                plotData('report-x-chart', 'displacement', true);
                plotData('report-v-chart', 'velocity', true);
                plotData('report-a-chart', 'acceleration', true);
            }
            else {
                $scope.report.isShown = false;
            }
        };

        $scope.reportDownload = () => {
            let data = selecNotifier.getReportData();
            let relativeUtl = httpProxy.getRelativeUrl('Report/GenerateDocument', { fileID: simuNotifier.fileID });
            httpProxy.http(relativeUtl)
            .post(data)
            .then(response => {
                let downloadUrl = httpProxy.getUrl('Report/DownLoad', { fileID: simuNotifier.fileID });
                window.open(downloadUrl, '_blank');
            }, response => { alert('生成报表失败') });
        }

        $scope.stateInit = () => {
            $scope.state = {
                isCompleted: false,
                isStarted: false,
                progress: 0,
                stateText: '尚未开始仿真',
            };
        };

        $scope.reportInit = () => {
            $scope.report = {
                isShown: false,
            };
        };
        

        /** 初始化 */
        /** 注册通知 */
        simuNotifier.registerNotification($scope);
        var intervalID: angular.IPromise<any> = null;
        $scope.stateInit();
        $scope.reportInit();

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
                $scope.state.progress += 0.3;               
            }
        }, 500);
        /** 如果已经有数据了 */
        if(simuNotifier.fileID && simuNotifier.fileID.length === 15) $scope.simulationCompleted();
    }
};

SimulationChart.$inject = ['$scope', '$interval', '$timeout', 'HttpProxy', 
                        'SimulationNotification', 'SelectionNotification'];