using Wasifu.BaseFrameWork;

namespace Wasifu.Models
{
    public class Resume : BaseModel
    {
        public long UserDataID { get; set; }
        public string ResumeTitle { get; set; }

        public string ProfessionalSummary { get; set; }
    }
}
