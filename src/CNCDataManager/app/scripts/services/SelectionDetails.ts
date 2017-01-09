import * as angular from 'angular';
import HttpProxy from './HttpProxy';
import MessageTips from './MessageTips';
import { ISelectionDetailScope, ISelectionDetailHandler } from '../types/CncSelection';

export default class SelectionDetails {
    private _component: string;
    private _typeID: string;
    private _item: any;
    private _sizes: any;

    public constructor(){}

    set component(value: string) { this._component = value; }
    get component(): string { return this._component; }

    set typeID(value: string) { this._typeID = value; }
    get typeID(): string { return this._typeID; }

    set item(value: any) { this._item = value; }
    get item(): any { return this._item; }

    set sizes(value: any) { this._sizes = value; }
    get sizes(): any { return this._sizes; }
};