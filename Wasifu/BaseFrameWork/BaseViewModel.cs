using Wasifu.Data;

namespace Wasifu.BaseFrameWork
{
    public class BaseViewModel
    {
        protected WasifuContext _context;

        public BaseViewModel(WasifuContext context)
        {
            _context = context;

        }


    }
}
