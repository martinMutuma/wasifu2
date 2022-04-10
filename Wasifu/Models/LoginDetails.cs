using Wasifu.BaseFrameWork;

namespace Wasifu.Models
{
    public class LoginDetails : BaseModel
    {
        public string UserName { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public long UserDataID { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
