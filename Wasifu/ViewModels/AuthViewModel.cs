using Wasifu.BaseFrameWork;
using Wasifu.Data;
using Wasifu.Dtos;
using Wasifu.Models;
using Wasifu.Repositories;

namespace Wasifu.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        private UserDataRepository userDataRepository;
        public AuthViewModel(WasifuContext context) : base(context)
        {
            userDataRepository = new UserDataRepository(context);
        }

        public AjaxResponse RegisterUser(LoginDto loginDto)
        {

            try
            {
                UserData userData = new UserData();

                userData.Email = loginDto.Email.Trim();
                userData.FirstName = loginDto.FirstName.Trim();
                userData.LastName = loginDto.LastName.Trim();
                userData.gender = loginDto.gender;

                var userCreateResponse = userDataRepository.SaveUserData(userData) ?? new AjaxResponse("Registration Failed", false);
                if (userCreateResponse != null && userCreateResponse.data != null)
                {
                    userData = (UserData)userCreateResponse.data;
                }

                if (userData.ID > 0)
                {
                    var loginDetails = new LoginDetails();
                    loginDetails.UserDataID = userData.ID;
                    loginDetails.Email = userData.Email.Trim();
                    loginDetails.UserName = loginDetails.Email;
                    loginDetails.password = loginDto.Password;
                    var loginCreateResponse = userDataRepository.SaveLoginDetails(loginDetails);

                    if (loginCreateResponse != null && loginCreateResponse.data != null)
                    {
                        loginDetails = (LoginDetails)loginCreateResponse.data;

                    }
                    if (loginDetails.ID == 0)
                    {
                        userCreateResponse = loginCreateResponse;
                        userDataRepository.DeleteUserData(userData);
                    }
                }
                return userCreateResponse;
            }
            catch (Exception)
            {


            }
            return null;
        }

        public LoginDetails? GetUserByUserName(string username)
        {
            if(string.IsNullOrEmpty(username)) return null;
            username = username.Trim();
            var loginDetails = userDataRepository.GetUserByUserName(username);
            return loginDetails;
        }
        public UserData? GetUserDataById(long Userid)
        {
            UserData? userData = userDataRepository.GetUserDataById(Userid); ;
          
            return userData;
        }
    }
    public class USerViewModel : BaseViewModel
    {
        public USerViewModel(WasifuContext context) : base(context)
        {

        }
    }
}
