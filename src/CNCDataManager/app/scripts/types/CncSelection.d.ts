/**SideMenu Type Definition */
interface IObjectState {
    IsSelected: boolean;
    IsShown: boolean;
    [prop: string]: any;
}

interface ISelectionObject extends IObjectState {
    TypeID: string;
    Manufacturer?: string;
    SupportType?: string;
    ImgUrl?: string,
    [prop: string]: any;
}

interface ISelectionAxis extends IObjectState {
    Guide: ISelectionObject;
    ScrewNuts: ISelectionObject;
    Bearings: ISelectionObject;
    Couplings: ISelectionObject;
    ServoMotor: ISelectionObject;
    ServoDriver: ISelectionObject;
    TransmissionMethod?: string;
    [prop: string]: ISelectionObject & any;
}

interface ISelectionData {
    CNCMachine: ISelectionObject;
    CNCSystem: ISelectionObject;
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
    filtratedItems: IItem[];
    state: {
        orderProperty: string;
        paginationIndex?: number;
        paginationSize?: number;
        pageNumber?: number;
        paginationAllIndex?: number[];
        colState?: boolean[];
        filtrateConditions?: any;
    };
    data: {
        selectedItem: any;
        selectedTypeID: string;
    };
    changeOrderProperty: (property: string) => void;
    selectItem: (item: IItem) => void;
    toggleCol?: (id: number, e: BaseJQueryEventObject) => void;
    changePaginationSize?: () => void;  /** 修改当前页面显示的数据条数 通常是10 20 30 */
    changePaginationIndex?: (index: number) => void; /** 修改当前的页数 */
    changeFilter?: () => void; /** 修改当前页面的刷选条件，主要是为了修改分页条的数目 */
    previousPage?: () => void; /** 分页功能：上一页 */
    nextPage?: () => void;     /** 分页功能：下一页 */
    goDetails?: (item: IItem) => void;
}

interface ISelectionTableHandler {
    toggleCol: (id: number, e: BaseJQueryEventObject)=> void;
    changeOrderProperty: (property: string)=> void;
    selectItem?: (item: IItem) => void;
    changePaginationSize?: () => void;
    changeFilter?: (filerName: string) => () => void;
    goDetails?: (item: IItem) => void;
    reset?: () => void;
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
        filtrateConditions?: any;
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
        filtrateConditions?: any;
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
        filtrateConditions?: any;
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
        filtrateConditions?: any;
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
        filtrateConditions?: any;
        axisID: string,
        manufacturerOptions: string[];
        voltageOptions: any[];                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
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
        filtrateConditions?: any;
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

interface ISelectionDefaultValue {
    guideFriction: number,   //导轨库伦摩擦系数
	guideSealingResistance: number,   //滚动导轨的密封阻力
	guideType: string,
	ballscrewShaftDia: number,   //滚珠丝杠联轴器配合轴孔直径
	ballscrewMaxSpeed: number,   //滚珠丝杠极限转速
	ballscrewAccuracyClass: number,   //滚珠丝杠精度等级
	ballscrewLead: number,   //滚珠丝杠计算结果导程
	ballscrewTorque: number,   //滚珠丝杠计算结果等效负载转矩
	ballscrewNominalDiameter_d0: number,
	ballscrewLength: number,
}

export { ISelectionObject }
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
export { ISelectionDefaultValue };