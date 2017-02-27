interface ILoginScope extends angular.IScope
{
    isAuthenticated: boolean;
    user: {
        name: string;
        logout: () => void;
    };
    tourist: {
        loginUserName?: string;
        loginPassword?: string;
        registerEmail?: string;
        registerUserName?: string;
        registerPassword?: string;
        registerConfirmPassword: string;
        login: () => void;
        register: () => void;
    }
}

interface IRegisterModel {
    email: string;
    username: string;
    password: string;
}
interface ILoginModel {
    username: string;
    password: string;
}

export { ILoginScope };
export { IRegisterModel };
export { ILoginModel };