/**SideMenu Type Definition */
interface IObjectState {
    IsSelected: boolean;
    IsShown: boolean;
    [prop: string]: any;
}

interface ISelectionOject extends IObjectState {
    TypeID: string;
    Manufacturer?: string;
    SupportType?: string;
    ImgUrl?: string,
    [prop: string]: any;
}

interface ISelectionAxis extends IObjectState {
    Guide: ISelectionOject;
    ScrewNuts: ISelectionOject;
    Bearings: ISelectionOject;
    Couplings: ISelectionOject;
    ServoMotor: ISelectionOject;
    ServoDriver: ISelectionOject;
    [prop: string]: any;
}

interface ISelectionData {
    CNCMachine: ISelectionOject;
    CNCSystem: ISelectionOject;
    FeedSystemX: ISelectionAxis;
    FeedSystemY: ISelectionAxis;
    FeedSystemZ: ISelectionAxis;
    Spindle?: ISelectionAxis;
    [prop: string]: any;
}

interface ISelectionStateScope extends angular.IScope {
    data: ISelectionData;
    changeHandler: () => void;
}

/** Selection Controllers' Type Definition */
interface ISelectionPartScope extends angular.IScope {
    nextStep: () => void;
    reset: () => void;
}

import { IItem, ITableScope } from './CncData';
interface ISelectionTableScope extends ITableScope, ISelectionPartScope {
    ITEMNAME: string;
    items: IItem[];
    state: {
        orderProperty: string;
        paginationIndex?: number;
        paginationSize?: number;
        pageNumber?: number;
        paginationAllIndex?: number[];
        colState?: boolean[];
    };
    data: {
        selectedItem: any;
        selectedTypeID: string;
    };
    changeOrderProperty: (property: string) => void;
    selectItem: (item: IItem) => void;
    toggleCol?: (id: number, e: BaseJQueryEventObject) => void;
    changePaginationSize?: () => void;
    changePaginationIndex?: (index: number) => void;
    previousPage?: () => void;
    nextPage?: () => void;
    goDetails?: (item: IItem) => void;
}

interface ISelectionTableHandler {
    toggleCol: (id: number, e: BaseJQueryEventObject)=> void;
    changeOrderProperty: (property: string)=> void;
    selectItem?: (item: IItem) => void;
    changePaginationSize?: () => void;
    goDetails?: (item: IItem) => void;
}

/** PageBy Filter Type Definition */
interface IFilterPageBy{
    (items: any[], paginationIndex: number, paginationSize: number): any[];
}

/** CNCSystem Selection Type */
interface ICNCSystemFilterConditions {
    Manufacturer: string;
    SupportChannels: number;
    MaxNumberOfFeedShafts: number;
    SupportMachineType: string;
}
interface IFilterCNCSystemFiltrate {
    (items: any[], conditions: ICNCSystemFilterConditions): any[];
}

interface ICNCSystemSelectionScope extends ISelectionTableScope {
    filtratedItems: IItem[];
    state: {
        filtrateConditions: ICNCSystemFilterConditions;
        ManufacturerOptions: string[];
        orderProperty: string;
        paginationIndex?: number;
        paginationSize?: number;
        pageNumber?: number;
        paginationAllIndex?: number[];
        colState?: boolean[];
    };
}

/** Guide Selection Type */
interface IGuideScope extends ISelectionTableScope {
    state: {
        orderProperty: string;
        paginationIndex?: number;
        paginationSize?: number;
        pageNumber?: number;
        paginationAllIndex?: number[];
        colState?: boolean[];
        axisID: string,
        imgUrl: string
    };
}

/** ScrewNuts Selection Type */
interface IScrewNutsScope extends ISelectionTableScope {
    state: {
        orderProperty: string;
        paginationIndex?: number;
        paginationSize?: number;
        pageNumber?: number;
        paginationAllIndex?: number[];
        colState?: boolean[];
        axisID: string,
    };
}

/** Bearings Selection Type */
interface IBearingsScope extends ISelectionTableScope {
    state: {
        orderProperty: string;
        paginationIndex?: number;
        paginationSize?: number;
        pageNumber?: number;
        paginationAllIndex?: number[];
        colState?: boolean[];
        axisID: string,
        typeOptions: { name: string; type: string; url: string}[];
        currentType: { name: string; type: string; url: string},
    };
    changeCurrentType: () => void;
}

/** Couplings Selection Type */
interface ICouplingsScope extends ISelectionTableScope {
    state: {
        orderProperty: string;
        paginationIndex?: number;
        paginationSize?: number;
        pageNumber?: number;
        paginationAllIndex?: number[];
        colState?: boolean[];
        axisID: string,
        typeOptions: { name: string; url: string}[];
        currentType: { name: string; url: string},
    };
    changeCurrentType: () => void;
}

/** ServoMotor Selection Type */
interface IServoMotorScope extends ISelectionTableScope {
    state: {
        orderProperty: string;
        paginationIndex?: number;
        paginationSize?: number;
        pageNumber?: number;
        paginationAllIndex?: number[];
        colState?: boolean[];
        axisID: string,
        manufacturerOptions: string[];
        currentManufacturer: string,
    };
    changeCurrentType: () => void;
}

/** ServoMotor Selection Type */
interface IServoDriverScope extends ISelectionTableScope {
    state: {
        orderProperty: string;
        paginationIndex?: number;
        paginationSize?: number;
        pageNumber?: number;
        paginationAllIndex?: number[];
        colState?: boolean[];
        axisID: string,
        manufacturerOptions: string[];
        currentManufacturer: string,
    };
    changeCurrentType: () => void;
}

/** Selection Component Detail Scope */
interface ISelectionDetailScope{
    state: {
        axisID: string;
        imgUrl?: string;
    };
    item: IItem;
    sizes?: any;
    back: () => void;
}
interface ISelectionDetailHandler{

}

export { ISelectionAxis };
export { ISelectionData };
export { ISelectionStateScope };
export { ISelectionPartScope };
export { ISelectionTableScope };
export { ISelectionTableHandler };
export { IFilterPageBy };
export { ICNCSystemFilterConditions };
export { IFilterCNCSystemFiltrate };
export { ICNCSystemSelectionScope };
export { IGuideScope };
export { IScrewNutsScope };
export { IBearingsScope };
export { ICouplingsScope };
export { IServoMotorScope };
export { IServoDriverScope };
export { ISelectionDetailScope };
export { ISelectionDetailHandler };