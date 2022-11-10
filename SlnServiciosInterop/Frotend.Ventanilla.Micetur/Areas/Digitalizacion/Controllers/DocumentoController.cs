using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models;
using Frotend.Ventanilla.Micetur.Authorization;
using Frotend.Ventanilla.Micetur.Filters;
using Frotend.Ventanilla.Micetur.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Utilitarios.Recursos;
namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class DocumentoController : Controller
    {
        // GET: DocumentoController
        [HttpGet, Route("~/Digitalizacion/documento")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet, Route("~/Digitalizacion/documento/ver-proceso")]
        public ActionResult Documento_Ver_Proceso(long ID_DOCUMENTO)
        {
            DocumentoVerObsModelView modelo = new DocumentoVerObsModelView();
            modelo.ID_DOCUMENTO = ID_DOCUMENTO;
            return View(modelo);
        }

        [HttpGet, Route("~/Digitalizacion/documento/validar-imagen")]
        public ActionResult Documento_Validar_Imagen(long ID_DOCUMENTO, long ID_DOCUMENTO_ASIGNADO)
        {
            int ID_USUARIO = int.Parse(User.GetUserId());
            DocumentoValidarModelView modelo = new DocumentoValidarModelView();
            enAuditoria auditoria = new enAuditoria();
            modelo.ID_DOCUMENTO = ID_DOCUMENTO;
            modelo.ID_DOCUMENTO_ASIGNADO = ID_DOCUMENTO_ASIGNADO;
            modelo.Lista_VALIDAR_ID_CONFORME = new List<SelectListItem>();
            modelo.Lista_VALIDAR_ID_CONFORME.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });
            modelo.Lista_VALIDAR_ID_CONFORME.Insert(1, new SelectListItem() { Value = "1", Text = "CONFORME" });
            modelo.Lista_VALIDAR_ID_CONFORME.Insert(2, new SelectListItem() { Value = "0", Text = "NO CONFORME" });
            modelo.VALIDAR_ID_CONFORME = "";
            modelo.Lista_VALIDAR_ID_TIPO_OBS = new List<SelectListItem>();

            return View(modelo);
        }

        [HttpGet, Route("~/Digitalizacion/documento/ver-imagen")]
        public async Task<ActionResult> Documento_Ver_Imagen(long ID_DOCUMENTO)
        {
            int ID_USUARIO = int.Parse(User.GetUserId());
            DocumentoValidarModelView modelo = new DocumentoValidarModelView();
            modelo.ID_DOCUMENTO = ID_DOCUMENTO;
            return View(modelo);
        }

        [HttpGet, Route("~/Digitalizacion/documento/ver-Obs")]
        public ActionResult Documento_Ver_Obs(long ID_DOCUMENTO)
        {
            DocumentoVerObsModelView modelo = new DocumentoVerObsModelView();
            modelo.ID_DOCUMENTO = ID_DOCUMENTO;
            return View(modelo);
        }
    }
}
