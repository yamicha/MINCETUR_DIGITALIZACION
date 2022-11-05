using Frotend.Ventanilla.Micetur.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Controllers
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
