import * as angular from 'angular';
import SelectionDetails from '../../../services/SelectionDetails';

export class ComponentDetails {
    public constructor($scope: angular.IScope & any, 
                       details: SelectionDetails,
                       $stateParams: angular.ui.IStateParamsService)
    {
        $scope.item = details.item;
        $scope.state = { 
            axisID: $stateParams['axis'],
            imgUrl: null,
        };
        if(details.component)
        {
            switch(details.component)
            {
                case '角接触球轴承':{
                    $scope.state.imgUrl = './images/Mechanics/滚动轴承-表/1-角接触球轴承-表.jpg';
                    break;
                }
                case '深沟球轴承': {
                    $scope.state.imgUrl = './images/Mechanics/滚动轴承-表/2-深沟球轴承-表.jpg';
                    break;
                }
                case '圆锥滚子轴承': {
                    $scope.state.imgUrl = './images/Mechanics/滚动轴承-表/3-圆锥滚子轴承-表.jpg';
                    break;
                }
                case '圆柱滚子轴承': {
                    $scope.state.imgUrl = './images/Mechanics/滚动轴承-表/4-圆柱滚子轴承1-表.jpg';
                    break;
                }
                case '调心滚子轴承': {
                    $scope.state.imgUrl = './images/Mechanics/滚动轴承-表/5-调心滚子轴承-表.jpg';
                    break;
                }
                case '调心球轴承': {
                    $scope.state.imgUrl = './images/Mechanics/滚动轴承-表/6-调心球轴承-表.jpg';
                    break;
                }
                case '滚珠丝杠支撑轴承': {
                    $scope.state.imgUrl = './images/Mechanics/滚动轴承-表/7-滚珠丝杠支撑轴承-表.jpg';
                    break;
                }
                case '交叉圆锥滚子轴承': {
                    $scope.state.imgUrl = './images/Mechanics/滚动轴承-表/6-调心球轴承-表.jpg';
                    break;
                }
                case '双列圆柱滚子轴承': {
                    $scope.state.imgUrl = './images/Mechanics/滚动轴承-表/7-滚珠丝杠支撑轴承-表.jpg';
                    break;
                }
                case '双向推力角接触球轴承': {
                    $scope.state.imgUrl = './images/Mechanics/滚动轴承-表/8-双向推力角接触球轴承.jpg';
                    break;
                }
                case '十字滑块式联轴器': {
                    $scope.state.imgUrl = './images/Mechanics/联轴器-表/2-十字滑块联轴器-表.jpg';
                    break;
                }
                case '弹性柱销联轴器': {
                    $scope.state.imgUrl = './images/Mechanics/联轴器-表/6-弹性柱销联轴器-表.jpg';
                    break;
                }
                case '弹性套柱销联轴器': {
                    $scope.state.imgUrl = './images/Mechanics/联轴器-表/5-弹性套注销联轴器-表.jpg';
                    break;
                }
                case '带制动轮弹性套柱销联轴器': {
                    $scope.state.imgUrl = './images/Mechanics/联轴器-表/4-带制动轮弹性套柱销联轴器-表.jpg';
                    break;
                }
                case '凸缘联轴器': {
                    $scope.state.imgUrl = './images/Mechanics/联轴器-表/1-凸缘式联轴器-表.jpg';
                    break;
                }
                case '齿式联轴器': {
                    $scope.state.imgUrl = './images/Mechanics/联轴器-表/3-齿式联轴器-表.jpg';
                    break;
                }
                case '梅花形弹性联轴器': {
                    $scope.state.imgUrl = './images/Mechanics/联轴器-表/7-梅花形弹性联轴器-表.jpg';
                    break;
                }
                default: break;
            }
        }

        
        $scope.back = () => { history.back(); };
    }
};

ComponentDetails.$inject = ['$scope', 'SelectionDetails', '$stateParams'];