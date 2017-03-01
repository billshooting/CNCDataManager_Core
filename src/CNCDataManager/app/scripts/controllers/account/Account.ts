interface IAccountScope extends angular.IScope
{
    user: 
    {
        name: string;
        role: string;
    }
    management:
    {
        users: any[];
        addUser: () => void;
        deleteUser: () => void;
    }
}
import User from '../../services/User'

export default class Account
{
    public constructor($scope: IAccountScope, user: User)
    {
        $scope.user = { name: user.Name, role: user.Role };
    }
};
Account.$inject = ['$scope', 'User'];