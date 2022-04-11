using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wasifu.BaseFrameWork;
using Wasifu.Data;
using Wasifu.Models;

namespace Wasifu.Controllers
{

    public partial class HomeController : BaseAuthenticatedController
    {

        public HomeController(ILogger<object> logger, WasifuContext context) : base(logger, context)
        {

        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}