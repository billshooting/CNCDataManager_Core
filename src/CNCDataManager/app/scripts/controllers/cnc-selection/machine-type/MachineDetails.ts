import * as angular from 'angular';
import DataStroage from '../../../services/DataStroage';
import SelectionNotification from '../../../services/SelectionNotification';
import { ISelectionPartScope } from  '../../../types/CncSelection';

interface IMachineDetailsScope extends ISelectionPartScope {
    data:{
        cuttingCondition: any;
        productCondition: any;
    };
    loadCharacterOptions: string[];
}

export class MachineDetails {
    public constructor($scope: IMachineDetailsScope,
                       $state: angular.ui.IStateService,
                       dataStroage: DataStroage,
                       notifier: SelectionNotification)
    {
        $scope.reset = (): void => {
            $scope.loadCharacterOptions = ["无冲击","轻微冲击","有冲击或振动"];
            $scope.data = {
                cuttingCondition: [
                {
                    lengthwaysForce:2000,
                    verticalForce:1200,
                    feedSpeed:0.6,
                    timeScale:10,
                },
                {
                    lengthwaysForce:1000,
                    verticalForce:500,
                    feedSpeed:0.8,
                    timeScale:30,
                },
                {
                    lengthwaysForce:500,
                    verticalForce:200,
                    feedSpeed:1,
                    timeScale:50,
                },
                {
                    lengthwaysForce:0,
                    verticalForce:0,
                    feedSpeed:15,
                    timeScale:10,
                }],
                productCondition: {
                    maxFeedSpeed:15,
                    tableTravel:1000,
                    productMaxMass:300,
                    tableMass:100,
                    productMaxHeight:400,
                    loadCharacter:"无冲击",
                    productMaxLength:400,
                    feedAcceleration:1,
                    productMaxWidth:400,
                    spindleBoxMass:100,
                    tableLength:1200,
                    productStiffness:1150000000,
                }
            };
        };
        $scope.nextStep = (): void => {
            dataStroage.setObject('MachineWorkingConditions', $scope.data);
            notifier.notifyChange(data => {});
            $state.go('selection.CNCSystem');
        };
        $scope.reset();
    }

};
MachineDetails.$inject = ['$scope','$state', 'DataStroage', 'SelectionNotification'];