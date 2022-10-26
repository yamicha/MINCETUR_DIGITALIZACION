using System;
using System.Web;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utilitarios.Recursos;
using EnServiciosDigitalizacion.ArchivoCentral.Carga.Vistas;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using EnServiciosDigitalizacion.ArchivoCentral.Carga;
using Frotend.ArchivoCentral.Micetur.Controllers;
using Frotend.ArchivoCentral.Micetur.Authorization;
using Frotend.ArchivoCentral.Micetur.Filters;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class RecepcionController : BaseController
    {

        // GET: SeccionController
        [HttpGet, Route("~/Digitalizacion/recepcion")]
        public ActionResult Index()
        {
            enAuditoria auditoria = new enAuditoria();
            RecepcionModelView modelo = new RecepcionModelView();

            modelo.Lista_ID_CONTROL_CARGA.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });
            modelo.Lista_ID_TABLA.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });
            return View(modelo);
        }
        [HttpGet, Route("~/Digitalizacion/formato-ver")]
        public ActionResult FormatoCarga_Ver(long ID_TABLA)
        {
            FormatoModelView modelo = new FormatoModelView();
            modelo.ID_TABLA = ID_TABLA;
            return View(modelo);
        }

    }
}
