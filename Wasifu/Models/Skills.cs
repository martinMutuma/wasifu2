using Wasifu.BaseFrameWork;

namespace Wasifu.Models
{
    public class Skills : BaseModel
    {
        public long ResumeID { get; set; }
        public long UserDataID { get; set; }
        public string SkillName { get; set; }
        public int SkillLevel { get; set; }
        public int SkillType { get; set; }
    }
}
