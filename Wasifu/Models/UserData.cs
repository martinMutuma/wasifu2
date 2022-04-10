using Wasifu.BaseFrameWork;
using Wasifu.Enums;

namespace Wasifu.Models
{
    public class UserData : BaseModel
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string? JobTitle { get; set; }
        public long CountryId { get; set; }
        public long CityId { get; set; }
        public int gender { get; set; }
    }
}
