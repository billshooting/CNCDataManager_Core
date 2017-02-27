export default function changeDefaultConfiguration(app: angular.IModule) {
    app.config(($httpProvider: angular.IHttpProvider) => {
        /** 在每次进行CorsAPI调用时，都发送Cookie */
        $httpProvider.defaults.withCredentials = true;
    });
};
changeDefaultConfiguration.$inject = ['$httpProvider'];