import * as angular from 'angular';
import { ISelectionTableScope } from '../types/CncSelection';

let Pagination: angular.IDirectiveFactory = (): angular.IDirective => {
    return {
        templateUrl: './views/directives/cnc-pagination.html',
        restrict: 'E',
        scope: true,
        link: ($scope: ISelectionTableScope): void => {
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
                $scope.state.paginationIndex = 1;
            };
            $scope.previousPage = () =>{ $scope.state.paginationIndex--; };
            $scope.nextPage = () => { $scope.state.paginationIndex++; };
            $scope.changePaginationIndex = (index: number) => {
                $scope.state.paginationIndex = index;
            }
        }
    };
};

export default Pagination;