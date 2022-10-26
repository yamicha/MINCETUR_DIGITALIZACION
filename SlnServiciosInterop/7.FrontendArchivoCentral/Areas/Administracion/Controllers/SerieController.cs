using System;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Models;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    [Route("[action]")]
    public class SerieController : Controller
    {
        [HttpGet, Route("~/Administracion/Serie")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Administracion/Serie/Mantenimiento")]
        public ActionResult Mantenimiento(int id, string Accion)
        {
            enAuditoria auditoria = new enAuditoria();
            SerieModelView model = new SerieModelView
            {
                ACCION = Accion,
                ID_SERIE = id
            };
            try
            {
                model.CBO_SECCION = new List<SelectListItem>(); 
                model.CBO_SECCION.Insert(0, new SelectListItem("--SELECCIONE--", ""));
             
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return View(model);
        }


    }
}
