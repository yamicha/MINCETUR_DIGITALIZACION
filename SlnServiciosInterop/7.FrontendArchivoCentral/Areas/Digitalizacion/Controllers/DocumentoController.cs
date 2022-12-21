using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Filters;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Frotend.ArchivoCentral.Micetur.Authorization;
using EnServiciosDigitalizacion.Enums;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
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
        public async Task<ActionResult> Documento_Validar_Imagen(long ID_DOCUMENTO,long ID_LASER)
        {
            int ID_USUARIO = int.Parse(User.GetUserId());
            DocumentoValidarModelView modelo = new DocumentoValidarModelView();
            enAuditoria auditoria = new enAuditoria();

            try
            {
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
                modelo.VALIDAR_ID_CONFORME = "";
                modelo.Lista_VALIDAR_ID_TIPO_OBS = new List<SelectListItem>();
                if (ID_LASER != 0)
                {
                    string CODLASER_ENCRIPT = await new CssUtil().ClientEncriptarIdLaser(ID_LASER, ID_USUARIO);
                    modelo.VISOR_LF = string.Format("{0}{1}", AppSettings.RutaVisorLF, CODLASER_ENCRIPT);
                    //modelo.VISOR_LF = @"\\Repositorio\\archivo_prueba.pdf";
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            
            return View(modelo);
        }

        [HttpGet, Route("~/Digitalizacion/documento/ver-imagen")]
        public async Task<ActionResult> Documento_Ver_Imagen(long ID_LASER)
        {
            int ID_USUARIO = int.Parse(User.GetUserId());
            DocumentoVerModelView modelo = new DocumentoVerModelView();
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar();
            try
            {
                if (ID_LASER != 0)
                {
                    string CODLASER_ENCRIPT = await new CssUtil().ClientEncriptarIdLaser(ID_LASER, ID_USUARIO);
                    modelo.VISOR_LF = string.Format("{0}{1}", AppSettings.RutaVisorLF, CODLASER_ENCRIPT);
                    //modelo.VISOR_LF = @"\\Repositorio\\archivo_prueba.pdf";
                }

            }
            catch (Exception ex)
            {
                modelo.CODIGO_IMAGEN = "";
                auditoria.Error(ex);
                Log.Guardar(auditoria.ErrorLog);
            }

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
