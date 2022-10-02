using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frotend.ArchivoCentral.Micetur.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class FedatarioController : Controller
    {
        // GET: FedetarioController
        [HttpGet, Route("~/Digitalizacion/fedatario")]
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
