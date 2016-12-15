import 'angular-strap';
/**
 * This is angular scope type definition used in cncdatamanagner.
 */

interface IItem{
    TypeID: string;
    isUpdate?: boolean & undefined;
}

interface IHandlingItems{
    deletingItem: IItem;
    addingItem: IItem;
    updatingItem: IItem;
}

interface ICncDataScope extends angular.IScope{
    deleteItemModal: mgcrea.ngStrap.modal.IModal;
    addItemModal: mgcrea.ngStrap.modal.IModal;

    ITEMNAME: string;
    items: IItem[];
    addingItems: IItem[];
    handlingItems: IHandlingItems;
    orderProperty: string;
    colState: boolean[];
    processSequence: number;

    toggleCol: (id: number, e: BaseJQueryEventObject) => void;
    changeOrderProperty: (property: string) => void;
    showDeleteModal: (item: IItem) => void;
    deleteItemLocal: (item: IItem) => void;
    deleteItemRemote: () => void;
    showAddModal: () => void;
    addItemLocal: () => void;
    addItemRemote: (item: IItem) => void;
    updateItemLocal: (item: IItem) => void;
    updateItemsRemote: () => void;
}

interface ITableHandler {
    toggleCol: (id: number, e: BaseJQueryEventObject) => void;
    changeOrderProperty: (property: string) => void;
    showDeleteModal: (item: IItem) => void;
    deleteItemLocal: (item: IItem) => void;
    deleteItemRemote: () => void;
    showAddModal: () => void;
    addItemLocal: () => void;
    addItemRemote: (item: IItem) => void;
    updateItemLocal: (item: IItem) => void;
    updateItemsRemote: () => void;
} 

export { IItem };
export { IHandlingItems };
export { ICncDataScope };
export { ITableHandler };