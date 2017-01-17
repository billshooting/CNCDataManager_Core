import * as angular from 'angular';
import Simulation from './Simulation';
import SimulationChart from './SimulationChart';

export default function registerSimulationControllers(app: angular.IModule): void {
    app.controller('SimulationCtrl', Simulation);
    app.controller('SimulationChartCtrl', SimulationChart);
};