
/**
 * 前端页面的http处理封装
 */

import * as angular from 'angular';
import * as _ from 'lodash';
import {inject} from '../bases/utility';
import {ICncDataScope, IItem, IHandlingItems} from '../types/ICncDataScope';

interface IRestfulMethod {
    get: () => angular.IPromise<any>;
    post: (data: any) => angular.IPromise<any>;
    put: (data: any) => angular.IPromise<any>;
    delete: () => angular.IPromise<any>;
}

interface IResponseHandler{
    loadSuccess:      (scope: ICncDataScope, response: IHttpResponse<any>) => void;
    loadFail:         (scope: ICncDataScope, response: IHttpResponse<any>) => void;
    addSuccess:       (scope: ICncDataScope, response: IHttpResponse<any>, item: IItem) => void;
    addFail:          (scope: ICncDataScope, response: IHttpResponse<any>) => void;
    deleteSuccess:    (scope: ICncDataScope, response: IHttpResponse<any>) => void;
    deleteFail:       (scope: ICncDataScope, response: IHttpResponse<any>) => void;
    updateAllSuccess: (scope: ICncDataScope, response: IHttpResponse<any>, count: number) => void;
    updateAllFail:    (scope: ICncDataScope, response: IHttpResponse<any>, count: number) => void;
}

interface IHttpResponse<T> extends angular.IHttpPromiseCallbackArg<T>{
    message? : string;
}

@inject(['$http', '$q'])
export default class HttpProxy{
    private BASE = '/';
    //const BASE = 'http://localhost:9000/';
    //const BASE = 'http://localhost:5000/';
    private PATH = 'api/cncdata/';

    private $http: angular.IHttpService;
    private $q: angular.IQService;

    private getUrl(uri: string): string { return this.BASE + this. PATH + uri };

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

    public responseHandler: IResponseHandler = {
        loadSuccess: function(scope: ICncDataScope, response: IHttpResponse<any>){
            if(response.status < 300)
            {
                scope.items = response.data;
                //scope.messageTips.hideLoading();
            }
            else
            {
                let msg = '错误信息:' + response.status.toString() + ' ' + response.statusText;
                if(response.message !== undefined) msg = '错误信息:' + response.message;
                //scope.messageTips.hideLoading();
                //scope.messageTips.showError(msg);
            }
        },
        loadFail: function(scope: ICncDataScope, response: IHttpResponse<any>){
            let msg = '错误信息:' + response.status + ' ' + response.statusText;
            if(response.message !== undefined) msg = '错误信息:' + response.message;
            //scope.messageTips.hideLoading();
            //scope.messageTips.showError(msg);
        },
        addSuccess: function(scope: ICncDataScope, response: IHttpResponse<any>, item: IItem){
            if(response.status < 300)
            {
              _.remove(scope.items, m => m.TypeID === item.TypeID);
              scope.items.push(item);
              _.remove(scope.addingItems, item);
              //scope.messageTips.hideLoading();
            }
            else
            {
              let msg = '错误信息:' + response.status + ' ' + response.statusText;
              //scope.messageTips.hideLoading();
              //scope.messageTips.showError(msg);
            }           
        },
        addFail: function(scope: ICncDataScope, response: IHttpResponse<any>){
            var msg = '错误信息:' + response.status + ' ' + response.statusText;
            //scope.messageTips.hideLoading();
            //scope.messageTips.showError(msg);
        },
        deleteSuccess: function(scope: ICncDataScope, response: IHttpResponse<any>){
            if(response.status < 300)
            {
              _.remove(scope.items, s => s.TypeID === scope.handlingItems.deletingItem.TypeID);
              //scope.handlingItems.deletingItem = null;
              //scope.messageTips.hideLoading();
            }
            else
            {
              let msg = '错误信息:' + response.status + ' ' + response.statusText;
              scope.handlingItems.deletingItem = null;
              //scope.messageTips.hideLoading();
              //scope.messageTips.showError(msg);
            }
        },
        deleteFail: function(scope: ICncDataScope, response: IHttpResponse<any>){
            let msg = '错误信息:' + response.status + ' ' + response.statusText;
            scope.handlingItems.deletingItem = null;
            //scope.messageTips.hideLoading();
            //scope.messageTips.showError(msg);
        },
        updateAllSuccess: function(scope: ICncDataScope, response: IHttpResponse<any>, count: number){
            let ID: string = JSON.parse(response.config.data).TypeID as string;
            let item = _.find(scope.addingItems, m => m.TypeID === ID);
            if(response.status < 300)
            {
              scope.processSequence++;
              _.remove(scope.items, m => m.TypeID === item.TypeID);
              scope.items.push(item);
              _.remove(scope.addingItems, m => m.TypeID === item.TypeID);
              //scope.messageTips.showUpdate(scope.processSequence, count);
            }
            else
            {
              let msg = '错误信息:型号为' + ID +  '数据处理错误 ' + response.status + ' ' + response.statusText + '\n';
              //scope.messageTips.showUpdate(scope.processSequence, count, msg);
            }
        },
        updateAllFail: function(scope: ICncDataScope, response: IHttpResponse<any>, count: number){
            let ID:string = JSON.parse(response.config.data).TypeID as string;
            var msg = '错误信息:型号为' + ID + '某条数据处理错误 ' + response.status + ' ' + response.statusText + '\n';
            //scope.messageTips.showUpdate(scope.processSequence, count, msg);
        },
    };
}


