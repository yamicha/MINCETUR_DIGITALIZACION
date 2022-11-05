using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frotend.Ventanilla.Micetur.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Controllers
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
