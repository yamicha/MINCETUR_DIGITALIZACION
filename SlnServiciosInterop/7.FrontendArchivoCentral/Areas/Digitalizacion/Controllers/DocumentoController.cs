using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion; 
using Microsoft.AspNetCore.Mvc.Rendering;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Frotend.ArchivoCentral.Micetur.Helpers;
using ServiceReference1;
using System.Web;
using Newtonsoft.Json;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
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
        public async  Task<ActionResult> Documento_Validar_Imagen(long ID_DOCUMENTO)
        {
            int COUSUARIO = 3248;
            DocumentoValidarModelView modelo = new DocumentoValidarModelView();
            enAuditoria auditoria = new enAuditoria();
           enAuditoria auditoriaAPi = await new CssApi().GetApi<enAuditoria>($"archivo-central/documento/get-documento/{ID_DOCUMENTO}");
            modelo.CODIGO_IMAGEN = "";
            modelo.Lista_VALIDAR_ID_CONFORME = new List<SelectListItem>();
            modelo.Lista_VALIDAR_ID_CONFORME.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });
            modelo.Lista_VALIDAR_ID_CONFORME.Insert(1, new SelectListItem() { Value = "1", Text = "CONFORME" });
            modelo.Lista_VALIDAR_ID_CONFORME.Insert(2, new SelectListItem() { Value = "0", Text = "NO CONFORME" });
            modelo.VALIDAR_ID_CONFORME = "";
            modelo.Lista_VALIDAR_ID_TIPO_OBS = new List<SelectListItem>();

            //var lista = _cls_Serv_V_TipoObs.Listar_Todo("1", ref auditoria);
            //if (auditoria.EjecucionProceso)
            //{
            //    if (!auditoria.Rechazo)
            //    {
            //        modelo.Lista_VALIDAR_ID_TIPO_OBS = lista.Select(x => new SelectListItem()
            //        {
            //            Text = x.DESC_OBSERVACION.ToString(),
            //            Value = x.ID_OBSERVACION.ToString()
            //        }).ToList();
            //        modelo.Lista_VALIDAR_ID_TIPO_OBS.Insert(0, new SelectListItem() { Value = "", Text = "-- Seleccione --" });
            //    }
            //}
            //else
            //{
            //    modelo.Lista_VALIDAR_ID_TIPO_OBS.Insert(0, new SelectListItem() { Value = "", Text = "-- Seleccione --" });
            //    Log.Guardar(auditoria.ErrorLog);
            //}

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
                        try
                        {
                            if (cls_V_Documento.ID_LASERFICHE != 0)
                            {
                                string CODLASER_ENCRIPT = await new CssApi().ClientEncriptarIdLaser(cls_V_Documento.ID_LASERFICHE, COUSUARIO);
                                modelo.VISOR_LF = string.Format("{0}{1}", AppSettingsHelper.RutaVisorLF, CODLASER_ENCRIPT); 
                            }
                   
                        }
                        catch (Exception ex)
                        {
                            modelo.CODIGO_IMAGEN = "";
                            auditoria.Error(ex);
                            Log.Guardar(auditoria.ErrorLog);
                        }
                    }
                }
            }
            return View(modelo);
        }

        [HttpGet, Route("~/Digitalizacion/documento/ver-imagen")]
        public ActionResult Documento_Ver_Imagen(long ID_LASER)
        {
            DocumentoVerModelView modelo = new DocumentoVerModelView();
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar();
            modelo.CODIGO_IMAGEN = "";
            string ruta_temporal = "";

            //Cls_V_Documento cls_V_Documento = _cls_Serv_V_Documento.Documento_Listar_Uno(ID_DOCUMENTO, ref auditoria);
            try
            {
                if (ID_LASER != 0)
                {
                    modelo.VISOR_LF = AppSettingsHelper.RutaVisorLF + ID_LASER;
                }

            }
            catch (Exception ex)
            {
                modelo.CODIGO_IMAGEN = "";
                auditoria.Error(ex);
                Log.Guardar(auditoria.ErrorLog);
            }
            finally
            {
                System.Threading.Thread t2 = new System.Threading.Thread(() =>
                {
                    int numberOfSeconds = 0;
                    while (numberOfSeconds < 10)
                    {
                        System.Threading.Thread.Sleep(1000);
                        numberOfSeconds++;
                    }
                    if (System.IO.File.Exists(ruta_temporal))
                        System.IO.File.Delete(ruta_temporal);
                });
                t2.Start();
                //t2.Join();
            }
            return View(modelo);
        }
    }
}
