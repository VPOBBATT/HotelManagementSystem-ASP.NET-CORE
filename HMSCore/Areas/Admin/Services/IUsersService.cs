using HMSCore.Areas.Admin.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMSCore.Areas.Admin.Services
{
    public interface IUsersService
    {
        Task<IdentityResult> Register(RegisterUserFormModel user);

        Task<IEnumerable<ListUserViewModel>> All();

        Task ChangePassword(ChangePasswordUserFormModel user);

        Task<ChangePasswordUserFormModel> GetUser(string id);

        Task Delete(string id);

        Task<ChangeUserRoleFormModel> LoadRoles(string id);

        Task ChangeRole(ChangeUserRoleFormModel user);

    }
}
