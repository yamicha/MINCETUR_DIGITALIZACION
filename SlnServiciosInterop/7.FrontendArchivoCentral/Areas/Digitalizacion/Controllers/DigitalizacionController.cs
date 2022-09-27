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
    public class DigitalizacionController : Controller
    {
        // GET: DigitalizacionController
        [HttpGet, Route("~/Digitalizacion/digitalizar-documento")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
