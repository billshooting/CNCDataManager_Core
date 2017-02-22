import * as angular from 'angular';
import { ICNCSystemSelectionScope, ICNCSystemFilterConditions, IFilterCNCSystemFiltrate } from '../../../types/CncSelection';
import SelectionTableHandler from '../../../services/SelectionTableHandler';
import DataStorage from '../../../services/DataStorage';
import SelectionNotification from '../../../services/SelectionNotification';

export class CNCSystemType {
    public constructor($scope: ICNCSystemSelectionScope, 
                       tableHandler: SelectionTableHandler,
                       $state: angular.ui.IStateService,
                       dataStorage: DataStorage,
                       notifier: SelectionNotification,
                       $filter: angular.IFilterService)
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
            ManufacturerOptions: ['所有厂商', '华中数控', '广州数控', '沈阳高精' , '北京航天数控'],
            filtrateConditions: {
                Manufacturer: '所有厂商',
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
        $scope.selectItem = handler.selectItem;
        $scope.changePaginationSize = handler.changePaginationSize;
        $scope.changePaginationIndex = handler.changePaginationIndex;
        $scope.changeFilter = handler.changeFilter('cncSystemFiltrateBy');
        $scope.reset = handler.reset;

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

        tableHandler.Initialize($scope);
    }
};
CNCSystemType.$inject = ['$scope', 'SelectionTableHandler', '$state', 'DataStorage', 'SelectionNotification', '$filter'];