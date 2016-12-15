import * as angular from 'angular';
import MessageTips from '../services/MessageTips';

interface IMsgDialogScope extends angular.IScope {
    isLoading: boolean;
    isError: boolean;
}

let MsgDialog: angular.IDirectiveFactory = (messageService: MessageTips): angular.IDirective => {
    return {
        templateUrl: './views/cnc-data/directives/message-tips.html',
        restrict: 'E',
        scope: true,
        link: (scope: IMsgDialogScope, ele: Element, attr: Attr) => {
            scope.isLoading = false;
            scope.isError = false;
            messageService.hideError = () => {
                angular.element('#update-msg').text('');
                angular.element('#error-msg').text('');
                scope.isError = false;
            };
            messageService.showError = (msg: string) => {
                angular.element('#errorMsg').text(msg);
                scope.isError = true;
            };
            messageService.showLoading = () => { scope.isLoading = true; };
            messageService.hideLoading = () => {
                angular.element('#update-msg').text('');
                angular.element('#error-msg').text('');
                scope.isLoading = false;
            };
            messageService.showUpdate = (i, count, msg) => {
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
};

MsgDialog.$inject = ['MessageTips'];
export default MsgDialog;