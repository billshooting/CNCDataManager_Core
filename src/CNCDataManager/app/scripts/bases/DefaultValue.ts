import * as angular from 'angular';
import { ISelectionDefaultValue } from '../types/CncSelection';

export default function registerDefaultValue (app: angular.IModule)
{
    app.value<ISelectionDefaultValue>('default',{
        guideFriction:0.003,   //导轨库伦摩擦系数
        guideSealingResistance:100,   //滚动导轨的密封阻力
        guideType:"滚动导轨",
        ballscrewShaftDia:24,   //滚珠丝杠联轴器配合轴孔直径
        ballscrewMaxSpeed:8000,   //滚珠丝杠极限转速
        ballscrewAccuracyClass:1,   //滚珠丝杠精度等级
        ballscrewLead:5,   //滚珠丝杠计算结果导程
        ballscrewTorque:2,   //滚珠丝杠计算结果等效负载转矩
        ballscrewNominalDiameter_d0:30,
        ballscrewLength:1000,
    });
};