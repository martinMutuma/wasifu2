using Wasifu.Models;

namespace Wasifu.Dtos
{
    public class LoginDto : UserData
    {
        public string ConfirmPassword { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public string? loginError { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
