import * as angular from 'angular';
import DataStorage from '../../../services/DataStorage';
import SelectionNotification from '../../../services/SelectionNotification';
import { ISelectionPartScope } from  '../../../types/CncSelection';

interface IMachineTypeScope extends ISelectionPartScope {
    data:{
        type: string;
        support: string;
        imgUrl: string;
    };
    selectType: (type: string, support: string, event: JQueryEventObject) => void;
}

export class MachineType {
    public constructor($scope: IMachineTypeScope, 
                       $state: angular.ui.IStateService, 
                       dataStorage: DataStorage,
                       notifier: SelectionNotification)
    {
        $scope.data = {type: null, support: null, imgUrl: null};
        $scope.selectType = (type: string, support: string, event: JQueryEventObject): void => {
            let img = event.currentTarget.firstElementChild;
            let imgUrl = img.getAttribute('src');
            $scope.data = { type: type, support: support, imgUrl: imgUrl };
        };
        $scope.reset = (): void => {
            $scope.data = { type: null, support: null, imgUrl: null};
        };
        $scope.nextStep = (): void => {
            dataStorage.setObject('MachineType', $scope.data);
            notifier.notifyChange(data => {
                let indentifiedValue = data.CNCMachine.IsShown; 
                data.CNCMachine = {
                    IsSelected: true,
                    TypeID: $scope.data.type,
                    SupportType: $scope.data.support,
                    IsShown: indentifiedValue,
                    ImgUrl: $scope.data.imgUrl,
                };
            });
            $state.go('.WorkingConditions');
        };
    }

};
//$scope也是依赖，也需要注入
MachineType.$inject = ['$scope','$state', 'DataStorage', 'SelectionNotification'];
