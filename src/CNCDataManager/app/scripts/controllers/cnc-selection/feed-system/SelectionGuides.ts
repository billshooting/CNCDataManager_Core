import * as angular from 'angular';
import SelectionTableHandler from '../../../services/SelectionTableHandler';
import DataStorage from '../../../services/DataStorage';
import SelectionNotification from '../../../services/SelectionNotification';
import { IGuideScope, ISelectionAxis } from '../../../types/CncSelection';
import { IItem } from '../../../types/CncData';
import SelectionDetails from '../../../services/SelectionDetails';

export class SelectionGuides {
    public constructor ($scope: IGuideScope,
                        $state: angular.ui.IStateService,
                        $stateParams: angular.ui.IStateParamsService,
                        tableHandler: SelectionTableHandler,
                        dataStorage: DataStorage,
                        notifier: SelectionNotification,
                        detail: SelectionDetails)
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
        $scope.selectItem = handler.selectItem;
        $scope.changePaginationSize = handler.changePaginationSize;
        
        $scope.goDetails = (item: IItem) => {
            detail.item = item;
            detail.typeID = item.TypeID;
            $state.go('.Details', {id: item.TypeID});
        };

        $scope.nextStep = () =>　{
            let key = 'FeedSystem' + $scope.state.axisID + 'Guides';
            dataStorage.setObject(key, $scope.data.selectedItem);
            notifier.notifyChange(data => {
                let feedSystem: ISelectionAxis = null;
                if($scope.state.axisID === 'X') feedSystem = data.FeedSystemX;
                else if($scope.state.axisID === 'Y') feedSystem = data.FeedSystemY;
                else feedSystem = data.FeedSystemZ; 
                let indentifiedValue = feedSystem.Guide.IsShown; 
                feedSystem.Guide = {
                    IsSelected: true,
                    TypeID: $scope.data.selectedTypeID,
                    Manufacturer: $scope.data.selectedItem.Manufacturer,
                    IsShown: indentifiedValue,
                    ImgUrl: './images/Mechanics/导轨-表/Guide.jpg',
                };
            });
            $state.go('selection.FeedSystem.ScrewNuts');
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
SelectionGuides.$inject = ['$scope', '$state', '$stateParams', 'SelectionTableHandler', 
                            'DataStorage', 'SelectionNotification', 'SelectionDetails'];