using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Enums;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;
using Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models;
using Frotend.Ventanilla.Micetur.Authorization;
using Frotend.Ventanilla.Micetur.Filters;
using Frotend.Ventanilla.Micetur.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Utilitarios.Helpers;
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
        public async Task<ActionResult> Documento_Validar_Imagen(long ID_DOCUMENTO, long ID_DOCUMENTO_ASIGNADO)
        {
            int ID_USUARIO = int.Parse(User.GetUserId());
            DocumentoValidarModelView modelo = new DocumentoValidarModelView();
            enAuditoria auditoria = new enAuditoria();
            modelo.ID_DOCUMENTO = ID_DOCUMENTO;
            modelo.ID_DOCUMENTO_ASIGNADO = ID_DOCUMENTO_ASIGNADO;
            modelo.VALIDAR_ID_CONFORME = "";

            enAuditoria ApiDominio = await new Utilitarios.Helpers.CssApi().GetApi<enAuditoria>(new Utilitarios.Helpers.ApiParams
            {
                EndPoint = AppSettings.baseUrlApi,
                Url = $"recursivo/dominio/listar/1",
                UserAD = AppSettings.UserAD,
                PassAD = AppSettings.PassAD,
            });
            if (ApiDominio != null)
            {
                if (!ApiDominio.Rechazo)
                {
                    if (ApiDominio.Objeto != null)
                    {
                        List<enDominio> ListaDominios = JsonConvert.DeserializeObject<List<enDominio>>(ApiDominio.Objeto.ToString());
                        if (ListaDominios == null) ListaDominios = new List<enDominio>();
                        modelo.Lista_VALIDAR_ID_CONFORME = ListaDominios
                          .Where(s => s.ID_DOMINIO_PADRE == (long)Dominios.EvalucionCalidad)
                         .Select(x => new SelectListItem
                         {
                             Text = x.DESC_ITEM,
                             Value = x.COD_ITEM,
                         }).ToList();
                        modelo.Lista_VALIDAR_ID_CONFORME.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
                    }
                }
            }

            modelo.Lista_VALIDAR_ID_TIPO_OBS = new List<SelectListItem>();
            enAuditoria apiDocumento= await new CssApi().GetApi<enAuditoria>(new ApiParams
            {
                EndPoint = AppSettings.baseUrlApi,
                Url = $"ventanilla/documento/get-documento/{ID_DOCUMENTO}",
                UserAD = AppSettings.UserAD,
                PassAD = AppSettings.PassAD
            });
            if (apiDocumento != null)
            {
                if (!apiDocumento.Rechazo)
                {
                    if (apiDocumento.Objeto != null)
                    {
                        enDocumento Documento = JsonConvert.DeserializeObject<enDocumento>(apiDocumento.Objeto.ToString());
                        if (Documento == null) Documento = new enDocumento();
                        modelo.DES_TIP_DOC = Documento.DES_TIP_DOC;
                        modelo.DES_ASUNTO = Documento.DES_ASUNTO;
                        modelo.DES_OBS = Documento.DES_OBS;
                        modelo.NUM_DOC = Documento.NUM_DOC;
                        modelo.NUM_FOLIOS = Documento.NUM_FOLIOS;
                        modelo.DES_CLASIF = Documento.DES_CLASIF;
                        modelo.DES_PERSONA = Documento.DES_PERSONA;
                        modelo.EXP_OBSERVACION = Documento.EXP_OBSERVACION;
                        //modelo.
                    }
                }
            }
            return View(modelo);
        }

        [HttpGet, Route("~/Digitalizacion/documento/ver-imagen")]
        public ActionResult Documento_Ver_Imagen(long ID_DOCUMENTO)
        {
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
