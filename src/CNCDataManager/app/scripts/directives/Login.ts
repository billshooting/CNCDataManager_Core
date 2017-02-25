import * as angular from 'angular';
import User from '../services/User';
import { ILoginScope } from '../types/CncAccount';

let Login: angular.IDirectiveFactory = (user: User): angular.IDirective => {
    return {
        templateUrl: './views/directives/login.html',
        restrict: 'E',
        scope: true,
        link: (scope: ILoginScope, ele: Element, attr: Attr) => {
            /** 同步视图和服务之间的状态，User服务中的状态永远是最新的 */
            let stateSync = () => {
                scope.isAuthenticated = user.IsAuthenticated;
                scope.user.name = user.Name;
            }
            let init = () => {
                scope.isAuthenticated = user.IsAuthenticated;
                scope.user = {
                    name: user.Name,
                    logout: () => {
                        let result = user.logout();
                        stateSync();
                        return result;
                    },
                };
                scope.tourist = {
                    loginUserName: null,
                    loginPassword: null,
                    registerEmail: null,
                    registerUserName: null,
                    registerPassword: null,
                    registerConfirmPassword: null,
                    login: () => {
                        let loginForm = document.getElementById('loginForm') as HTMLFormElement;
                        let loginData = new FormData(loginForm);
                        let result = user.login(loginData);
                        stateSync();
                        return result;
                    },
                    register: () => {
                        let registerForm = document.getElementById('registerForm') as HTMLFormElement;
                        let registerData = new FormData(registerForm);
                        let result = user.register(registerData);
                        stateSync();
                        return result;
                    },
                };
            };

            init();
        }
    };
};
Login.$inject = ['User']
export default Login;