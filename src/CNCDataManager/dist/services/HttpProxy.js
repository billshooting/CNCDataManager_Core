/**
 * 前端页面的http处理封装
 */
System.register(["lodash", "../bases/utility"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var _, utility_1, HttpProxy;
    return {
        setters: [
            function (_1) {
                _ = _1;
            },
            function (utility_1_1) {
                utility_1 = utility_1_1;
            }
        ],
        execute: function () {
            HttpProxy = (function () {
                function HttpProxy() {
                    this.BASE = '/';
                    //const BASE = 'http://localhost:9000/';
                    //const BASE = 'http://localhost:5000/';
                    this.PATH = 'api/cncdata/';
                    this.responseHandler = {
                        loadSuccess: function (scope, response) {
                            if (response.status < 300) {
                                scope.items = response.data;
                            }
                            else {
                                var msg = '错误信息:' + response.status.toString() + ' ' + response.statusText;
                                if (response.message !== undefined)
                                    msg = '错误信息:' + response.message;
                            }
                        },
                        loadFail: function (scope, response) {
                            var msg = '错误信息:' + response.status + ' ' + response.statusText;
                            if (response.message !== undefined)
                                msg = '错误信息:' + response.message;
                            //scope.messageTips.hideLoading();
                            //scope.messageTips.showError(msg);
                        },
                        addSuccess: function (scope, response, item) {
                            if (response.status < 300) {
                                _.remove(scope.items, function (m) { return m.TypeID === item.TypeID; });
                                scope.items.push(item);
                                _.remove(scope.addingItems, item);
                            }
                            else {
                                var msg = '错误信息:' + response.status + ' ' + response.statusText;
                            }
                        },
                        addFail: function (scope, response) {
                            var msg = '错误信息:' + response.status + ' ' + response.statusText;
                            //scope.messageTips.hideLoading();
                            //scope.messageTips.showError(msg);
                        },
                        deleteSuccess: function (scope, response) {
                            if (response.status < 300) {
                                _.remove(scope.items, function (s) { return s.TypeID === scope.handlingItems.deletingItem.TypeID; });
                            }
                            else {
                                var msg = '错误信息:' + response.status + ' ' + response.statusText;
                                scope.handlingItems.deletingItem = null;
                            }
                        },
                        deleteFail: function (scope, response) {
                            var msg = '错误信息:' + response.status + ' ' + response.statusText;
                            scope.handlingItems.deletingItem = null;
                            //scope.messageTips.hideLoading();
                            //scope.messageTips.showError(msg);
                        },
                        updateAllSuccess: function (scope, response, count) {
                            var ID = JSON.parse(response.config.data).TypeID;
                            var item = _.find(scope.addingItems, function (m) { return m.TypeID === ID; });
                            if (response.status < 300) {
                                scope.processSequence++;
                                _.remove(scope.items, function (m) { return m.TypeID === item.TypeID; });
                                scope.items.push(item);
                                _.remove(scope.addingItems, function (m) { return m.TypeID === item.TypeID; });
                            }
                            else {
                                var msg = '错误信息:型号为' + ID + '数据处理错误 ' + response.status + ' ' + response.statusText + '\n';
                            }
                        },
                        updateAllFail: function (scope, response, count) {
                            var ID = JSON.parse(response.config.data).TypeID;
                            var msg = '错误信息:型号为' + ID + '某条数据处理错误 ' + response.status + ' ' + response.statusText + '\n';
                            //scope.messageTips.showUpdate(scope.processSequence, count, msg);
                        },
                    };
                }
                HttpProxy.prototype.getUrl = function (uri) { return this.BASE + this.PATH + uri; };
                ;
                HttpProxy.prototype.http = function (uri) {
                    var url = this.getUrl(uri);
                    var deffered = this.$q.defer();
                    var promise = deffered.promise;
                    var $http = this.$http;
                    return {
                        get: function () {
                            $http.get(url).then(function (response) { return deffered.resolve(response); }, function (response) { return deffered.reject(response); });
                            return promise;
                        },
                        post: function (data) {
                            $http.post(url, data).then(function (response) { return deffered.resolve(response); }, function (response) { return deffered.reject(response); });
                            return promise;
                        },
                        put: function (data) {
                            $http.put(url, data).then(function (response) { return deffered.resolve(response); }, function (response) { return deffered.reject(response); });
                            return promise;
                        },
                        delete: function () {
                            $http.delete(url).then(function (response) { return deffered.resolve(response); }, function (response) { return deffered.reject(response); });
                            return promise;
                        }
                    };
                };
                return HttpProxy;
            }());
            HttpProxy = __decorate([
                utility_1.inject(['$http', '$q'])
            ], HttpProxy);
            exports_1("default", HttpProxy);
        }
    };
});
