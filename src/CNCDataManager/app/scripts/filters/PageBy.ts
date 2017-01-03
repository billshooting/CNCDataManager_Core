import * as angular from 'angular';
import { IFilterPageBy } from '../types/CncSelection'

export default function PageBy(): IFilterPageBy {
    return function(items: any[], paginationIndex: number, paginationSize: number): any[] {
        if(!items) return [];
        let start = (paginationIndex - 1) * paginationSize;
        let end = paginationIndex * paginationSize;
        end = end <= items.length? end : items.length;
        return items.slice(start, end);
    };
}