using EnServiciosDigitalizacion;
using Frotend.Ventanilla.Micetur.Areas.Administracion.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frotend.Ventanilla.Micetur.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    [Route("[action]")]
    public class SoporteController : Controller
    {
        [HttpGet, Route("~/Administracion/Soporte")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Administracion/Soporte/Mantenimiento")]
        public ActionResult Mantenimiento(int id, string Accion)
        {
            enAuditoria auditoria = new enAuditoria();
            SoporteModelView model = new SoporteModelView
            {
                ACCION = Accion,
                ID_SOPORTE = id
            };

            return View(model);
        }
    }
}
