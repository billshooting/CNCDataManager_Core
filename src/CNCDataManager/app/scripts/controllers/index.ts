import * as angular from 'angular';
import { HomeController } from './home/home';
import { AboutController } from './home/about';
import { ContactController } from './home/contact';

export default function registerControllers(app: angular.IModule): void
{
    app.controller('HomeCtrl', HomeController);
    app.controller('AboutCtrl', AboutController);
    app.controller('ContactCtrl', ContactController);
}