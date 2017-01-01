import * as angular from 'angular';
import Header from './Header';
import BackToTop from './BackToTop';
import MsgDialog from './MsgDialog';
import ProgressBar from './ProgressBar';
import SideMenu from './SideMenu';
import ContentEditable from './ContentEditable';

export default function registerDirective(app: angular.IModule): void {
    app.directive('appHeader', Header);
    app.directive('backToTop', BackToTop);
    app.directive('msgDialog', MsgDialog);
    app.directive('progressBar', ProgressBar);
    app.directive('sideMenu', SideMenu);

    app.directive('contenteditable', ContentEditable);
};
