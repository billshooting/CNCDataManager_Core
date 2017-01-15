import * as angular from 'angular';

export default function (): any {
    return function (items: any[], conditions: any): any[] {
        let result: any[] = [];
        if(items)
        {
            items.forEach(item => result.push(item));
        }
        return result;
    };
};