import * as angular from 'angular';
import { ICNCSystemSelectionScope, ICNCSystemFilterConditions } from '../../../types/CncSelection';
import SelectionTableHandler from '../../../services/SelectionTableHandler';
import DataStorage from '../../../services/DataStorage';
import SelectionNotification from '../../../services/SelectionNotification';

export class CNCSystemType {
    public constructor($scope: ICNCSystemSelectionScope, 
                       tableHandler: SelectionTableHandler,
                       $state: angular.ui.IStateService,
                       dataStorage: DataStorage,
                       notifier: SelectionNotification)
    {
        // 属性
        $scope.ITEMNAME = 'ncsystems/';
        $scope.items = [];
        $scope.filtratedItems = [];
        $scope.state = {
            orderProperty: 'TypeID',
            paginationIndex: 1,
            paginationSize: 10,
            pageNumber: 1,
            paginationAllIndex: [1],
            ManufacturerOptions: ["华中数控","广州数控","沈阳高精","北京航天数控"],
            filtrateConditions: {
                Manufacturer: null,
                SupportChannels: 1,
                MaxNumberOfFeedShafts: 1,
                SupportMachineType: dataStorage.getObject('MachineType').support,
            }
        };
        $scope.data = {
            selectedItem: null,
            selectedTypeID: null
        };

        // 方法
        let handler = tableHandler.buildTableHandler($scope);
        $scope.changeOrderProperty = handler.changeOrderProperty;
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

        tableHandler.Initialize($scope);
    }
};
CNCSystemType.$inject = ['$scope', 'SelectionTableHandler', '$state', 'DataStorage', 'SelectionNotification'];