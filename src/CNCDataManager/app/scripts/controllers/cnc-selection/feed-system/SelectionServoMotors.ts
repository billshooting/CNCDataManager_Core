import * as angular from 'angular';
import SelectionTableHandler from '../../../services/SelectionTableHandler';
import DataStorage from '../../../services/DataStorage';
import SelectionNotification from '../../../services/SelectionNotification';
import { IServoMotorScope, ISelectionAxis } from '../../../types/CncSelection';
import { IItem } from '../../../types/CncData';
import SelectionDetails from '../../../services/SelectionDetails';

export class SelectionServoMotors {
    public constructor ($scope: IServoMotorScope,
                        $state: angular.ui.IStateService,
                        $stateParams: angular.ui.IStateParamsService,
                        tableHandler: SelectionTableHandler,
                        dataStorage: DataStorage,
                        notifier: SelectionNotification,
                        detail: SelectionDetails)
    {
        $scope.ITEMNAME = 'pmsrvmotorparas/';
        $scope.items = [];
        $scope.filtratedItems = [];
        $scope.state = {
            orderProperty: 'TypeID',
            paginationIndex: 1,
            paginationSize: 10,
            pageNumber: 1,
            paginationAllIndex: [1],
            colState: [false, false, false, false],
            axisID: null,
            manufacturerOptions: ["全部厂商", "华大","广数","登奇","光洋"],
            voltageOptions: [{ name: '全部电压', id: 0 }, { name: '低压220V', id: 220 }, { name: '高压380V', id: 380 }],
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
        $scope.selectItem = handler.selectItem;
        $scope.changePaginationSize = handler.changePaginationSize;
        $scope.changePaginationIndex = handler.changePaginationIndex;
        $scope.changeFilter = handler.changeFilter('selectionServoMotorFiltrateBy');
        $scope.goDetails = handler.goDetails;
        $scope.reset = handler.reset;

        $scope.nextStep = () =>　{
            let key = 'FeedSystem' + $scope.state.axisID + 'ServoMotors';
            dataStorage.setObject(key, $scope.data.selectedItem);
            notifier.notifyChange(data => {
                let feedSystem: ISelectionAxis = null;
                if($scope.state.axisID === 'X') feedSystem = data.FeedSystemX;
                else if($scope.state.axisID === 'Y') feedSystem = data.FeedSystemY;
                else feedSystem = data.FeedSystemZ; 
                let indentifiedValue = feedSystem.ServoMotor.IsShown; 
                feedSystem.ServoMotor = {
                    IsSelected: true,
                    TypeID: $scope.data.selectedTypeID,
                    Manufacturer: $scope.data.selectedItem.Manufacturer,
                    IsShown: indentifiedValue,
                    ImgUrl: './images/Motors/伺服电机.jpg',
                };
            });
            $state.go('selection.FeedSystem.ServoDrivers');
        };

        //初始化
        $scope.state.axisID = $stateParams['axis'];
        tableHandler.Initialize($scope);
    }
};

SelectionServoMotors.$inject = ['$scope', '$state', '$stateParams', 'SelectionTableHandler', 
                            'DataStorage', 'SelectionNotification', 'SelectionDetails'];