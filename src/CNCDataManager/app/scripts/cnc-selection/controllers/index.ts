import * as angular from 'angular';
import { Selection } from './Selection';

export default function registerSelectionControllers(app: angular.IModule): void {
    app.controller('SelectionCtrl', Selection);
}