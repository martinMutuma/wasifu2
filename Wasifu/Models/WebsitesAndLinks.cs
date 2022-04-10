using Wasifu.BaseFrameWork;

namespace Wasifu.Models
{
    public class Countries : BaseModel
    {
        public string CountryName { get; set; }

    }

    public class Cities : BaseModel
    {
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }

    public class WebsitesAndLinks : BaseModel
    {
        public long ResumeID { get; set; }


    }
}
