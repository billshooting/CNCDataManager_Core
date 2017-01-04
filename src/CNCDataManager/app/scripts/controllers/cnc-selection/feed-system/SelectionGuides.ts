import * as angular from 'angular';
import SelectionTableHandler from '../../../services/SelectionTableHandler';
import DataStorage from '../../../services/DataStorage';
import SelectionNotification from '../../../services/SelectionNotification';
import { IGuideScope } from '../../../types/CncSelection';

export class SelectionGuides {
    public constructor ($scope: IGuideScope,
                        $state: angular.ui.IStateService,
                        $stateParams: angular.ui.IStateParamsService,
                        tableHandler: SelectionTableHandler,
                        dataStorage: DataStorage,
                        notifier: SelectionNotification)
    {
        $scope.ITEMNAME = 'linerollingguides/';
        $scope.items = [];
        $scope.state = {
            orderProperty: 'TypeID',
            paginationIndex: 1,
            paginationSize: 10,
            pageNumber: 1,
            paginationAllIndex: [1],
            colState: [true, false, false],
            axisID: null,
            imgUrl: null,
        };
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

        $scope.nextStep = () =>　{
            dataStorage.setObject('CNCSystem', $scope.data.selectedItem);
            notifier.notifyChange(data => {
                let indentifiedValue = data.CNCSystem.IsShown; 
                data.CNCSystem = {
                    IsSelected: true,
                    TypeID: $scope.data.selectedTypeID,
                    Manufacturer: $scope.data.selectedItem.Manufacturer,
                    IsShown: indentifiedValue,
                    ImgUrl: './images/CNC/CNCSystem/' + $scope.data.selectedTypeID + '.jpg',
                };
            });
            $state.go('.Accessories');
        };

        $scope.reset = () => {
            $scope.data = { selectedTypeID: null, selectedItem: null };
        };

        //初始化
        $scope.$watch(() => { return $stateParams['axis']; },
                      (newValue: string) => { 
                          $scope.state.axisID = newValue;
                          $scope.state.imgUrl = './images/Mechanics/导轨-表/立铣' + newValue + '轴导轨.jpg'; 
                        });
        tableHandler.Initialize($scope);
    }  
};
SelectionGuides.$inject = ['$scope', '$state', '$stateParams', 'SelectionTableHandler', 'DataStorage', 'SelectionNotification'];