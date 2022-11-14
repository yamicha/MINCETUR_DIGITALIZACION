using Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models;
using Frotend.Ventanilla.Micetur.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class ReprocesoController : Controller
    {

        [HttpGet, Route("~/Digitalizacion/reproceso")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Digitalizacion/reproceso/mantinimiento")]
        public ActionResult Mantenimiento(long ID_DOCUMENTO)
        {
            ReprocesoModels modelo = new ReprocesoModels();
            modelo.ID_DOCUMENTO = ID_DOCUMENTO;
            return View(modelo);
        }

        [HttpGet, Route("~/Digitalizacion/reproceso/editar-adjunto")]
        public ActionResult EditarAdjunto()
        {
            return View();
        }

    }
}
