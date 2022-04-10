using Wasifu.Data;

namespace Wasifu.BaseFrameWork
{
    public class BaseRepository
    {
        protected WasifuContext _context;

        public BaseRepository(WasifuContext context)
        {
            _context = context;

        }


        public bool isContextOkay
        {
            get
            {
                return _context != null;
            }
        }


        public string DbContextError = "Error Connecting to database";
    }
}
