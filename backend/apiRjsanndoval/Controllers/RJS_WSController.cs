using Microsoft.AspNetCore.Mvc;
using RJS_WS.BLL;

namespace RJS_WS.Controllers
{
    public class RJS_WSController : ControllerBase
    {
        private readonly RJS_WSBL _rjsWSBL;

        public RJS_WSController()
        {
            _rjsWSBL = new RJS_WSBL();
        }

        [HttpPost("GetUsers")]
        public IActionResult GetUsers()
        {

        }
    }
}
