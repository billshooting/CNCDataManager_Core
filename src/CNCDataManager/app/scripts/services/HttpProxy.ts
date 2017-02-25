
/**
 * 前端页面的http处理封装
 */

import * as angular from 'angular';
import * as _ from 'lodash';
import { ITableScope, ICncDataScope, IItem, IHandlingItems } from '../types/CncData';
import MessageTips from './MessageTips';

interface IRestfulMethod {
    get: (queryStringObject?: any, options?: angular.IRequestShortcutConfig) => angular.IPromise<any>;
    post: (data: any, options?: angular.IRequestShortcutConfig) => angular.IPromise<any>;
    put: (data: any, options?: angular.IRequestShortcutConfig) => angular.IPromise<any>;
    delete: (options?: angular.IRequestShortcutConfig) => angular.IPromise<any>;
    polling: (onSuccess?: (response: any) => void, onError?: (response: any) => void, options?: angular.IRequestShortcutConfig) => angular.IPromise<any>;
}

interface IHttpResponse<T> extends angular.IHttpPromiseCallbackArg<T>{
    message? : string;
}


export default class HttpProxy{
    //private BASE = '/';
    //private BASE = 'http://localhost:5000/';
    private BASE = 'http://localhost:52132/';
    //private BASE = 'http://cncdataapi.azurewebsites.net/';
    private PATH = 'api/cncdata/';

    private $http: angular.IHttpService;
    private $q: angular.IQService;
    private messageTips: MessageTips;
    private $interval: angular.IIntervalService;

    public constructor($http: angular.IHttpService, $q: angular.IQService, messageTips: MessageTips, $interval: angular.IIntervalService)
    {
        this.$http = $http;
        this.$q = $q;
        this.messageTips = messageTips;
        this.$interval = $interval;
    }

    public getUrl(uri: string, queryStringObject?: any): string { 
        let result = this.BASE + this.PATH + uri;
        if(queryStringObject){
            result = result + '?';
            for(let key in queryStringObject) result = result + key + '=' + queryStringObject[key] + '&';
            result = result.substr(0, result.length - 1);
        }
        return result;
    };

    public getRelativeUrl(relativeUri: string, queryStringObject?: any): string {
        let result = relativeUri;
        if(queryStringObject) {
            result = result + '?';
            for(let key in queryStringObject) result = result + key + '=' + queryStringObject[key] + '&';
            result = result.substr(0, result.length - 1);
        }
        return result;
    }

    public http(uri: string): IRestfulMethod {
        let url: string = this.getUrl(uri);
        let deffered: angular.IDeferred<any> = this.$q.defer<any>();
        let promise: angular.IPromise<any> = deffered.promise;
        let $http = this.$http;
        let $interval = this.$interval;
        return{
            get: function(queryStringObject?: any, options?: angular.IRequestShortcutConfig): angular.IPromise<any> {
                if(queryStringObject){
                    url = url + '?';
                    for(let key in queryStringObject) url = url + key + '=' + queryStringObject[key] + '&';
                    url = url.substr(0, url.length - 1);// 去掉最后一个 '&'
                }
                $http.get(url, options).then(
                    (response: any) => deffered.resolve(response),
                    (response: any) => deffered.reject(response));
                return promise;
            },
            post: function(data: any, options?: angular.IRequestShortcutConfig): angular.IPromise<any>{
                $http.post(url, data, options).then(
                    (response: any) => deffered.resolve(response),
                    (response: any) => deffered.reject(response));
                return promise;
            },
            put: function(data: any, options?: angular.IRequestShortcutConfig): angular.IPromise<any>{
                $http.put(url, data, options).then(
                    (response: any) => deffered.resolve(response),
                    (response: any) => deffered.reject(response));
                return promise;
            },
            delete: function(options?: angular.IRequestShortcutConfig): angular.IPromise<any>{
                $http.delete(url, options).then(
                    (response: any) => deffered.resolve(response),
                    (response: any) => deffered.reject(response));
                return promise;
            },
            polling: function(onSuccess, onError, options?: angular.IRequestShortcutConfig): angular.IPromise<any>{
                let intervalID = $interval(() => $http.get(url, options).then(
                    (response: any) => {
                        if(response.status === 200) 
                        {
                            $interval.cancel(intervalID);
                            onSuccess(response);
                        }
                        else if(response.status === 204) console.log('Not Completed Yet!');
                    }, 
                    (response: any) => onError(response)), 11000, 30);
                return intervalID;
            }
        }
    }

    public loadSuccess(scope: ITableScope, response: IHttpResponse<any>): void
    {
        if (response.status < 300) {
            scope.items = response.data;
            this.messageTips.hideLoading();
        }
        else {
            let msg = '错误信息:' + response.status.toString() + ' ' + response.statusText;
            if (response.message !== undefined) msg = '错误信息:' + response.message;
            this.messageTips.hideLoading();
            this.messageTips.showError(msg);
        }
    }

    public loadFail(scope: ITableScope, response: IHttpResponse<any>): void
    {
        let msg = '错误信息:' + response.status + ' ' + response.statusText;
        if (response.message !== undefined) msg = '错误信息:' + response.message;
        this.messageTips.hideLoading();
        this.messageTips.showError(msg);
    }

    public addSuccess(scope: ICncDataScope, response: IHttpResponse<any>, item: IItem): void
    {
        if (response.status < 300) {
            _.remove(scope.items, m => m.TypeID === item.TypeID);
            scope.items.push(item);
            _.remove(scope.addingItems, item);
            this.messageTips.hideLoading();
        }
        else {
            let msg = '错误信息:' + response.status + ' ' + response.statusText;
            this.messageTips.hideLoading();
            this.messageTips.showError(msg);
        }    
    }

    public addFail(scope: ICncDataScope, response: IHttpResponse<any>): void
    {
        let msg = '错误信息:' + response.status + ' ' + response.statusText;
        this.messageTips.hideLoading();
        this.messageTips.showError(msg);

    }

    public deleteSuccess(scope: ICncDataScope, response: IHttpResponse<any>): void
    {
        if (response.status < 300) {
            _.remove(scope.items, s => s.TypeID === scope.handlingItems.deletingItem.TypeID);
            scope.handlingItems.deletingItem = null;
            this.messageTips.hideLoading();
        }
        else {
            let msg = '错误信息:' + response.status + ' ' + response.statusText;
            scope.handlingItems.deletingItem = null;
            this.messageTips.hideLoading();
            this.messageTips.showError(msg);
        }
    }

    public deleteFail(scope: ICncDataScope, response: IHttpResponse<any>): void
    {
        let msg = '错误信息:' + response.status + ' ' + response.statusText;
        scope.handlingItems.deletingItem = null;
        this.messageTips.hideLoading();
        this.messageTips.showError(msg);
    }

    public updateAllSuccess(scope: ICncDataScope, response: IHttpResponse<any>, count: number): void
    {
        let ID: string = JSON.parse(response.config.data).TypeID as string;
        let item = _.find(scope.addingItems, m => m.TypeID === ID);
        if (response.status < 300) {
            scope.processSequence++;
            _.remove(scope.items, m => m.TypeID === item.TypeID);
            scope.items.push(item);
            _.remove(scope.addingItems, m => m.TypeID === item.TypeID);
            this.messageTips.showUpdate(scope.processSequence, count);
        }
        else {
            let msg = '错误信息:型号为' + ID + '数据处理错误 ' + response.status + ' ' + response.statusText + '\n';
            this.messageTips.showUpdate(scope.processSequence, count, msg);
        }
    }

    public updateAllFail(scope: ICncDataScope, response: IHttpResponse<any>, count: number): void
    {
        let ID: string = JSON.parse(response.config.data).TypeID as string;
        let msg = '错误信息:型号为' + ID + '某条数据处理错误 ' + response.status + ' ' + response.statusText + '\n';
        this.messageTips.showUpdate(scope.processSequence, count, msg);
    }
}

HttpProxy.$inject = ['$http', '$q', 'MessageTips', '$interval'];


