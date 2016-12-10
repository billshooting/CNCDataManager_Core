import * as angular from 'angular';

let $$injector;

/**
 * inject方法可以作为一个注解，帮助类获得angular的内置的服务
 */
export const inject = (services: string[]) => {
  if (!services || !services.length) {
    return;
  }
  let service: any;
  return function(Target: any) {
      angular.module('cncDataManager').run(['$injector', ($injector: any) => {
      $$injector = $injector;
      angular.forEach(services, (name: string, index: number) => {
        try {
          service = $injector.get(name);
          Target.prototype[name] = service;
        } catch (error) {
          console.error(error);
        }
      });
    }]);
  };
};