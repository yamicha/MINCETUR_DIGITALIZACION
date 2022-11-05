using Frotend.Ventanilla.Micetur.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
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
