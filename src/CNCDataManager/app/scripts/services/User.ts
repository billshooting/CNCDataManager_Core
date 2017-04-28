import * as angular from 'angular';
import HttpProxy from './HttpProxy';
import { IRegisterModel, ILoginModel } from '../types/CncAccount';

export default class User 
{
    private name: string;
    private isAuthenticated: boolean;
    private httpProxy: HttpProxy;
    private role: string;
    private company: string;

    public constructor(httpProxy: HttpProxy) 
    {
        this.httpProxy = httpProxy;
        this.isAuthenticated = false;
        this.name = null;
        this.role = null;
        this.company = null;
    }

    public get Name(): string { return this.name; }
    public get IsAuthenticated(): boolean { return this.isAuthenticated; }
    public get Role(): string { return this.role; }
    public get Company(): string { return this.company; }
    public get CompanyName(): string 
    {
        switch(this.Company)
        {
            case 'HNC': return '华中数控的';
            case 'GSK': return '广州数控的';
            case 'GJ': return '沈阳高精的';
            case 'BJHT': return '北京航天的';
            default: return '';
        }
    }

    public login(formData: ILoginModel, onsuccess?: (response: any) => void, onerror?: (response: any) => void): void
    {
        this.httpProxy.http('Account/Login').post(formData).then(response => 
        {
            if(response.status === 200) 
            {
                this.name = response.data.userName as string;
                this.role = response.data.role as string;
                this.company = response.data.company as string;
                this.isAuthenticated = true;
            }
            onsuccess(response);
        }, onerror);
    }
    public logout(): void 
    {
        this.httpProxy.http('Account/LogOff').post({});
        this.isAuthenticated = false;
        this.name = null;
        this.role = null;
        this.company = null;
    }
    public register(data: IRegisterModel, onsuccess?: (response: any) => void, onerror?: (response: any) => void): void 
    {
        this.httpProxy.http('Account/Register').post(data).then(response => 
        {
            if(response.status === 200) 
            {
                this.name = response.data.userName as string;
                this.role = response.data.role as string;
                this.company = response.data.company as string;
                this.isAuthenticated = true;
            }
            onsuccess(response);
        }, onerror);
    }
    public isLogin(stateSync: () => void): void
    {
        this.httpProxy.http('Account/IsLogin')
            .get()
            .then((response: any) => 
            {
                this.name = response.data.userName as string;
                this.role = response.data.role as string;
                this.company = response.data.company as string;
                this.isAuthenticated = true;
                stateSync();
            }, response => {});
    }

};
User.$inject = ['HttpProxy'];

