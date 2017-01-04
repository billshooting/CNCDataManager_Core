import * as angular from 'angular';

export class FeedSystemLeftSide {
    public constructor($scope: angular.IScope & any, $stateParams: angular.ui.IStateParamsService)
    {
        $scope.$watch(() => { return $stateParams['axis']; },
                      (newValue: string) => { $scope.axisID = newValue; });
    }
};

FeedSystemLeftSide.$inject = ['$scope', '$stateParams'];