'use strict';

/**
 * @ngdoc service
 * @name cncdataManagerApp.TableHandler
 * @description
 * # TableHandler
 * Service in the cncdataManagerApp.
 */
angular.module('cncdataManagerApp')
  .service('TableHandler', function (ProxyService) {
    // AngularJS will instantiate a singleton by calling "new" on this function
        // 1. 是否显示某列元素
        this.toggleCol = function (id, e) 
        {
            let scope = this;
            if (scope.colState[id]) {
                scope.colState[id] = false;
                angular.element(e.currentTarget).removeClass('cncdata-table-col-checked');
            }
            else {
                scope.colState[id] = true;
                angular.element(e.currentTarget).addClass('cncdata-table-col-checked');
            }
        };
        // 2. 对表格进行排序
        this.changeOrderProperty = function (property) 
        {
            let scope = this;
            if(property === scope.orderProperty){
              scope.orderProperty = '-' + property;
            }else{
              scope.orderProperty = property;
            }
        };

        // 3. 删除数据
        this.showDeleteModal = function (item) 
        {
          let scope = this;
          scope.handlingItems.deletingItem = item;
          scope.deleteItemModal.$promise.then(scope.deleteItemModal.show);
        };
        this.deleteItemLocal = function (item)
        {
          let scope = this;
          _.remove(scope.addingItems, item);
        };
        this.deleteItemRemote = function () 
        {
          //显示加载图像
          let scope = this;
          scope.messageTips.showLoading();
          scope.deleteItemModal.hide();
          ProxyService.http(scope.ITEMNAME + $.trim(scope.handlingItems.deletingItem.TypeID)).delete()
          .then(function (response) 
          {
            ProxyService.responseHandler.deleteSuccess (scope, response);
          }, function (response) 
          {
            ProxyService.responseHandler.deleteFail (scope, response);
          });
        };

        // 4. 添加数据
        this.showAddModal = function ()
        {
          let scope = this;
          scope.addItemModal.$promise.then(scope.addItemModal.show);
        };
        this.addItemLocal = function ()
        {
          let scope = this;
          scope.addingItems.push(scope.handlingItems.addingItem);
          scope.handlingItems.addingItem = null;
          scope.addItemModal.hide();
        };
        this.addItemRemote = function (item)
        {
          let scope = this;
          //显示加载图像
          scope.messageTips.showLoading();
          if(!item.isUpdate)
          {
            ProxyService.http(scope.ITEMNAME + encodeURIComponent($.trim(item.TypeID))).post(JSON.stringify(item))
            .then(function (response) {
              ProxyService.responseHandler.addSuccess (scope, response, item);
            }, function (response) {
              ProxyService.responseHandler.addFail (scope, response);
            });
          }
          else
          {
            item.isUpdate = undefined;
            ProxyService.http(scope.ITEMNAME + $.trim(item.TypeID)).put(JSON.stringify(item))
            .then(function (response) {
              ProxyService.responseHandler.addSuccess (scope, response, item);
            }, function (response) {
              ProxyService.responseHandler.addFail (scope, response);
            });
          }
        };

        // 5. 修改数据
        this.updateItemLocal = function (item) 
        {
          let scope = this;
          item.isUpdate = true;
          scope.addingItems.push(item);
        };
        this.updateItemsRemote = function () 
        {
          let scope = this;
          scope.messageTips.showLoading();
          scope.processSequence = 0;
          let count = scope.addingItems.length;
          for(var j = 0; j<scope.addingItems.length; j++)
          {
            var item = scope.addingItems[j];
            if (item.isUpdate)
            {
              item.isUpdate = undefined;
              ProxyService.http(scope.ITEMNAME + $.trim(item.TypeID)).put(JSON.stringify(item))
              .then(function (response) {
                ProxyService.responseHandler.updateAllSuccess(scope, response, count);
              }, function (response) {
                ProxyService.responseHandler.updateAllFail(scope, response, count);
              });
            }
            else{
              ProxyService.http(scope.ITEMNAME + encodeURIComponent($.trim(item.TypeID))).post(JSON.stringify(item))
              .then(function (response) {
                ProxyService.responseHandler.updateAllSuccess(scope, response, count);
              }, function (response) {
                ProxyService.responseHandler.updateAllFail(scope, response, count);
              });
            }
          }
        };

        // 6. 初始化
        this.initialize = function (scope)
        {
          scope.messageTips.showLoading();
          ProxyService.http(scope.ITEMNAME).get()
          .then(function(response)
          {         
            ProxyService.responseHandler.loadSuccess(scope, response);
          }, function (response)
          {
            ProxyService.responseHandler.loadFail(scope, response);
          });
        };

  });
