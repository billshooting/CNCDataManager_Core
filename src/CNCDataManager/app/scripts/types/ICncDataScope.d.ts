
/**
 * This is angular scope type definition used in cncdatamanagner.
 */

interface IItem{
    TypeID: string;
}

interface IHandlingItems{
    deletingItem: IItem;
    addingItem: IItem;
    updatingItem: IItem;
}

interface ICncDataScope extends angular.IScope{
    ITEMNAME: string;
    items: IItem[];
    addingItems: IItem[];
    handlingItems: IHandlingItems;
    orderProperty: string;
    colState: boolean[];
    processSequence: number;

    toggleCol: any;
    changeOrderProperty: any;
    showDeleteModal: any;
    deleteItemLocal: any;
    deleteItemRemote: any;
    showAddModal: any;
    addItemLocal: any;
    addItemRemote: any;
    updateItemLocal: any;
    updateItemsRemote: any;
}

export {IItem};
export {IHandlingItems};
export {ICncDataScope};