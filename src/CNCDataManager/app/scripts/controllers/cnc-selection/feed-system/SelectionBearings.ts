import * as angular from 'angular';
import SelectionTableHandler from '../../../services/SelectionTableHandler';
import DataStorage from '../../../services/DataStorage';
import SelectionNotification from '../../../services/SelectionNotification';
import { IBearingsScope, ISelectionAxis } from '../../../types/CncSelection';

export class SelectionBearings {
    public constructor ($scope: IBearingsScope,
                        $state: angular.ui.IStateService,
                        $stateParams: angular.ui.IStateParamsService,
                        tableHandler: SelectionTableHandler,
                        dataStorage: DataStorage,
                        notifier: SelectionNotification)
    {
        $scope.ITEMNAME = 'angcontactballbrgs/';
        $scope.items = [];
        $scope.state = {
            orderProperty: 'TypeID',
            paginationIndex: 1,
            paginationSize: 10,
            pageNumber: 1,
            paginationAllIndex: [1],
            colState: [true, true, true, false, false, false],
            axisID: null,
            bearingsTypeOptions: [
                { name: '角接触球轴承', type: 'ball', url: 'angcontactballbrgs'},
                { name: '深沟球轴承', type: 'ball', url: 'deepgrooveballbrgs' },
                { name: '圆锥滚子轴承', type: 'roller', url: 'taperedrollerbrgs'},
                { name: '圆柱滚子轴承', type: 'roller', url: 'cylinrollerbrgs'},
                { name: '调心滚子轴承', type: 'roller', url: 'alignrollerbrgs'},
                { name: '调心球轴承', type: 'ball', url: 'alignballbrgs'},
                { name: '滚珠丝杠支撑轴承', type: 'ball', url: 'ballleadscrewsptbrgs'},
                { name: '交叉圆锥滚子轴承', type: 'roller', url: 'xtaperedrollerbrgs'},
                { name: '双列圆柱滚子轴承', type: 'roller', url: 'doublerowcylinrollerbrgs'},
                { name: '双向推力角接触球轴承', type: 'ball', url: 'doublethrustangcontactballbrgs'},
                //{ name: '滚针轴承和推力滚子组合轴承', type: 'roller', url: 'needlerollerthrustrollerbrgs'},
            ],
            currentBearingsType: { name: '角接触球轴承', type: 'ball', url: 'angcontactballbrgs'},
        }
        $scope.data = {
            selectedTypeID: null,
            selectedItem: null
        };

        // 方法
        let handler = tableHandler.buildTableHandler($scope);
        $scope.changeOrderProperty = handler.changeOrderProperty;
        $scope.toggleCol = handler.toggleCol;
        $scope.selectItem = item => {
            $scope.data.selectedItem = item as any;
            $scope.data.selectedTypeID = item.TypeID;
        };

        $scope.changePaginationSize = () => {
            let size = $scope.state.paginationSize;
            let number = $scope.state.pageNumber;
            $scope.state.pageNumber = Math.ceil($scope.items.length / size);
            let newNumber = $scope.state.pageNumber;
            if(newNumber <= number) $scope.state.paginationAllIndex = $scope.state.paginationAllIndex.slice(0, newNumber);
            else{
                for(let i = number + 1; i <= newNumber; i++)
                {
                    $scope.state.paginationAllIndex.push(i);
                }
            }
            $scope.state.paginationIndex = 1;
        };

        $scope.changeBearingsType = (): void => {
            $scope.ITEMNAME = $scope.state.currentBearingsType.url;
            tableHandler.Initialize($scope);
        }

        $scope.nextStep = () =>　{
            let key = 'FeedSystem' + $scope.state.axisID + 'Bearings';
            dataStorage.setObject(key, $scope.data.selectedItem);
            notifier.notifyChange(data => {
                let feedSystem: ISelectionAxis = null;
                if($scope.state.axisID === 'X') feedSystem = data.FeedSystemX;
                else if($scope.state.axisID === 'Y') feedSystem = data.FeedSystemY;
                else feedSystem = data.FeedSystemZ; 
                let indentifiedValue = feedSystem.Bearings.IsShown; 
                feedSystem.Bearings = {
                    IsSelected: true,
                    TypeID: $scope.data.selectedTypeID,
                    Manufacturer: $scope.data.selectedItem.Manufacturer,
                    IsShown: indentifiedValue,
                    ImgUrl: './images/Mechanics/滚动轴承-表/滚动轴承.jpg',
                };
            });
            $state.go('selection.FeedSystem.Couplings');
        };

        $scope.reset = () => {
            $scope.data = { selectedTypeID: null, selectedItem: null };
        };

        //初始化
        $scope.state.axisID = $stateParams['axis'];
        tableHandler.Initialize($scope);
    }
};

SelectionBearings.$inject = ['$scope', '$state', '$stateParams', 'SelectionTableHandler', 'DataStorage', 'SelectionNotification'];