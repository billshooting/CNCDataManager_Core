import * as angular from 'angular';
import { ISelectionStateScope } from '../types/CncSelection';
import SelectionNotification from '../services/SelectionNotification';
import DataStorage from '../services/DataStorage';

interface ISideMenuScope extends ISelectionStateScope{
    toggleState: (propA?: string, propB?: string)=> void;
}

let SideMenu: angular.IDirectiveFactory = (notifier: SelectionNotification, dataStorage: DataStorage): angular.IDirective => {
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
            notifier.registerNotification(scope);
            let storageKeys: string[] = ['MachineType', 'MachineWorkingConditions',
                                        'CNCSystem', 'CNCSystemAccessories',
                                        'XGuide', 'XBallScrew', 'XBearings', 'XCouplings', 'XServoMotor', 'XServoDriver',
                                        'YGuide', 'YBallScrew', 'YBearings', 'YCouplings', 'YServoMotor', 'YServoDriver',
                                        'ZGuide', 'ZBallScrew', 'ZBearings', 'ZCouplings', 'ZServoMotor', 'ZServoDriver'];
            storageKeys.forEach(key => {
                let storage = dataStorage.getObject(key);
                if(storage){
                    switch(key)
                    {
                        case storageKeys[0]:
                        {
                            notifier.notifyChange(data => {
                                let indentifiedValue = data.CNCMachine.IsShown; 
                                data.CNCMachine = {
                                    IsSelected: true,
                                    TypeID: storage.type,
                                    SupportType: storage.support,
                                    IsShown: indentifiedValue,
                                    ImgUrl: storage.imgUrl,
                                };
                            });
                            break;
                        }
                        case storageKeys[1]: break;
                        case storageKeys[2]:
                        {
                            notifier.notifyChange(data => {
                                let indentifiedValue = data.CNCSystem.IsShown; 
                                data.CNCSystem = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: indentifiedValue,
                                    ImgUrl: './images/CNC/CNCSystem/' + storage.TypeID + '.jpg',
                                };
                            });
                            break;
                        }
                    }
                }
            })
        }
    };
};
SideMenu.$inject = ['SelectionNotification', 'DataStorage'];

export default SideMenu;