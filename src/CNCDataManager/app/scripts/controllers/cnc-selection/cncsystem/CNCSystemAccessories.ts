import * as angular from 'angular';
import { ISelectionTableScope } from '../../../types/CncSelection';

export class CNCSystemAccessories {
    public constructor ($scope: ISelectionTableScope,
                        $state: angular.ui.IStateService)
    {
        $scope.nextStep = () => {
            $state.go('selection.FeedSystem', {axis: 'X'});
        };
        $scope.reset = () => {

        };
    }
};

CNCSystemAccessories.$inject = ['$scope', '$state'];