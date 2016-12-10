import * as angular from 'angular';
import HttpProxy from './HttpProxy';
import Users from './Users';

export default function registerServices(app: angular.IModule): void {
    app.service('HttpProxy', HttpProxy);
    app.service('Users', Users);
}