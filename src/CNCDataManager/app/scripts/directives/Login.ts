import * as angular from 'angular';
import User from '../services/User';
import MessageTips from '../services/MessageTips';
import { ILoginScope, IRegisterModel, ILoginModel } from '../types/CncAccount';

let Login: angular.IDirectiveFactory = (user: User, messageService: MessageTips): angular.IDirective => {
    return {
        templateUrl: './views/directives/login.html',
        restrict: 'E',
        scope: true,
        link: (scope: ILoginScope, ele: Element, attr: Attr) => 
        {
            /** 同步视图和服务之间的状态，User服务中的状态永远是最新的 */
            let stateSync = () => 
            {
                scope.isAuthenticated = user.IsAuthenticated;
                scope.user.name = user.Name;
                scope.user.companyName = user.CompanyName;
            }
            let init = () => 
            {
                scope.isAuthenticated = user.IsAuthenticated;
                scope.companies = [
                    { id: 'HNC', name: '华中数控' },
                    { id: 'GSK', name: '广州数控' },
                    { id: 'LT', name: '沈阳高精' },
                    { id: 'BJHT', name: '北京航天' },
                    { id: 'GONA', name: '大连光洋'},
                    { id: 'DMTG', name: '大连机床'},
                    { id: 'OHTER', name: '其他'}
                ]
                scope.user = 
                {
                    name: user.Name,
                    companyName: user.CompanyName,
                    logout: () => 
                    {
                        user.logout();
                        stateSync();
                    },
                };
                scope.tourist = 
                {
                    loginUserName: null,
                    loginPassword: null,
                    registerEmail: null,
                    registerUserName: null,
                    registerCompany: 'HNC',
                    registerPassword: null,
                    registerConfirmPassword: null,
                    login: () => 
                    {
                        messageService.showLoading();
                        let loginData: ILoginModel = { username: scope.tourist.loginUserName, password: scope.tourist.loginPassword };
                        user.login(loginData, response => 
                        {
                            messageService.hideLoading();
                            if(response.status === 204) { messageService.showError('登陆失败，可能是服务器没有接受你的输入。'); }
                            stateSync();
                        }, response => 
                        {
                            messageService.hideLoading();
                            if(response.status === 409) { messageService.showError ('登陆失败，' + response.data); }
                            else 
                            {
                                let error = response.statusText || '服务器或者网络连接有问题';
                                messageService.showError(error);
                            }
                        });
                        stateSync();
                    },
                    register: () => 
                    {
                        messageService.showLoading();
                        let registerData: IRegisterModel = { 
                            email: scope.tourist.registerEmail, 
                            username: scope.tourist.registerUserName, 
                            company: scope.tourist.registerCompany,
                            password: scope.tourist.registerPassword 
                        };
                        user.register(registerData, response => 
                        {
                            messageService.hideLoading();
                            if(response.status === 200) { messageService.showMsg('注册成功，欢迎你：' + response.data.userName); }
                            else if(response.status === 204) { messageService.showError('注册失败，该服务可能未开放。'); }
                            stateSync();
                        }, response => 
                        {
                            messageService.hideLoading();
                            if(response.status === 409) { messageService.showError('注册失败，您的用户名已被占用。'); }
                            else 
                            { 
                                let error = response.statusText || '服务器或者网络连接有问题';
                                messageService.showError(error);
                            }
                        });                      
                    },
                };
                scope.showLoginModal = () => { ($('#loginModal') as any).modal({focus: true}); };
                scope.showRegisterModal = () => { ($('#registerModal') as any).modal({focus: true}); };
                user.isLogin(stateSync);
            };
            init();
        }
    };
};
Login.$inject = ['User', 'MessageTips'];
export default Login;