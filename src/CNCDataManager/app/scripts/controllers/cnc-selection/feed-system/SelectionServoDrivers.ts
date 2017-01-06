import * as angular from 'angular';
import SelectionTableHandler from '../../../services/SelectionTableHandler';
import DataStorage from '../../../services/DataStorage';
import SelectionNotification from '../../../services/SelectionNotification';
import { IServoDriverScope, ISelectionAxis } from '../../../types/CncSelection';

export class SelectionServoDrivers {
    public constructor ($scope: IServoDriverScope,
                        $state: angular.ui.IStateService,
                        $stateParams: angular.ui.IStateParamsService,
                        tableHandler: SelectionTableHandler,
                        dataStorage: DataStorage,
                        notifier: SelectionNotification)
    {
        $scope.ITEMNAME = 'pmsrvmotordrivers/';
        $scope.items = [];
        $scope.state = {
            orderProperty: 'TypeID',
            paginationIndex: 1,
            paginationSize: 10,
            pageNumber: 1,
            paginationAllIndex: [1],
            axisID: null,
            manufacturerOptions: ["华中数控","广州数控","沈阳高精","北京航天数控"],
            currentManufacturer: null,
        };
        $scope.state.currentManufacturer = $scope.state.manufacturerOptions[0];
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

        $scope.changeCurrentType = (): void => {
            $scope.ITEMNAME = $scope.state.currentManufacturer;
            tableHandler.Initialize($scope);
        }

        $scope.nextStep = () =>　{
            let key = 'FeedSystem' + $scope.state.axisID + 'ServoDrivers';
            dataStorage.setObject(key, $scope.data.selectedItem);
            notifier.notifyChange(data => {
                let feedSystem: ISelectionAxis = null;
                if($scope.state.axisID === 'X') feedSystem = data.FeedSystemX;
                else if($scope.state.axisID === 'Y') feedSystem = data.FeedSystemY;
                else feedSystem = data.FeedSystemZ; 
                let indentifiedValue = feedSystem.ServoDriver.IsShown; 
                feedSystem.ServoDriver = {
                    IsSelected: true,
                    TypeID: $scope.data.selectedTypeID,
                    Manufacturer: $scope.data.selectedItem.Manufacturer,
                    IsShown: indentifiedValue,
                    ImgUrl: './images/Motors/伺服电机.jpg',
                };
            });
            if($scope.state.axisID === 'X') $state.go('selection.FeedSystem.Guides', {axis: 'Y'});
            else if ($scope.state.axisID === 'Y') $state.go('selection.FeedSystem.Guides', {axis: 'Z'});
            else if ($scope.state.axisID === 'Z'){
                alert('请转至侧边栏查看所选组件');
            }
            
        };

        $scope.reset = () => {
            $scope.data = { selectedTypeID: null, selectedItem: null };
        };

        //初始化
        $scope.state.axisID = $stateParams['axis'];
        tableHandler.Initialize($scope);
    }
};

SelectionServoDrivers.$inject = ['$scope', '$state', '$stateParams', 'SelectionTableHandler', 'DataStorage', 'SelectionNotification'];