let DataListModal: angular.IDirectiveFactory = (): angular.IDirective => 
{
    return {
        templateUrl: './views/directives/datalist-modal.html',
        restrict: 'E',
        scope: true
    };
};

export default DataListModal;