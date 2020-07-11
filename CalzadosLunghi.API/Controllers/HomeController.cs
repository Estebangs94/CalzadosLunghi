using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalzadosLunghi.API.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {

        }

        [Route("contact-us")]
        [HttpGet]
        public ActionResult Contact()
        {
            return Ok();
        }
    }
}
