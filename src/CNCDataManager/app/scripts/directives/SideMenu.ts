import * as angular from 'angular';
import { ISelectionStateScope } from '../types/CncSelection';
import SelectionNotification from '../services/SelectionNotification';
import DataStorage from '../services/DataStorage';
import HttpProxy from '../services/HttpProxy';

interface ISideMenuScope extends ISelectionStateScope{
    toggleState: (propA?: string, propB?: string)=> void;
    selectionComplete: () => void;
    selectionReset: () => void;
}

let SideMenu: angular.IDirectiveFactory = (notifier: SelectionNotification, 
                                           dataStorage: DataStorage, 
                                           httpProxy: HttpProxy,
                                           $state: angular.ui.IStateService): angular.IDirective => {
    return {
        templateUrl: './views/directives/side-menu.html',
        restrict: 'E',
        scope: true,
        link: (scope: ISideMenuScope, ele: Element, attr: Attr): void => {
            /** scope上数据初始化 */
            let dataInitialize = (scope: ISideMenuScope): void => {
                scope.data = {
                    CNCMachine: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        SupportType: null,
                        ImgUrl: null,
                    },
                    CNCSystem: {
                        IsSelected: false,
                        IsShown: false,
                        TypeID: null,
                        Manufacturer: null,
                        ImgUrl: null,
                    },
                    FeedSystemX: {
                        IsSelected: false,
                        IsShown: false,
                        Guide: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        ScrewNuts: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        Bearings: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        Couplings: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        ServoMotor: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        ServoDriver: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                    },
                    FeedSystemY: {
                        IsSelected: false,
                        IsShown: false,
                        Guide: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        ScrewNuts: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        Bearings: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        Couplings: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        ServoMotor: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        ServoDriver: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                    },
                    FeedSystemZ: {
                        IsSelected: false,
                        IsShown: false,
                        Guide: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        ScrewNuts: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        Bearings: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        Couplings: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        ServoMotor: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                        ServoDriver: {
                            IsSelected: false,
                            IsShown: false,
                            TypeID: null,
                            Manufacturer: null,
                            ImgUrl: null,
                        },
                    },
                };
            };
            
            //方法定义
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

            scope.selectionComplete = () => {
                if(notifier.isAllSelected()) $state.go('simulation.Settings', {axisID: 'X'});
                else alert('选型尚未完成，请继续');
            };
            scope.selectionReset = () => {
                dataStorage.clear();
                dataInitialize(scope);
            }

            scope.changeHandler = () => {};

            // 1.注册通知
            notifier.registerNotification(scope);
            // 2.数据初始化
            dataInitialize(scope);
            // 3.用当前localStorage里的数据初始化 SideMenu
            let storageKeys: string[] = ['MachineType', 'MachineWorkingConditions',
                                        'CNCSystem', 'CNCSystemAccessories',
                                        'FeedSystemXGuides', 'FeedSystemXScrewNuts', 'FeedSystemXBearings', 'FeedSystemXCouplings', 'FeedSystemXServoMotors', 'FeedSystemXServoDrivers',
                                        'FeedSystemYGuides', 'FeedSystemYScrewNuts', 'FeedSystemYBearings', 'FeedSystemYCouplings', 'FeedSystemYServoMotors', 'FeedSystemYServoDrivers',
                                        'FeedSystemZGuides', 'FeedSystemZScrewNuts', 'FeedSystemZBearings', 'FeedSystemZCouplings', 'FeedSystemZServoMotors', 'FeedSystemZServoDrivers'];
            storageKeys.forEach(key => {
                let storage = dataStorage.getObject(key);
                if(storage){
                    switch(key)
                    {
                        case storageKeys[0]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.CNCMachine.IsShown; 
                                data.CNCMachine = {
                                    IsSelected: true,
                                    TypeID: storage.type,
                                    SupportType: storage.support,
                                    IsShown: identifiedValue,
                                    ImgUrl: storage.imgUrl,
                                };
                            });
                            break;
                        }
                        case storageKeys[1]: break;
                        case storageKeys[2]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.CNCSystem.IsShown; 
                                data.CNCSystem = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/CNC/CNCSystem/' + storage.TypeID + '.jpg',
                                };
                            });
                            break;
                        }
                        case storageKeys[3]: break;
                        case storageKeys[4]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemX.Guide.IsShown;
                                data.FeedSystemX.Guide = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                   IsShown: identifiedValue,
                                   ImgUrl: './images/Mechanics/导轨-表/Guide.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[5]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemX.ScrewNuts.IsShown;
                                data.FeedSystemX.ScrewNuts = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                   IsShown: identifiedValue,
                                   ImgUrl: './images/Mechanics/滚珠丝杠-表/滚珠丝杠螺母副.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[6]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemX.Bearings.IsShown;
                                data.FeedSystemX.Bearings = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Mechanics/滚动轴承-表/滚动轴承.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[7]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemX.Couplings.IsShown;
                                data.FeedSystemX.Couplings = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Mechanics/联轴器-表/联轴器.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[8]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemX.ServoMotor.IsShown;
                                data.FeedSystemX.ServoMotor = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Motors/伺服电机.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[9]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemX.ServoDriver.IsShown;
                                data.FeedSystemX.ServoDriver = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Servo/Driver.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[10]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemY.Guide.IsShown;
                                data.FeedSystemY.Guide = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Mechanics/导轨-表/Guide.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[11]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemY.ScrewNuts.IsShown;
                                data.FeedSystemY.ScrewNuts = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Mechanics/滚珠丝杠-表/滚珠丝杠螺母副.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[12]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemY.Bearings.IsShown;
                                data.FeedSystemY.Bearings = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Mechanics/滚动轴承-表/滚动轴承.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[13]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemY.Couplings.IsShown;
                                data.FeedSystemY.Couplings = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Mechanics/联轴器-表/联轴器.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[14]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemY.ServoMotor.IsShown;
                                data.FeedSystemY.ServoMotor = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Motors/伺服电机.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[15]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemY.ServoDriver.IsShown;
                                data.FeedSystemY.ServoDriver = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Servo/Driver.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[16]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemZ.Guide.IsShown;
                                data.FeedSystemZ.Guide = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Mechanics/导轨-表/Guide.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[17]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemZ.ScrewNuts.IsShown;
                                data.FeedSystemZ.ScrewNuts = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Mechanics/滚珠丝杠-表/滚珠丝杠螺母副.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[18]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemZ.Bearings.IsShown;
                                data.FeedSystemZ.Bearings = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Mechanics/滚动轴承-表/滚动轴承.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[19]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemZ.Couplings.IsShown;
                                data.FeedSystemZ.Couplings = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Mechanics/联轴器-表/联轴器.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[20]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemZ.ServoMotor.IsShown;
                                data.FeedSystemZ.ServoMotor = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Motors/伺服电机.jpg',
                                }
                            });
                            break;
                        }
                        case storageKeys[21]:
                        {
                            notifier.notifyChange(data => {
                                let identifiedValue = data.FeedSystemZ.ServoDriver.IsShown;
                                data.FeedSystemZ.ServoDriver = {
                                    IsSelected: true,
                                    TypeID: storage.TypeID,
                                    Manufacturer: storage.Manufacturer,
                                    IsShown: identifiedValue,
                                    ImgUrl: './images/Servo/Driver.jpg',
                                }
                            });
                            break;
                        }
                    }
                }
            });

            // 4.监听destroy事件，释放资源
            scope.$on('$destroy', () => notifier.deregisterNotification(scope));
            
        }
    };
};
SideMenu.$inject = ['SelectionNotification', 'DataStorage', 'HttpProxy', '$state'];

export default SideMenu;