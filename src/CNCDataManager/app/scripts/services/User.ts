import * as angular from 'angular';
import HttpProxy from './HttpProxy';

export default class User {
    private name: string;
    private isAuthenticated: boolean;
    private httpProxy: HttpProxy;

    public constructor(httpProxy: HttpProxy) {
        this.httpProxy = httpProxy;
        this.isAuthenticated = false;
        this.name = null;
    }

    public get Name(): string {
        return this.name;
    }
    public get IsAuthenticated(): boolean {
        return this.isAuthenticated;
    }

    public login(formData: FormData): boolean{
        this.isAuthenticated = true;
        this.name = 'Bill';
        return true;
    }
    public logout(): boolean {
        this.isAuthenticated = false;
        this.name = null;
        return true;
    }
    public register(formData: FormData): boolean {
        return true;
    }

};
User.$inject = ['HttpProxy'];

