import * as angular from 'angular';
import SelectionTableHandler from '../../../services/SelectionTableHandler';
import DataStorage from '../../../services/DataStorage';
import SelectionNotification from '../../../services/SelectionNotification';
import SelectionDetails from '../../../services/SelectionDetails';
import { ICouplingsScope, ISelectionAxis } from '../../../types/CncSelection';
import { IItem } from '../../../types/CncData';

export class SelectionCouplings {
    public constructor ($scope: ICouplingsScope,
                        $state: angular.ui.IStateService,
                        $stateParams: angular.ui.IStateParamsService,
                        tableHandler: SelectionTableHandler,
                        dataStorage: DataStorage,
                        notifier: SelectionNotification,
                        detail: SelectionDetails)
    {
        $scope.ITEMNAME = 'elasticslvpincoups/';
        $scope.items = [];
        $scope.filtratedItems = [];
        $scope.state = {
            orderProperty: 'TypeID',
            paginationIndex: 1,
            paginationSize: 10,
            pageNumber: 1,
            paginationAllIndex: [1],
            colState: [true, false, false, false],
            axisID: null,
            typeOptions: [
                {name: "十字滑块式联轴器", url:"oldhamcoups/"},
                {name: "弹性柱销联轴器", url:"flexiblepinCoups/"},
                {name: "弹性套柱销联轴器", url:"elasticslvpincoups/"},
                {name: "带制动轮弹性套柱销联轴器", url:"bwelasticslvpincoups/"},
                {name: "凸缘联轴器", url:"flangecoups/"},
                {name: "齿式联轴器", url:"gearcoups/"},
                {name: "梅花形弹性联轴器", url:"plumshapedflexiblecoups/"},
                {name: '轮毂型联轴器', url: 'hubshapedcoups/'},
            ],
            currentType: null,
        };
        $scope.state.currentType = $scope.state.typeOptions[2];
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
        $scope.changePaginationIndex = handler.changePaginationIndex;
        $scope.changeFilter = handler.changeFilter('selectionCouplingsFiltrateBy');
        $scope.reset = handler.reset;

        $scope.changeCurrentType = (): void => {
            $scope.ITEMNAME = $scope.state.currentType.url;
            tableHandler.Initialize($scope);
        };

        $scope.goDetails = (item: IItem) => {
            detail.item = item;
            detail.typeID = item.TypeID;
            detail.component = $scope.state.currentType.name;
            $state.go('.Details', {id: item.TypeID });
        };

        $scope.nextStep = () =>　{
            let key = 'FeedSystem' + $scope.state.axisID + 'Couplings';
            dataStorage.setObject(key, $scope.data.selectedItem);
            notifier.notifyChange(data => {
                let feedSystem: ISelectionAxis = null;
                if($scope.state.axisID === 'X') feedSystem = data.FeedSystemX;
                else if($scope.state.axisID === 'Y') feedSystem = data.FeedSystemY;
                else feedSystem = data.FeedSystemZ; 
                let indentifiedValue = feedSystem.Couplings.IsShown; 
                feedSystem.Couplings = {
                    IsSelected: true,
                    TypeID: $scope.data.selectedTypeID,
                    Manufacturer: $scope.data.selectedItem.Manufacturer,
                    IsShown: indentifiedValue,
                    ImgUrl: './images/Mechanics/联轴器-表/联轴器.jpg',
                };
            });
            $state.go('selection.FeedSystem.ServoMotors');
        };


        //初始化
        $scope.state.axisID = $stateParams['axis'];
        tableHandler.Initialize($scope);
    }
};

SelectionCouplings.$inject = ['$scope', '$state', '$stateParams', 'SelectionTableHandler', 
                            'DataStorage', 'SelectionNotification', 'SelectionDetails'];