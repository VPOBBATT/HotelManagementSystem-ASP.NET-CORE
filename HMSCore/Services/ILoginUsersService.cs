using DataLayer.Models;
using HMSCore.Models.LoginUsers;
using System.Threading.Tasks;

namespace HMSCore.Services
{
    public interface ILoginUsersService
    {
        Task Login(User user);

        Task<User> IsUserExist(LoginUsersFormModel user);

        Task<bool> IsPasswordCorrect(User user, LoginUsersFormModel userFormModel);

        Task LogOut();
    }
}