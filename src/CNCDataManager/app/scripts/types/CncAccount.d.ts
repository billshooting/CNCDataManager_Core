interface ILoginScope extends angular.IScope
{
    isAuthenticated: boolean;
    user: {
        name: string;
        logout: () => boolean;
    };
    tourist: {
        loginUserName?: string;
        loginPassword?: string;
        registerEmail?: string;
        registerUserName?: string;
        registerPassword?: string;
        registerConfirmPassword: string;
        login: () => boolean;
        register: () => boolean;
    }
}

export { ILoginScope };