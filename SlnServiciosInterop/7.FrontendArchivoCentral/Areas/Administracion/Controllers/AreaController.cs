using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frotend.ArchivoCentral.Micetur.Filters;
using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Controllers
{
    [MyAuthorize]
    [Area("Administracion")]
    [Route("[action]")]
    public class AreaController : Controller
    {
        [HttpGet, Route("~/Administracion/Area")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Administracion/Area/Mantenimiento")]
        public ActionResult Mantenimiento(int id, string Accion)
        {
            enAuditoria auditoria = new enAuditoria();
            AreaModelView model = new AreaModelView
            {
                ACCION = Accion,
                ID_AREA = id
            };
            return View(model);
        }

    }
}
