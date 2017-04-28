interface ILoginScope extends angular.IScope
{
    isAuthenticated: boolean;
    companies: any[];
    user: {
        name: string;
        companyName: string;
        logout: () => void;
    };
    tourist: {
        loginUserName?: string;
        loginPassword?: string;
        registerEmail?: string;
        registerUserName?: string;
        registerCompany?: string;
        registerPassword?: string;
        registerConfirmPassword: string;
        login: () => void;
        register: () => void;
    }
    showLoginModal: () => void;
    showRegisterModal: () => void;
}

interface IRegisterModel {
    email: string;
    username: string;
    company: string;
    password: string;
}
interface ILoginModel {
    username: string;
    password: string;
}

export { ILoginScope };
export { IRegisterModel };
export { ILoginModel };