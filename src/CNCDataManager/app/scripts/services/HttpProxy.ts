
/**
 * 前端页面的http处理封装
 */

import * as angular from 'angular';
import * as _ from 'lodash';
import { ICncDataScope, IItem, IHandlingItems } from '../types/ICncDataScope';
import MessageTips from './MessageTips';

interface IRestfulMethod {
    get: () => angular.IPromise<any>;
    post: (data: any) => angular.IPromise<any>;
    put: (data: any) => angular.IPromise<any>;
    delete: () => angular.IPromise<any>;
}

interface IHttpResponse<T> extends angular.IHttpPromiseCallbackArg<T>{
    message? : string;
}


export default class HttpProxy{
    //private BASE = '/';
    //private BASE = 'http://localhost:9200/';
    //private BASE = 'http://localhost:52132/';
    private BASE = 'http://cncdataapi.azurewebsites.net/';
    private PATH = 'api/cncdata/';

    private $http: angular.IHttpService;
    private $q: angular.IQService;
    private messageTips: MessageTips;

    public constructor($http: angular.IHttpService, $q: angular.IQService, messageTips: MessageTips)
    {
        this.$http = $http;
        this.$q = $q;
        this.messageTips = messageTips;
    }

    private getUrl(uri: string): string { return this.BASE + this.PATH + uri };

    public http(uri: string): IRestfulMethod {
        let url: string = this.getUrl(uri);
        let deffered: angular.IDeferred<any> = this.$q.defer<any>();
        let promise: angular.IPromise<any> = deffered.promise;
        let $http = this.$http;
        return{
            get: function(): angular.IPromise<any> {
                $http.get(url).then(
                    (response: any) => deffered.resolve(response),
                    (response: any) => deffered.reject(response));
                return promise;
            },
            post: function(data: any): angular.IPromise<any>{
                $http.post(url, data).then(
                    (response: any) => deffered.resolve(response),
                    (response: any) => deffered.reject(response));
                return promise;
            },
            put: function(data: any): angular.IPromise<any>{
                $http.put(url, data).then(
                    (response: any) => deffered.resolve(response),
                    (response: any) => deffered.reject(response));
                return promise;
            },
            delete: function(): angular.IPromise<any>{
                $http.delete(url).then(
                    (response: any) => deffered.resolve(response),
                    (response: any) => deffered.reject(response));
                return promise;
            }
        }
    }

    public loadSuccess(scope: ICncDataScope, response: IHttpResponse<any>): void
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

    public loadFail(scope: ICncDataScope, response: IHttpResponse<any>): void
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

HttpProxy.$inject = ['$http', '$q', 'MessageTips'];


