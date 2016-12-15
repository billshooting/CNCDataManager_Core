import * as angular from 'angular';
import Header from './Header';
import BackToTop from './BackToTop';
import MsgDialog from './MsgDialog';
import ContentEditable from './ContentEditable';

export default function registerDirective(app: angular.IModule): void {
    app.directive('appHeader', Header);
    app.directive('backToTop', BackToTop);
    app.directive('msgDialog', MsgDialog);

    app.directive('contenteditable', ContentEditable);
};
