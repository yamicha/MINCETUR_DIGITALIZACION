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
        public async Task<ActionResult> Documento_Validar_Imagen(long ID_DOCUMENTO)
        {
            int ID_USUARIO = int.Parse(User.GetUserId());
            DocumentoValidarModelView modelo = new DocumentoValidarModelView();
            enAuditoria auditoria = new enAuditoria();
            enAuditoria auditoriaAPi = await new CssApi().GetApi<enAuditoria>($"archivo-central/documento/get-documento/{ID_DOCUMENTO}");
            modelo.Lista_VALIDAR_ID_CONFORME = new List<SelectListItem>();
            modelo.Lista_VALIDAR_ID_CONFORME.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });
            modelo.Lista_VALIDAR_ID_CONFORME.Insert(1, new SelectListItem() { Value = "1", Text = "CONFORME" });
            modelo.Lista_VALIDAR_ID_CONFORME.Insert(2, new SelectListItem() { Value = "0", Text = "NO CONFORME" });
            modelo.VALIDAR_ID_CONFORME = "";
            modelo.Lista_VALIDAR_ID_TIPO_OBS = new List<SelectListItem>();

            enAuditoria TipoObservacion = await new CssApi().PostApi<enAuditoria>($"archivo-central/observacion/listar", new parameters
            {
                FlgEstado = "1"
            });
            if (TipoObservacion.EjecucionProceso)
            {
                if (!TipoObservacion.Rechazo)
                {
                    List<enObservacion> ListaObservacion = new List<enObservacion>();
                    if (auditoriaAPi.Objeto != null)
                        ListaObservacion = JsonConvert.DeserializeObject<List<enObservacion>>(TipoObservacion.Objeto.ToString());
                    modelo.Lista_VALIDAR_ID_TIPO_OBS = ListaObservacion.Select(x => new SelectListItem()
                    {
                        Text = x.DESC_OBSERVACION.ToString(),
                        Value = x.ID_OBSERVACION.ToString()
                    }).ToList();
                    modelo.Lista_VALIDAR_ID_TIPO_OBS.Insert(0, new SelectListItem() { Value = "", Text = "-- Seleccione --" });
                }
            }
            else
            {
                modelo.Lista_VALIDAR_ID_TIPO_OBS.Insert(0, new SelectListItem() { Value = "", Text = "-- Seleccione --" });
                Log.Guardar(auditoria.ErrorLog);
            }

            if (auditoriaAPi.EjecucionProceso)
            {
                if (!auditoriaAPi.Rechazo)
                {
                    if (auditoriaAPi.Objeto != null)
                    {
                        enDocumento cls_V_Documento = JsonConvert.DeserializeObject<enDocumento>(auditoriaAPi.Objeto.ToString());
                        modelo.ID_DOCUMENTO = cls_V_Documento.ID_DOCUMENTO;
                        modelo.ID_DOCUMENTO_ASIGNADO = cls_V_Documento.ID_DOCUMENTO_ASIGNADO;
                        modelo.NOM_DOCUMENTO = cls_V_Documento.NOM_DOCUMENTO;
                        modelo.DESC_FONDO = cls_V_Documento.DES_FONDO;
                        modelo.DESC_LARGA_SECCION = cls_V_Documento.DES_LARGA_SECCION;
                        modelo.DESC_SERIE = cls_V_Documento.DES_SERIE;
                        modelo.ANIO = cls_V_Documento.ANIO;
                        modelo.FOLIOS = cls_V_Documento.FOLIOS;
                        modelo.DESCRIPCION = cls_V_Documento.DESCRIPCION;
                        modelo.VALIDAR_NOMBRE_DIGITALIZADOR = cls_V_Documento.DESCRIPCION;
                        modelo.OBSERVACION = cls_V_Documento.OBSERVACION;
                        modelo.VALIDAR_NOMBRE_DIGITALIZADOR = cls_V_Documento.NOMBRE_USUARIO;
                        modelo.ID_DOCUMENTO_ASIGNADO = cls_V_Documento.ID_DOCUMENTO_ASIGNADO;
                        try
                        {
                            if (cls_V_Documento.ID_LASERFICHE != 0)
                            {
                                //string CODLASER_ENCRIPT = await new CssApi().ClientEncriptarIdLaser(cls_V_Documento.ID_LASERFICHE, COUSUARIO);
                                //modelo.VISOR_LF = string.Format("{0}{1}", AppSettingsHelper.RutaVisorLF, CODLASER_ENCRIPT);
                                modelo.VISOR_LF = @"\\Repositorio\\archivo_prueba.pdf";

                            }

                        }
                        catch (Exception ex)
                        {
                            auditoria.Error(ex);
                            Log.Guardar(auditoria.ErrorLog);
                        }
                    }
                }
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
                    //string CODLASER_ENCRIPT = await new CssApi().ClientEncriptarIdLaser(ID_LASER, ID_USUARIO);
                    //modelo.VISOR_LF = string.Format("{0}{1}", AppSettingsHelper.RutaVisorLF, CODLASER_ENCRIPT);
                    modelo.VISOR_LF = @"\\Repositorio\\archivo_prueba.pdf";
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
