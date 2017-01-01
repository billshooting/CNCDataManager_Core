
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

interface ISelectionPartScope extends angular.IScope {
    nextStep: () => void;
    reset: () => void;
}

export { ISelectionAxis };
export { ISelectionData };
export { ISelectionStateScope };
export { ISelectionPartScope };