using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Webextant.Controllers
{
    [Route("api")]
    public class PingController : Controller
    {
        [HttpGet]
        [Route("ping")]
        public string Ping()
        {
            return "Pong";
        }
    }
}