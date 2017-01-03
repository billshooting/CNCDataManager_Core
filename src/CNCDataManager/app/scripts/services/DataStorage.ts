import * as angular from 'angular';

export default class DataStorage {
    public constructor(){}
    public setValue(key: string, value: string): void {
        localStorage.setItem(key, value);
    }
    public getValue(key: string): string {
        return localStorage.getItem(key);
    }
    public setObject(key: string, value: any): void {
        localStorage.setItem(key, JSON.stringify(value));
    }
    public getObject(key: string): any {
        return JSON.parse(localStorage.getItem(key));
    }
    public remove(key: string): void { localStorage.removeItem(key); };
    public clear(): void { localStorage.clear(); };
};