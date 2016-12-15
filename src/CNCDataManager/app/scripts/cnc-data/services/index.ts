import * as angular from 'angular';
import HttpProxy from './HttpProxy';
import User from './User';
import MessageTips from './MessageTips';
import TableHandler from './TableHandler';

export default function registerServices(app: angular.IModule): void {
    app.service('HttpProxy', HttpProxy);
    app.service('User', User);
    app.service('MessageTips', MessageTips);
    app.service('TableHandler', TableHandler);
};
