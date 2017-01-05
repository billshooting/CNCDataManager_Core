import * as angular from 'angular';
import { Selection } from './Selection';
import { MachineType } from './machine-type/MachineType';
import { MachineDetails } from './machine-type/MachineDetails';
import { CNCSystemType } from './cncsystem/CNCSystemType';
import { CNCSystemAccessories } from './cncsystem/CNCSystemAccessories';
import { FeedSystemLeftSide } from './feed-system/FeedSystemLeftSide';
import { SelectionGuides } from './feed-system/SelectionGuides';
import { SelectionScrewNuts } from './feed-system/SelectionScrewNuts';
import { SelectionBearings } from './feed-system/SelectionBearings';

export default function registerSelectionControllers(app: angular.IModule): void {
    app.controller('SelectionCtrl', Selection);
    app.controller('MachineTypeCtrl', MachineType);
    app.controller('MachineDetailsCtrl', MachineDetails);
    app.controller('CNCSystemTypeCtrl', CNCSystemType);
    app.controller('CNCSystemAccessoriesCtrl', CNCSystemAccessories);
    app.controller('FeedSystemLeftSideCtrl', FeedSystemLeftSide);
    app.controller('SelectionGuidesCtrl', SelectionGuides);
    app.controller('SelectionScrewNutsCtrl', SelectionScrewNuts);
    app.controller('SelectionBearingsCtrl', SelectionBearings);
}