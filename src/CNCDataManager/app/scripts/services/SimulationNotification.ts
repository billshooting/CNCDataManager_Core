import * as angular from 'angular';
import { ISimulationCompletedScope } from '../types/CncSimulation';

export default class SimulationNotification {
    private scopes: ISimulationCompletedScope[];
    private _fileID: string;
    private _plotData: {
        displacement: [number, number][];
        velocity: [number, number][];
        acceleration: [number, number][];
        [propName: string]: [number, number][];
    }

    public constructor() { 
        this.scopes = new Array<ISimulationCompletedScope>(); 
        this._fileID = null;
        this._plotData = { displacement: null, velocity: null, acceleration: null };
    }

    public registerNotification(...listeners: ISimulationCompletedScope[]): void
    {
        if(listeners){
            for(let listener of listeners) this.scopes.push(listener);
        }
    }

    public deregisterNotification(...listeners: ISimulationCompletedScope[]): void
    {
        if(listeners)
        {
            let temp: ISimulationCompletedScope[] = [];
            this.scopes.forEach(scope => {
                if(listeners.indexOf(scope) < 0) temp.push(scope);
            })
            this.scopes = temp;
        }
    }

    public notifyComplement(data: any): void
    {
        this.fileID = data as string;
        this.scopes.forEach(scope => scope.simulationCompleted());
    }

    public notifyFailure(errorMsg: string): void
    {
        this.scopes.forEach(scope => scope.simulationFailed(errorMsg));
    }

    public notifyStart(): void 
    {
        this.scopes.forEach(scope => scope.simulationStarted());
    }

    public get fileID() { return this._fileID; }
    public set fileID(value: string) 
    {
        if(value.length === 15) this._fileID = value;
    }

    public get plotData() { return this._plotData; }

    /** 主要为了从设置页面跳转到结果页面时，清除掉已经存在的fileID */
    public resetFileID(): void 
    { 
        this._fileID = null; 
        this._plotData = { displacement: null, velocity: null, acceleration: null };
    }

    /** 这个方法本不应该在这，但它似乎没什么好去处 return format: 20170101-005059*/
    public getCurrentTime(): string
    {
        let date = new Date();
        let year = date.getFullYear().toString();
        let month = ('0' + (date.getMonth() + 1).toString()).slice(-2);
        let day = ('0' + date.getDate().toString()).slice(-2);
        let hour = ('0' +  date.getHours()).slice(-2);
        let min = ('0' + date.getMinutes()).slice(-2);
        let sec = ('0' + date.getSeconds()).slice(-2);
        return year + month + day + '-' + hour + min + sec;
    }

};