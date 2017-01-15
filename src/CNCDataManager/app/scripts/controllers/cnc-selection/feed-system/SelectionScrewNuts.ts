import * as angular from 'angular';
import SelectionTableHandler from '../../../services/SelectionTableHandler';
import DataStorage from '../../../services/DataStorage';
import SelectionNotification from '../../../services/SelectionNotification';
import { IScrewNutsScope, ISelectionAxis } from '../../../types/CncSelection';
import { IItem } from '../../../types/CncData';
import SelectionDetails from '../../../services/SelectionDetails';

export class SelectionScrewNuts {
    public constructor ($scope: IScrewNutsScope,
                        $state: angular.ui.IStateService,
                        $stateParams: angular.ui.IStateParamsService,
                        tableHandler: SelectionTableHandler,
                        dataStorage: DataStorage,
                        notifier: SelectionNotification,
                        detail: SelectionDetails)
    {
        $scope.ITEMNAME = 'solidballscrewnutpairs/';
        $scope.items = [];
        $scope.filtratedItems = [];
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
        $scope.selectItem = handler.selectItem;
        $scope.changePaginationSize = handler.changePaginationSize;
        $scope.changeFilter = handler.changeFilter('selectionScrewNutsFiltrateBy');
        $scope.goDetails = handler.goDetails;
        $scope.reset = handler.reset;

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

        $scope.state.axisID = $stateParams['axis'];
        //初始化
        tableHandler.Initialize($scope);
    }  
};

SelectionScrewNuts.$inject = ['$scope', '$state', '$stateParams', 'SelectionTableHandler', 
                            'DataStorage', 'SelectionNotification', 'SelectionDetails'];