'use strict';

/**
 * @ngdoc service
 * @name cncdataManagerApp.ProxyService
 * @description
 * # ProxyService
 * Service in the cncdataManagerApp.
 */
angular.module('cncdataManagerApp')
  .service('ProxyService', function ($http, $q) {
    // AngularJS will instantiate a singleton by calling "new" on this function
    const BASE = '/';
    //const BASE = 'http://localhost:9000/';
    const PATH = 'api/cncdata/';

    var getUrl = function (uri){ return BASE + PATH + uri; };

    this.http = function (uri)
    {
      var url = getUrl(uri);
      var deferred = $q.defer();
      var promise = deferred.promise;
      return {
        'get': function () {
          $http.get(url).then(
            function (response) { deferred.resolve(response); }, 
            function (response) { deferred.reject(response); });
          return promise;
        },
        'post': function (body) {
          $http.post(url, body).then(
            function (response) { deferred.resolve(response); },
            function (response) { deferred.resolve(response); });
          return promise;
        },
        'put': function (body) {
          $http.put(url, body).then(
            function (response) { deferred.resolve(response); },
            function (response) { deferred.reject(response); });
          return promise;
        },
        'delete': function () {
          $http.delete(url).then(
            function (response) { deferred.resolve(response); },
            function (response) { deferred.reject(response); });
          return promise;
        }
      };
    };

    this.responseHandler = {
          loadSuccess : function (scope, response) {
            if (response.status < 300)
            {
              scope.items = response.data;
              scope.messageTips.hideLoading();
            }
            else
            {
              var msg = '错误信息:' + response.status + ' ' + response.statusText;
              if(response.message !== undefined)
              {
                msg = '错误信息:' + response.message;
              }
              scope.messageTips.hideLoading();
              scope.messageTips.showError(msg);
            }
          },
          loadFail : function (scope, response) {
            var msg = '错误信息:' + response.status + ' ' + response.statusText;
            if(response.message !== undefined)
            {
               msg = '错误信息:' + response.message;
            }
            scope.messageTips.hideLoading();
            scope.messageTips.showError(msg);
          },
          addSuccess: function (scope, response, item) {
            if(response.status < 300)
            {
              _.remove(scope.items, function (m) { return m.TypeID === item.TypeID; });
              scope.items.push(item);
              _.remove(scope.addingItems, item);
              scope.messageTips.hideLoading();
            }
            else
            {
              var msg = '错误信息:' + response.status + ' ' + response.statusText;
              scope.messageTips.hideLoading();
              scope.messageTips.showError(msg);
            }           
          },
          addFail : function (scope, response) {
            var msg = '错误信息:' + response.status + ' ' + response.statusText;
            scope.messageTips.hideLoading();
            scope.messageTips.showError(msg);
          },
          deleteSuccess: function (scope, response) {
            if(response.status < 300)
            {
              _.remove(scope.items, function(s){ return s.TypeID === scope.handlingItems.deletingItem.TypeID; });
              scope.handlingItems.deletingItem = null;
              scope.messageTips.hideLoading();
            }
            else
            {
              var msg = '错误信息:' + response.status + ' ' + response.statusText;
              scope.handlingItems.deletingItem = null;
              scope.messageTips.hideLoading();
              scope.messageTips.showError(msg);
            }
          },
          deleteFail : function (scope, response) {
            var msg = '错误信息:' + response.status + ' ' + response.statusText;
            scope.handlingItems.deletingItem = null;
            scope.messageTips.hideLoading();
            scope.messageTips.showError(msg);
          },
          updateAllSuccess : function (scope, response, count) {
            let ID = JSON.parse(response.config.data).TypeID;
            let item = _.find(scope.addingItems, function (i) { return i.TypeID === ID; });
            if(response.status < 300)
            {
              scope.processSequence++;
              _.remove(scope.items, function (m) { return m.TypeID === item.TypeID; });
              scope.items.push(item);
              _.remove(scope.addingItems, function (m) { return m.TypeID === item.TypeID; });
              scope.messageTips.showUpdate(scope.processSequence, count);
            }
            else
            {
              var msg = '错误信息:型号为' + ID +  '数据处理错误 ' + response.status + ' ' + response.statusText + '\n';
              scope.messageTips.showUpdate(scope.processSequence, count, msg);
            }
          },
          updateAllFail : function (scope, response, count) {
            let ID = JSON.parse(response.config.data).TypeID;
            var msg = '错误信息:型号为' + ID + '某条数据处理错误 ' + response.status + ' ' + response.statusText + '\n';
            scope.messageTips.showUpdate(scope.processSequence, count, msg);
          }
    };
  });
