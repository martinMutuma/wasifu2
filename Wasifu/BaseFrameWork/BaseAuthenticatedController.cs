using Microsoft.AspNetCore.Authorization;
using Wasifu.Data;

namespace Wasifu.BaseFrameWork
{
    [Authorize]
    public class BaseAuthenticatedController : BaseController
    {
        public BaseAuthenticatedController(ILogger<object> logger, WasifuContext context):base(logger, context)
        {
          
        }
    }
}
