using Microsoft.AspNetCore.Mvc;
using Wasifu.Data;

namespace Wasifu.BaseFrameWork
{
    public class BaseController : Controller
    {
        private readonly ILogger<object>? _logger;
        protected  WasifuContext _context;
        public BaseController(ILogger<object> logger, WasifuContext context)
        {
            _logger = logger;
            _context = context;
        }
       
    }
}
