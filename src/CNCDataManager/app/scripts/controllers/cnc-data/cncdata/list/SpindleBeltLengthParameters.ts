import * as angular from 'angular';
import { ICncDataScope, IItem, IHandlingItems, ITableHandler } from '../../../../types/CncData';
import TableHandler from '../../../../services/TableHandler';

export class SpindleBeltLengthParameters {
    private tableHandler: TableHandler;

    public constructor(tableHandler: TableHandler, $scope: ICncDataScope)
    {
        this.tableHandler = tableHandler;
        // 0. 辅助方法声明
        $scope.ITEMNAME = 'spindlebeltlengths/';

        // 1. scope模型初始化
        $scope.items = [];                                                 //所有数据，get发回的json数据
        $scope.addingItems = [];                                           //添加数据时所需的缓存数组，待远程确认之后加入到items中
        $scope.handlingItems = {
            deletingItem: null, addingItem: null, updatingItem: null
        };      //将要处理的数据行
        $scope.orderProperty = 'LengthID';                                   //当前排序的列名
        $scope.colState = [true, true, true, true, true, true, true];  //控制是否显示
        $scope.processSequence = 0;

        // 2. 添加表格显示方法
        let handler = tableHandler.buildTableHandler($scope);
        $scope.toggleCol = handler.toggleCol;
        $scope.changeOrderProperty = handler.changeOrderProperty;
        $scope.showDeleteModal = handler.showDeleteModal;
        $scope.deleteItemLocal = handler.deleteItemLocal;
        $scope.deleteItemRemote = handler.deleteItemRemote;
        $scope.showAddModal = handler.showAddModal;
        $scope.addItemLocal = handler.addItemLocal;
        $scope.addItemRemote = handler.addItemRemote;
        $scope.updateItemLocal = handler.updateItemLocal;
        $scope.updateItemsRemote = handler.updateItemsRemote;

        //  获取数据初始化DOM
        this.tableHandler.initialize($scope);
    }
};

SpindleBeltLengthParameters.$inject = ['TableHandler', '$scope'];