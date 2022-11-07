using EnServiciosDigitalizacion;
using Frotend.Ventanilla.Micetur.Areas.Administracion.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frotend.Ventanilla.Micetur.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    [Route("[action]")]
    public class ObservacionController : Controller
    {
        [HttpGet, Route("~/Administracion/Observacion")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Administracion/Observacion/Mantenimiento")]
        public ActionResult Mantenimiento(int id, string Accion)
        {
            enAuditoria auditoria = new enAuditoria();
            ObservacionModelView model = new ObservacionModelView
            {
                ACCION = Accion,
                ID_OBSERVACION = id
            };

            return View(model);
        }
    }
}
