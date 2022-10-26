using System;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Controllers
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
