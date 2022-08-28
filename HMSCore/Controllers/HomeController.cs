using DataLayer.Models;
using HMSCore.Models;
using HMSCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HMSCore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHomeService hService;

        public HomeController(IHomeService homeService)
        {
            this.hService = homeService;
        }

        public IActionResult Home()
        {
            var currentDashboard = this.hService.GetDashboardInfo();

            return View(currentDashboard);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}