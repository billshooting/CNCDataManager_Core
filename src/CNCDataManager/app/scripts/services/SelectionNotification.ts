import * as angular from 'angular';
import { ISelectionStateScope, ISelectionData } from '../types/ISelectionStateScope';

export default class SelectionNotification {
    private scopes: ISelectionStateScope[];
 
    public constructor()
    {
        this.scopes = new Array<ISelectionStateScope>();
    }

    public registerNotification(...listeners: ISelectionStateScope[]): void
    {
        if(listeners)
        {
            for (let listener of listeners) this.scopes.push(listener);
        }
    }

    public deregisterNotification(...listeners: ISelectionStateScope[]): void
    {
        if(listeners)
        {
            let temp: ISelectionStateScope[] = [];
            this.scopes.forEach(scope => {
                if(listeners.indexOf(scope) < 0) temp.push(scope);
            })
            this.scopes = temp;
        }
    }

    public notifyChange(change: (data: ISelectionData) => void): void
    {
        this.scopes.forEach(scope => {
            change(scope.data);
            scope.changeHandler();
        });
    }

};