import * as angular from 'angular';
import HttpProxy from './HttpProxy';
import User from './User';
import MessageTips from './MessageTips';
import TableHandler from './TableHandler';
import SelectionNotification from './SelectionNotification';
import DataStorage from './DataStorage';
import SelectionTableHandler from './SelectionTableHandler';
import SelectionDetails from './SelectionDetails';
import SimulationNotification from './SimulationNotification';

export default function registerServices(app: angular.IModule): void {
    app.service('HttpProxy', HttpProxy);
    app.service('User', User);
    app.service('MessageTips', MessageTips);
    app.service('TableHandler', TableHandler);
    app.service('SelectionNotification', SelectionNotification);
    app.service('DataStorage', DataStorage);
    app.service('SelectionTableHandler', SelectionTableHandler);
    app.service("SelectionDetails", SelectionDetails);
    app.service('SimulationNotification', SimulationNotification);
};
