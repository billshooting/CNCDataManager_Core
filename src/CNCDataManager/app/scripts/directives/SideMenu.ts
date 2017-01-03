import * as angular from 'angular';
import { ISelectionStateScope } from '../types/CncSelection';
import SelectionNotification from '../services/SelectionNotification';

interface ISideMenuScope extends ISelectionStateScope{
    toggleState: (propA?: string, propB?: string)=> void;
}

let SideMenu: angular.IDirectiveFactory = (notification: SelectionNotification): angular.IDirective => {
    return {
        templateUrl: './views/directives/side-menu.html',
        restrict: 'E',
        scope: true,
        link: (scope: ISideMenuScope, ele: Element, attr: Attr): void => {
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

            scope.toggleState = (propA?: string, propB?: string): void => {
                if (propA === undefined) {
                    let ele = document.getElementById('side-menu');
                    if (ele.style.right === '0px') ele.style.right = '-300px';
                    else ele.style.right = '0px';
                }
                if (scope.data[propA] === undefined) return;
                else {
                    if (propB === undefined) scope.data[propA]['IsShown'] = !scope.data[propA]['IsShown'];
                    else scope.data[propA][propB]['IsShown'] = !scope.data[propA][propB]['IsShown'];
                }
            };

            scope.changeHandler = () => {};
            //注册通知
            notification.registerNotification(scope);
        }
    };
};
SideMenu.$inject = ['SelectionNotification']

export default SideMenu;