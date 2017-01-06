import * as angular from 'angular';
import HttpProxy from './HttpProxy';
import MessageTips from './MessageTips';
import { ISelectionTableScope, ISelectionTableHandler} from '../types/CncSelection';

export default class SelectionTableHandler {
    private httpProxy: HttpProxy;
    private message: MessageTips;

    public constructor(http: HttpProxy, message: MessageTips)
    {
        this.httpProxy = http;
        this.message = message;
    }

    public buildTableHandler(scope: ISelectionTableScope): ISelectionTableHandler
    {
        return {
            toggleCol: function (id: number, e: BaseJQueryEventObject): void {
                if (scope.state.colState[id]) {
                    scope.state.colState[id] = false;
                    angular.element(e.currentTarget).removeClass('cncdata-table-col-checked');
                }
                else {
                    scope.state.colState[id] = true;
                    angular.element(e.currentTarget).addClass('cncdata-table-col-checked');
                }
            },
            changeOrderProperty: function (property: string): void {
                if (property === scope.state.orderProperty) {
                    scope.state.orderProperty = '-' + property;
                } else {
                    scope.state.orderProperty = property;
                }
            }
        };
    }

    public Initialize(scope: ISelectionTableScope): void {
        this.message.showLoading();
        this.httpProxy.http(scope.ITEMNAME)
                      .get()
                      .then((response: any) => { this.httpProxy.loadSuccess(scope, response); scope.changePaginationSize(); },
                            (response: any) => { this.httpProxy.loadFail(scope, response); });
    }

};
SelectionTableHandler.$inject = ['HttpProxy', 'MessageTips'];