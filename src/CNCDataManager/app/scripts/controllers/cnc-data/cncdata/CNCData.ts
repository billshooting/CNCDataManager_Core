import * as angular from 'angular';
import MessageTips from '../../../services/MessageTips';

interface IMessageScope extends angular.IScope {
    isLoading: boolean;
    isError: boolean;
    hideError: () => void;
    hideLoading: () => void;
}

export class CNCData {
    public constructor(message: MessageTips, $scope: IMessageScope)
    {
    }
};

CNCData.$inject = ['MessageTips', '$scope'];