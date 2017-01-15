import * as angular from 'angular';
import {IFilterCNCSystemFiltrate, ICNCSystemFilterConditions} from '../types/CncSelection';

export default function (): IFilterCNCSystemFiltrate {
    return function (items: any[], conditions: ICNCSystemFilterConditions): any[]{
        let result: any[] = [];
        if(items)
        {
            items.forEach(item => {
                if((conditions.Manufacturer === '所有厂商' || item.Manufacturer === conditions.Manufacturer) &&
                   item.SupportMachineType.indexOf(conditions.SupportMachineType) >= 0 &&
                   item.SupportChannels >= conditions.SupportChannels &&
                   item.MaxNumberOfFeedShafts >= conditions.MaxNumberOfFeedShafts)
                {
                    result.push(item);
                }                   
            });
        }
        return result;
    };
};