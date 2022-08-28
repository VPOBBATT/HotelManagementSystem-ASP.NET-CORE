using HMSCore.Models.Home;

namespace HMSCore.Services
{
    public interface IHomeService
    {
        HomeViewModel GetDashboardInfo();
    }
}