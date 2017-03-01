import Account from './Account';

export default function registerAccountControllers(app: angular.IModule)
{
    app.controller('AccountCtrl', Account);
};
