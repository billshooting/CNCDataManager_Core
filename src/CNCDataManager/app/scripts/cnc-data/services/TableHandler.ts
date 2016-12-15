import * as $ from 'jquery';
import * as angular from 'angular';
import * as _ from 'lodash';
import HttpProxy from './HttpProxy';
import MessageTips from './MessageTips';
import { ICncDataScope, IItem, IHandlingItems, ITableHandler } from '../types/ICncDataScope';

export default class TableHandler {
    public httpProxy: HttpProxy;
    public message: MessageTips;

    public constructor(httpProxy: HttpProxy, message: MessageTips)
    {
        this.httpProxy = httpProxy;
        this.message = message;
    }

    public buildTableHandler(scope: ICncDataScope): ITableHandler
    {
        let message = this.message;
        let httpProxy = this.httpProxy;
        return {
            // 1. 是否显示某列元素
            toggleCol: function (id: number, e: BaseJQueryEventObject): void {
                if (scope.colState[id]) {
                    scope.colState[id] = false;
                    angular.element(e.currentTarget).removeClass('cncdata-table-col-checked');
                }
                else {
                    scope.colState[id] = true;
                    angular.element(e.currentTarget).addClass('cncdata-table-col-checked');
                }
            },
            // 2. 对表格进行排序
            changeOrderProperty: function (property: string): void {
                if (property === scope.orderProperty) {
                    scope.orderProperty = '-' + property;
                } else {
                    scope.orderProperty = property;
                }
            },
            // 3. 删除数据
            showDeleteModal: function (item: IItem): void {
                scope.handlingItems.deletingItem = item;
                scope.deleteItemModal.$promise.then(scope.deleteItemModal.show);
            },
            deleteItemLocal: function (item: IItem): void {
                _.remove(scope.addingItems, item);
            },
            deleteItemRemote: function (): void {
                //显示加载图像
                message.showLoading();
                scope.deleteItemModal.hide();
                httpProxy.http(scope.ITEMNAME + $.trim(scope.handlingItems.deletingItem.TypeID))
                    .delete()
                    .then((response: any) => { httpProxy.deleteSuccess(scope, response); },
                          (response: any) => { httpProxy.deleteFail(scope, response); });
            },
            // 4. 添加数据
            showAddModal: function (): void {
                scope.addItemModal.$promise.then(scope.addItemModal.show);
            },
            addItemLocal: function (): void {
                scope.addingItems.push(scope.handlingItems.addingItem);
                scope.handlingItems.addingItem = null;
                scope.addItemModal.hide();
            },
            addItemRemote: function (item: any): void {
                //显示加载图像
                message.showLoading();
                if (!item.isUpdate) {
                    httpProxy.http(scope.ITEMNAME)
                        .post(JSON.stringify(item))
                        .then((response: any) => { httpProxy.addSuccess(scope, response, item); },
                              (response: any) => { httpProxy.addFail(scope, response); });
                }
                else {
                    item.isUpdate = undefined;
                    httpProxy.http(scope.ITEMNAME + $.trim(item.TypeID))
                        .put(JSON.stringify(item))
                        .then((response: any) => { httpProxy.addSuccess(scope, response, item); },
                              (response: any) => { httpProxy.addFail(scope, response); });
                }
            },
            // 5. 修改数据
            updateItemLocal: function (item: IItem): void {
                item.isUpdate = true;
                scope.addingItems.push(item);
            },
            updateItemsRemote: function (): void {
                message.showLoading();
                
                scope.processSequence = 0;
                let count = scope.addingItems.length;
                for (let j = 0; j < scope.addingItems.length; j++) {
                    let item = scope.addingItems[j];
                    if (item.isUpdate) {
                        item.isUpdate = undefined;
                        httpProxy.http(scope.ITEMNAME + $.trim(item.TypeID))
                            .put(JSON.stringify(item))
                            .then((response: any) => { httpProxy.updateAllSuccess(scope, response, count); },
                            (response: any) => { httpProxy.updateAllFail(scope, response, count); });
                    }
                    else {
                        httpProxy.http(scope.ITEMNAME)
                            .post(JSON.stringify(item))
                            .then((response: any) => { httpProxy.updateAllSuccess(scope, response, count); },
                            (response: any) => { httpProxy.updateAllFail(scope, response, count); });
                    }
                }
            }
        };
    }

    // 6. 初始化
    public initialize(scope: ICncDataScope) {
        this.message.showLoading();
        this.httpProxy.http(scope.ITEMNAME)
            .get()
            .then((response: any) => { this.httpProxy.loadSuccess(scope, response); },
                  (response: any) => { this.httpProxy.loadFail(scope, response); });
    };
};

TableHandler.$inject = ['HttpProxy', 'MessageTips'];