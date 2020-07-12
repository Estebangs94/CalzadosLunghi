using CalzadosLunghi.API.ActionFilter;
using CalzadosLunghi.API.DTO;
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

        [MobileActionFilter(Action = "NewContact", Controller = "Home")]
        [Route("contact-us")]
        [HttpGet]
        public ActionResult Contact()
        {
            return Ok();
        }

        [Route("new-contact-us")]
        [HttpGet]
        public ActionResult NewContact()
        {
            return Ok(new TipoMaterialDTO { 
                Nombre = "Redireccion",
                Codigo = "RED100",
                ID = 100
            });
        }
    }
}
