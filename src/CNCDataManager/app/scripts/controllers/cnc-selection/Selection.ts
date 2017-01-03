import * as angular from 'angular';

export class Selection {
    public constructor ($scope: angular.IScope & any, $stateParams: angular.ui.IStateParamsService)
    {
        $scope.axisID = $stateParams['axis'];
    }
 };

 Selection.$inject = ['$scope', '$stateParams'];