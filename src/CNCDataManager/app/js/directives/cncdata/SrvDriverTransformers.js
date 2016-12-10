'use strict';

/**
 * @ngdoc directive
 * @name cncdataManagerApp.directive:alignBallBrgsPanel
 * @description
 * # alignBallBrgsPanel
 */
angular.module('cncdataManagerApp')
  .directive('srvDriverTransformers', function (TableHandler, $modal) {
      return {
          templateUrl: '../App/views/templates/SrvDriverTransformers.html',
          restrict: 'E',
          scope: true,
          link: function postLink(scope) {
              // 0. 辅助方法声明
              scope.ITEMNAME = 'srvdrivertransformers/';
              scope.deleteItemModal = $modal({
                  scope: scope,
                  templateUrl: '../App/views/modals/confirmDeleteModal.html',
                  show: false
              });
              scope.addItemModal = $modal({
                  scope: scope,
                  templateUrl: '../App/views/modals/tryAddModal.html',
                  show: false
              });

              // 1. scope模型初始化
              scope.items = [];                                                 //所有数据，get发回的json数据
              scope.addingItems = [];                                           //添加数据时所需的缓存数组，待远程确认之后加入到items中
              scope.handlingItems = {
                  deletingItem: null, addingItem: null, updatingItem: null
              };      //将要处理的数据行
              scope.orderProperty = 'TypeID';                                   //当前排序的列名
              //scope.colState = [true, false, false, false, false, false, false];  //控制是否显示
              scope.processSequence = 0;

              // 2. 添加表格显示方法
              scope.toggleCol = TableHandler.toggleCol;
              scope.changeOrderProperty = TableHandler.changeOrderProperty;
              scope.showDeleteModal = TableHandler.showDeleteModal;
              scope.deleteItemLocal = TableHandler.deleteItemLocal;
              scope.deleteItemRemote = TableHandler.deleteItemRemote;
              scope.showAddModal = TableHandler.showAddModal;
              scope.addItemLocal = TableHandler.addItemLocal;
              scope.addItemRemote = TableHandler.addItemRemote;
              scope.updateItemLocal = TableHandler.updateItemLocal;
              scope.updateItemsRemote = TableHandler.updateItemsRemote;

              //  获取数据初始化DOM
              TableHandler.initialize(scope);
          }
      };
  });
