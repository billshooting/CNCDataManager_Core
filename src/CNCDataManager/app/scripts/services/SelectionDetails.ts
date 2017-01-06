import * as angular from 'angular';
import HttpProxy from './HttpProxy';
import MessageTips from './MessageTips';
import { ISelectionDetailScope, ISelectionDetailHandler } from '../types/CncSelection';

export default class SelectionDetails {
    private component: string;
    private typeID: string;
    private item: any;
    private sizes: any;

    public constructor(){}

    set Component(value: string) { this.component = value; }
    get Component(): string { return this.component; }

    set TypeID(value: string) { this.typeID = value; }
    get TypeID(): string { return this.typeID; }

    set Item(value: any) { this.item = value; }
    get Item(): any { return this.item; }

    set Sizes(value: any) { this.sizes = value; }
    get Sizes(): any { return this.sizes; }
};