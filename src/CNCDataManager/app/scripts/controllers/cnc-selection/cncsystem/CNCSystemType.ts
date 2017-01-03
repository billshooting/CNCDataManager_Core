import * as angular from 'angular';
import { ICNCSystemSelectionScope, ICNCSystemFilterConditions } from '../../../types/CncSelection';
import SelectionTableHandler from '../../../services/SelectionTableHandler';
import DataStroage from '../../../services/DataStroage';

export class CNCSystemType {
    public constructor($scope: ICNCSystemSelectionScope, 
                       tableHandler: SelectionTableHandler,
                       $state: angular.ui.IStateService,
                       dataStroage: DataStroage)
    {
        // 属性
        $scope.ITEMNAME = 'ncsystems/';
        $scope.items = [];
        $scope.state = {
            orderProperty: 'TypeID',
            paginationIndex: 1,
            paginationSize: 20,
            filtrateConditions: {
                Manufacturer: null,
                SupportChannels: 1,
                MaxNumberOfFeedShafts: 1,
                SupportMachineType: dataStroage.getObject('MachineType').support
            }
        };
        $scope.data = {
            selectedTypeID: null
        };

        // 方法
        let handler = tableHandler.buildTableHandler($scope);
        $scope.changeOrderProperty = handler.changeOrderProperty;
        $scope.selectItem = item => {
            $scope.data.selectedTypeID = item.TypeID;
        };

        tableHandler.Initialize($scope);
    }
};
CNCSystemType.$inject = ['$scope', 'SelectionTableHandler'];