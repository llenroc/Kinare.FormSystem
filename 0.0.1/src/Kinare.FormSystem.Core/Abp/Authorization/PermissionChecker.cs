using Abp.Authorization;
using Kinare.FormSystem.Authorization.Roles;
using Kinare.FormSystem.Authorization.Users;

namespace Kinare.FormSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
