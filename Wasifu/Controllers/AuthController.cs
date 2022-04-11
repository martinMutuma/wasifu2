using Microsoft.AspNetCore.Mvc;
using Wasifu.BaseFrameWork;
using Wasifu.Data;
using Wasifu.Dtos;
using Wasifu.Services;
using Wasifu.ViewModels;

namespace Wasifu.Controllers
{

    public class AuthController : BaseController
    {
        AuthManager _authManager;

        public AuthController(ILogger<object> logger, WasifuContext context, AuthManager authManager) : base(logger, context)
        {
            _authManager = authManager;
        }
        [Route("Login")]
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            ViewData["Title"] = "Login";

            LoginDto loginDto = new LoginDto();

            ViewData["returnUrl"] = returnUrl;
            return View(loginDto);
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto userData, string returnUrl = "")
        {
            ViewData["returnUrl"] = returnUrl;

            var loginData = await _authManager.SignIn(this.HttpContext, userData);
            userData.loginError = loginData.Message;
            if (loginData.success)
            {
                if (!String.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("index", "Home");
            }
            return View(userData);
        }


        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public AjaxResponse Register(LoginDto loginDto)
        {
            var viewModel = GetViewModel();

            var response = viewModel.RegisterUser(loginDto);
            return response;
        }

        [Route("Logout")]

        public async Task<IActionResult> Logout()
        {

            await Task.Delay(1);
            var returnUrl = HttpContext.Request.Headers["Referer"].ToString();
            return RedirectToAction("Login", new { returnUrl = "/" });
        }
        private AuthViewModel GetViewModel()
        {
            var viewModel = new AuthViewModel(_context);

            return viewModel;
        }
    }
}