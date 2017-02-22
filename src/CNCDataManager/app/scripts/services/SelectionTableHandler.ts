import * as angular from 'angular';
import HttpProxy from './HttpProxy';
import MessageTips from './MessageTips';
import SelectionDetails from './SelectionDetails';
import { ISelectionTableScope, ISelectionTableHandler} from '../types/CncSelection';
import { IItem } from '../types/CncData';

export default class SelectionTableHandler {
    private httpProxy: HttpProxy;
    private message: MessageTips;
    private filter: angular.IFilterService;
    private detail: SelectionDetails;
    private state: angular.ui.IStateService;

    public constructor(http: HttpProxy, 
                       message: MessageTips, 
                       $filter: angular.IFilterService, 
                       detail: SelectionDetails,
                       $state: angular.ui.IStateService)
    {
        this.httpProxy = http;
        this.message = message;
        this.filter = $filter;
        this.detail = detail;
        this.state = $state;
    }

    public buildTableHandler(scope: ISelectionTableScope): ISelectionTableHandler
    {
        let $filter = this.filter;
        let detail = this.detail;
        let $state = this.state;
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
            },
            selectItem: function (item: IItem): void {
                scope.data.selectedItem = item as any;
                scope.data.selectedTypeID = item.TypeID;
            },
            changePaginationSize: function (): void {
                let size = scope.state.paginationSize;
                let number = scope.state.pageNumber;
                scope.state.pageNumber = Math.ceil(scope.filtratedItems.length / size);
                let newNumber = scope.state.pageNumber;
                if(newNumber <= number) scope.state.paginationAllIndex = scope.state.paginationAllIndex.slice(0, newNumber);
                else{
                    for(let i = number + 1; i <= newNumber; i++)
                    {
                        scope.state.paginationAllIndex.push(i);
                    }
                }
                scope.state.paginationIndex = 1;
            },
            changePaginationIndex: function (index: number) {
                scope.state.paginationIndex = index;
            },
            changeFilter: function (filterName: string): () => void {
                return function (): void {
                    scope.filtratedItems = $filter<any>(filterName)(scope.items, scope.state.filtrateConditions);
                    scope.changePaginationSize();
                    scope.changePaginationIndex(1);
                };  
            },
            goDetails: function (item: IItem): void {
                detail.item = item;
                detail.typeID = item.TypeID;
                $state.go('.Details', {id: item.TypeID});
            },
            reset: function (): void {
                scope.data = { selectedTypeID: null, selectedItem: null };
            }
        };
    }

    public Initialize(scope: ISelectionTableScope): void {
        this.message.showLoading();
        this.httpProxy.http(scope.ITEMNAME)
                      .get()
                      .then((response: any) => { 
                          this.httpProxy.loadSuccess(scope, response); 
                          scope.changePaginationSize(); 
                          scope.changeFilter();
                        }, (response: any) => { this.httpProxy.loadFail(scope, response); });
    }

};
SelectionTableHandler.$inject = ['HttpProxy', 'MessageTips', '$filter', 'SelectionDetails', '$state'];