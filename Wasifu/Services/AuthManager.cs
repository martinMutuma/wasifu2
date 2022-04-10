using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Wasifu.Data;
using Wasifu.Dtos;
using Wasifu.Models;
using Wasifu.ViewModels;
using static Wasifu.Utilities.Utilities;
using Wasifu.Extensions;

namespace Wasifu.Services
{
    public class AuthManager
    {
        AuthViewModel authViewModel;
        public AuthManager(WasifuContext dbContext)
        {
            authViewModel = new AuthViewModel(dbContext);
        }

        public async Task<AjaxResponse> SignIn(HttpContext httpContext, LoginDto user)
        {
            var response = new AjaxResponse(_success: false);
            try
            {

                string userName = user.Email;
                string password = user.Password;


                LoginDetails? acPAss = GetUserLoginCredentials(userName);

                if (acPAss == null)
                {
                    response.Message = "User Not Found";
                    return response;
                }
                else
                {

                    ///Implement the login logic here
                    string encryptPass = CalculateMD5Hash(password);
                    if (encryptPass != acPAss.password)
                    {
                        response.Message = "Account Details Did not match";
                        return response;
                    }
                }

                ClaimsIdentity identity = new ClaimsIdentity(GetUserClaims(httpContext, user, acPAss), CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                response.success = true;

                response.Message = "Login Successful";
                await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return response;
            }
            catch (Exception)
            {
            }
            return response;

        }

        private LoginDetails? GetUserLoginCredentials(string username)
        {
            var logins = authViewModel.GetUserByUserName(username);
            return logins;
        }

        private IEnumerable<Claim> GetUserClaims(HttpContext httpContext, LoginDto user, LoginDetails acPAss)
        {
            UserData? pers = null;
            pers = authViewModel.GetUserDataById(acPAss.UserDataID);
            if (pers != null)
            {
                user.UserName = acPAss.UserName;
                user.Email = pers.Email;
                user.Email = pers.Email;
                user.FirstName = pers.FirstName;
                user.LastName = pers.LastName;
            }


            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));

            claims.Add(new Claim("FullName", user.FirstName));
            claims.Add(new Claim("_UserKey", user.Password));

            httpContext.Session.SetLoggedInUser(user);
            return claims;
        }

    }
}
