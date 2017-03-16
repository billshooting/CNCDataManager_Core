import * as angular from 'angular';
import { ISelectionAxis, ISelectionObject } from './CncSelection';

interface ISimulationScope extends angular.IScope {
    data: {
        axisID: string;
        motor: {
            rotorMomentInertia: number;   
            polePairs: number;
            statorResistance: number;
            statorStrayInductance: number;
            mainFieldInductanceDaxis: number;
            mainFieldInductanceQaxis: number;
            opposingElectromotiveForce: number;
        };
        driver: {
            nominalVoltage: number;
            PWMCircle: number;
            KS: number;
            KV: number;
            polePairs: number;
            cellVoltage: number;
            KD: number;
            TD: number;
            TV: number;
        };
        ballscrew: {
            diameter: number;
            modulusofElasticty: number;
            shaftDistance: number;
            pitch: number;
            length: number;
            density: number;
            shearModulusofElasticty: number;
            campingCoefficient: number;
        };
        guide: {
            frictionFactor: number;
		    viscosityFriction: number;
        };
        bearings: {
            axisalStiffness: number;
		    startingMoment: number;
        };
        coupling: {
            stiffness: number;
		    momentInertia: number;
        };
        worktable: {
            mass: number;
            tighteningEfficiency: number;
            contactStiffness: number;
            dynamicLoadRating: number;
        };
        setting: {
            signal: string,
            startTime: number;
            endTime: number;
            stepSize: number;
            stepNum: number;
            alg: string;
            precision: number;
        };
    };
    changeStepNum: () => void;
    setDefaultMotorPara: () => void;
    setDefaultDriverPara: () => void;
    setDefaultMechanicalPara: () => void;
    setDefaultSimulationSettings: () => void;
    startSimulation: () => void;
    confirmStart:() => void;
}

interface ISimulationCompletedScope extends angular.IScope {
    simulationStarted: () => void;
    simulationCompleted: () => void;
    simulationFailed: (errorMsg: string) => void;
    showData: (type: string) => void;
    state: {
        isCompleted: boolean;
        progress: number;
    }
}

interface ISimulationChartScope extends ISimulationCompletedScope {
    state: {
        isCompleted: boolean;
        isStarted: boolean;
        progress: number;
        stateText: string;
    };
    report: {
        isShown: boolean;
        CNCMachine?: ISelectionObject;
        CNCSystem?: ISelectionObject;
        FeedSystemX?: ISelectionAxis;
        FeedSystemY?: ISelectionAxis;
        FeedSystemZ?: ISelectionAxis;
        Spindle?: ISelectionAxis;
        Components?: {typeID: string; manufacturer: string; name: string}[];
    };
    reportToggle: () => void;
    stateInit: () => void;
    reportInit: () => void;
    reportDownload: () => void;
}

interface IReportResult {
    MachineType: any;
    NCSystem: any;
    FeedSystemX: any;
    FeedSystemY: any;
    FeedSystemZ: any;
    Spindle: any;
}

export { ISimulationScope };
export { ISimulationCompletedScope };
export { ISimulationChartScope };
export { IReportResult };