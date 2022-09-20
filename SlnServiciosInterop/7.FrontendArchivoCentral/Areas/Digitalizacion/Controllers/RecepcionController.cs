using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class RecepcionController : Controller
    {

        // GET: SeccionController
        [HttpGet, Route("~/Digitalizacion/recepcion")]
        public ActionResult Index()
        {
            return View();
        }


      
    }
}
