import * as angular from 'angular';

export default function registerAccountRoute(app: angular.IModule): void
{
    app.config(($locationProvider: angular.ILocationProvider,
        $stateProvider: angular.ui.IStateProvider,
        $urlRouterProvider: angular.ui.IUrlRouterProvider) => {

        $locationProvider.hashPrefix('!');

        $stateProvider
            .state('account', 
            {
                url: '/account',
                templateUrl: './views/account/account.html',
                controller: 'AccountCtrl'
            })
            .state('account.ChangePassword',
            {
                url: '/changepassword',
                views: 
                {
                    'content@account': { templateUrl: './views/account/changepw.html' },
                }                
            })
            .state('account.AddInfo',
            {
                url: '/addinfo',
                views:
                {
                    'content@account': { templateUrl: './views/account/addinfo.html' },
                }
            })
            .state('account.ManageUser',
            {
                url: '/manageuser',
                views:
                {
                    'content@account': { templateUrl: './views/account/manageuser.html' },
                }
            });

            $urlRouterProvider.otherwise('/home');
    });
};