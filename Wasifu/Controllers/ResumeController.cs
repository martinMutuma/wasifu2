using Microsoft.AspNetCore.Mvc;
using Wasifu.BaseFrameWork;
using Wasifu.Data;

namespace Wasifu.Controllers
{
    public partial class ResumeController : BaseAuthenticatedController
    {

        public ResumeController(ILogger<object> logger, WasifuContext context) : base(logger, context)
        {

        }

        public IActionResult Edit()
        {
            ViewData["Title"] = "Resume Edit";
            return View();
        }
    }
}