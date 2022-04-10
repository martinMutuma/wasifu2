namespace Wasifu.BaseFrameWork
{
    public abstract class BaseModel
    {
        public long ID { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public long CreatedBy { get; set; }
        public bool IsDeleted { get; set; }  = false;
        public DateTime? DeletedDate { get; set; }
        public bool isActive { get; set; } = true;
    }

    public abstract class PartsBaseModel : BaseModel
    {
        public long ResumeID { get; set; }
        public long UserDataID { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Current { get; set; }
        public int position { get; set; }
        public string Location { get; set; }
        public long CityId { get; set; }

    }
}
