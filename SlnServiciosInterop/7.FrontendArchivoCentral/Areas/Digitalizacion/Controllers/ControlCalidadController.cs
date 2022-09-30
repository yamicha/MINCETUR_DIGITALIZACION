using Frotend.ArchivoCentral.Micetur.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class ControlCalidadController : Controller
    {
        // GET: ControlCalidadController
        [HttpGet, Route("~/Digitalizacion/control-calidad")]
        public ActionResult Index()
        {
            return View();
        }



     
    }
}
