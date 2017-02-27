import * as angular from 'angular';
import MessageTips from '../services/MessageTips';

interface IMsgDialogScope extends angular.IScope {
    isLoading: boolean;
    isError: boolean;
    hideError: () => void;
    hideLoading: () => void;
}

let MsgDialog: angular.IDirectiveFactory = (messageService: MessageTips): angular.IDirective => {
    return {
        templateUrl: './views/directives/message-tips.html',
        restrict: 'E',
        scope: true,
        link: ($scope: IMsgDialogScope, ele: Element, attr: Attr) => {
            $scope.isLoading = false;
            $scope.isError = false;
            $scope.hideError = () => {
                angular.element('#update-msg').text('');
                angular.element('#error-msg').text('');
                $scope.isError = false;
            };
            $scope.hideLoading = () => {
                angular.element('#update-msg').text('');
                angular.element('#error-msg').text('');
                $scope.isLoading = false;
            };
            messageService.hideError = () => {
                angular.element('#update-msg').text('');
                angular.element('#error-msg').text('');
                $scope.isError = false;
            };
            messageService.showError = (msg: string) => {
                $scope.isLoading = false;
                angular.element('#errorMsg').text(msg);
                $scope.isError = true;
            };
            messageService.showLoading = () => { 
                $scope.isError = false;
                $scope.isLoading = true; 
            };
            messageService.hideLoading = () => {
                angular.element('#update-msg').text('');
                angular.element('#error-msg').text('');
                $scope.isLoading = false;
            };
            messageService.showUpdate = (i, count, msg) => {
                $scope.isError = false;
                let message = i.toString() + '/' + count.toString() + ' success';
                angular.element('#update-msg').text(message);
                if (msg) {
                    let _errorMsg = document.querySelector('#error-msg');
                    angular.element(_errorMsg).text(msg);
                }
            };
            messageService.showMsg = (msg: string) => {
                $scope.isError = false;
                angular.element('#error-msg').text(msg);
                $scope.isLoading = true;
            }
        }
    };
};

MsgDialog.$inject = ['MessageTips'];
export default MsgDialog;