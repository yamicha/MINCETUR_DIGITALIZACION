using System;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Frotend.ArchivoCentral.Micetur.Controllers; 

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    [Route("[action]")]
    public class SeccionController : BaseController
    {
        // GET: SeccionController
        [HttpGet, Route("~/Administracion/Seccion")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Administracion/Seccion/Mantenimiento")]
        public ActionResult Mantenimiento(int id, string Accion)
        {
            enAuditoria auditoria = new enAuditoria();
            SeccionModelView model = new SeccionModelView
            {
                ACCION = Accion,
                ID_SECCION = id
            };
 
            return View(model);
        }

    }
}
