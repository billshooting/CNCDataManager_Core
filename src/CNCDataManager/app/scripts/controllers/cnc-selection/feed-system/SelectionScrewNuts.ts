import * as angular from 'angular';
import SelectionTableHandler from '../../../services/SelectionTableHandler';
import DataStorage from '../../../services/DataStorage';
import SelectionNotification from '../../../services/SelectionNotification';
import { IScrewNutsScope, ISelectionAxis } from '../../../types/CncSelection';

export class SelectionScrewNuts {
    public constructor ($scope: IScrewNutsScope,
                        $state: angular.ui.IStateService,
                        $stateParams: angular.ui.IStateParamsService,
                        tableHandler: SelectionTableHandler,
                        dataStorage: DataStorage,
                        notifier: SelectionNotification)
    {
        $scope.ITEMNAME = 'solidballscrewnutpairs/';
        $scope.items = [];
        $scope.state = {
            orderProperty: 'TypeID',
            paginationIndex: 1,
            paginationSize: 10,
            pageNumber: 1,
            paginationAllIndex: [1],
            colState: [false, false, false, false, false, false],
            axisID: null,
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

        $scope.nextStep = () =>　{
            let key = 'FeedSystem' + $scope.state.axisID + 'ScrewNuts';
            dataStorage.setObject(key, $scope.data.selectedItem);
            notifier.notifyChange(data => {
                let feedSystem: ISelectionAxis = null;
                if($scope.state.axisID === 'X') feedSystem = data.FeedSystemX;
                else if($scope.state.axisID === 'Y') feedSystem = data.FeedSystemY;
                else feedSystem = data.FeedSystemZ; 
                let indentifiedValue = feedSystem.ScrewNuts.IsShown; 
                feedSystem.ScrewNuts = {
                    IsSelected: true,
                    TypeID: $scope.data.selectedTypeID,
                    Manufacturer: $scope.data.selectedItem.Manufacturer,
                    IsShown: indentifiedValue,
                    ImgUrl: './images/Mechanics/滚珠丝杠-表/滚珠丝杠螺母副.jpg',
                };
            });
            $state.go('selection.FeedSystem.Bearings');
        };

        $scope.reset = () => {
            $scope.data = { selectedTypeID: null, selectedItem: null };
        };
        $scope.state.axisID = $stateParams['axis'];
        //初始化
        tableHandler.Initialize($scope);
    }  
};

SelectionScrewNuts.$inject = ['$scope', '$state', '$stateParams', 'SelectionTableHandler', 'DataStorage', 'SelectionNotification'];