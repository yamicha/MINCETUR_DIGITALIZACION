using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Authorization;
using Frotend.ArchivoCentral.Micetur.Filters;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    public class ControlAlmacenamientoController : Controller
    {
        [MyAuthorize]
        [Area("Digitalizacion")]
        [Route("[action]")]
        // GET: ControlAlamcenamientioController
        [HttpGet, Route("~/Digitalizacion/control-almacenamiento")]
        public ActionResult Index()
        {
            return View();
        }

   

    }
}
