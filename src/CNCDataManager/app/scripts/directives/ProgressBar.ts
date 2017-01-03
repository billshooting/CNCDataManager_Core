import * as angular from 'angular';
import { ISelectionStateScope, ISelectionAxis } from '../types/CncSelection';
import SelectionNotification from '../services/SelectionNotification';

interface IProgressBarScope extends ISelectionStateScope {
    state: {
        machineRate: number;
        systemRate: number;
        feedSystemXRate: number;
        feedSystemYRate: number;
        feedSystemZRate: number;
        spindleRate?: number;
    };
}

let ProgressBar: angular.IDirectiveFactory = (notification: SelectionNotification): angular.IDirective => {
    return {
        templateUrl: './views/directives/progress-bar.html',
        restrict: 'E',
        scope: true,
        link: (scope: IProgressBarScope, ele: Element, attr: Attr): void => {
            //辅助方法
            let getNumber:(axis: ISelectionAxis)=> number = function(axis: ISelectionAxis): number {
                let num = 0;
                for(let o in axis){
                    if (axis[o].IsSelected) num++;
                }
                return num;
            };
            scope.state = {
                machineRate: 0.0,
                systemRate: 0.0,
                feedSystemXRate: 0.0,
                feedSystemYRate: 0.0,
                feedSystemZRate: 0.0,
                spindleRate: 0.0
            };
            scope.data = {
                CNCMachine: {
                    IsSelected: false,
                    IsShown: false,
                    TypeID: null,
                    SupportType: null
                },
                CNCSystem: {
                    IsSelected: false,
                    IsShown: false,
                    TypeID: null,
                    Manufacturer: null
                },
                FeedSystemX: {
                    IsSelected: false,
                    IsShown: false,
                    Guide: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    ScrewNuts: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    Bearings: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    Couplings: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    ServoMotor: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    ServoDriver: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                },
                FeedSystemY: {
                    IsSelected: false,
                    IsShown: false,
                    Guide: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    ScrewNuts: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    Bearings: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    Couplings: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    ServoMotor: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    ServoDriver: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                },
                FeedSystemZ: {
                    IsSelected: false,
                    IsShown: false,
                    Guide: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    ScrewNuts: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    Bearings: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    Couplings: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    ServoMotor: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                    ServoDriver: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null
                    },
                },
            };

            scope.changeHandler = (): void => {
                scope.state.machineRate = scope.data.CNCMachine.IsSelected? 0.0 : 1.0;
                scope.state.systemRate = scope.data.CNCSystem.IsSelected? 0.0 : 1.0;
                scope.state.feedSystemXRate = getNumber(scope.data.FeedSystemX) / 6.0;
                scope.state.feedSystemYRate = getNumber(scope.data.FeedSystemY) / 6.0;
                scope.state.feedSystemZRate = getNumber(scope.data.FeedSystemZ) / 6.0;
            };
            //注册通知
            notification.registerNotification(scope);
        }
    };
};
ProgressBar.$inject = ['SelectionNotification'];

export default ProgressBar;