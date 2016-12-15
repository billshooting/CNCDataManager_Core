import * as angular from 'angular';
import MessageTips from '../../services/MessageTips';

interface IMessageScope extends angular.IScope {
    isLoading: boolean;
    isError: boolean;
    hideError: () => void;
    hideLoading: () => void;
}

export class CNCData {
    public constructor(message: MessageTips, $scope: IMessageScope)
    {
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
        message.hideError = () => {
            angular.element('#update-msg').text('');
            angular.element('#error-msg').text('');
            $scope.isError = false;
        };
        message.showError = (msg: string) => {
            angular.element('#errorMsg').text(msg);
            $scope.isError = true;
        };
        message.showLoading = () => { $scope.isLoading = true; };
        message.hideLoading = () => {
            angular.element('#update-msg').text('');
            angular.element('#error-msg').text('');
            $scope.isLoading = false;
        };
        message.showUpdate = (i, count, msg) => {
            console.log('showupdate called');
            let message = i.toString() + '/' + count.toString() + ' success';
            angular.element('#update-msg').text(message);
            if (msg) {
                let _errorMsg = document.querySelector('#error-msg');
                angular.element(_errorMsg).text(msg);
            }
        };
    }
};

CNCData.$inject = ['MessageTips', '$scope'];