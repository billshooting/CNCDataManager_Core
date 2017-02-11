import * as angular from 'angular';
import { ISelectionStateScope, ISelectionData } from '../types/CncSelection';
import DataStorage from './DataStorage';
import { IReportResult } from '../types/CncSimulation';

export default class SelectionNotification {
    private scopes: ISelectionStateScope[];
    private dataStorage: DataStorage;
 
    public constructor(storage: DataStorage)
    {
        this.dataStorage = storage;
        this.scopes = new Array<ISelectionStateScope>();
    }

    /** 获取当前localStorage里的数据 */
    private getFeedSystem(axisID: string): any {
        let feedSystem = {
            Guide: this.dataStorage.getObject('FeedSystem' + axisID + 'Guides'),
            Ballscrew: this.dataStorage.getObject('FeedSystem' + axisID + 'ScrewNuts'),
            Bearings: this.dataStorage.getObject('FeedSystem' + axisID + 'Bearings'),
            Coupling: this.dataStorage.getObject('FeedSystem' + axisID + 'Couplings'),
            ServoMotor: this.dataStorage.getObject('FeedSystem' + axisID + 'ServoMotors'),
            Driver: this.dataStorage.getObject('FeedSystem' + axisID + 'ServoDrivers'),
        };
        return feedSystem;
    }

    public registerNotification(...listeners: ISelectionStateScope[]): void
    {
        if(listeners)
        {
            for (let listener of listeners) this.scopes.push(listener);
        }
    }

    public deregisterNotification(...listeners: ISelectionStateScope[]): void
    {
        if(listeners)
        {
            let temp: ISelectionStateScope[] = [];
            this.scopes.forEach(scope => {
                if(listeners.indexOf(scope) < 0) temp.push(scope);
            })
            this.scopes = temp;
        }
    }

    public notifyChange(change: (data: ISelectionData) => void): void
    {
        this.scopes.forEach(scope => {
            change(scope.data);
            scope.changeHandler();
        });
    }

    public getSideMenuScopeData(): ISelectionData {
        let scope = this.scopes[0];
        return scope.data;
    }

    public getReportData(): IReportResult {
        let system = this.dataStorage.getObject('CNCSystem');
        let ncSystem = {
            TypeID: system.TypeID,
            SupportMachineType: system.SupportMachineType,
            NumberOfSupportChannels: system.SupportChannels,
            MaxNumberOfFeedSystemAxis: system.MaxNumberOfFeedShafts,
            MaxNumberOfSpindleAxis: system.MaxNumberOfSpindels,
            MaxNumberOfLinkageAxis: system.MaxNumberOfLinkageAxis
        };
        let result: IReportResult = {
            MachineType: this.dataStorage.getObject('MachineType'),
            NCSystem: ncSystem,
            FeedSystemX: this.getFeedSystem('X'),
            FeedSystemY: this.getFeedSystem('Y'),
            FeedSystemZ: this.getFeedSystem('Z'),
            Spindle: null,
        };
        return result;
    }
};
SelectionNotification.$inject = ['DataStorage'];