using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion.Models.Ventanilla;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;
using Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models;
using Frotend.Ventanilla.Micetur.Authorization;
using Frotend.Ventanilla.Micetur.Controllers;
using Frotend.Ventanilla.Micetur.Filters;
using Frotend.Ventanilla.Micetur.Helpers;
using Frotend.Ventanilla.Micetur.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Utilitarios.Helpers;
using System.Web;
using System.Net;
using subir = docSubirDocumento;
using ServiceReference1;

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]

    public class RecepcionController : BaseController
    {
        [HttpGet, Route("~/Digitalizacion/recepcion")]
        public async Task<IActionResult> Index()
        {
            RecibirModelView model = new RecibirModelView();
            model.ListaPersonal = new List<SelectListItem>();
            enAuditoria ApiUsuarios = await new CssApi().PostApi<enAuditoria>(new ApiParams
            {
                EndPoint = AppSettings.baseUrlApi,
                Url = $"ventanilla/operador/listar",
                UserAD = AppSettings.UserAD,
                PassAD = AppSettings.PassAD,
                parametros = new parameters { FlgEstado = "1" }
            });
            if (ApiUsuarios != null)
            {
                if (!ApiUsuarios.Rechazo)
                {
                    if (ApiUsuarios.Objeto != null)
                    {
                        var Lista = JsonConvert.DeserializeObject<List<enUsuario>>(ApiUsuarios.Objeto.ToString());
                        model.ListaPersonal = Lista.Select(x => new SelectListItem
                        {
                            Value = x.ID_USUARIO.ToString(),
                            Text = x.NOMBRE_USUARIO
                        }).ToList();
                        model.ListaPersonal.Insert(0, new SelectListItem { Value = "", Text = "--Seleccione--" });
                    }
                }
            }
            else
            {
                model.ListaPersonal.Insert(0, new SelectListItem { Value = "", Text = "--sin usuarios--" });
            }
            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/Recepcion/RecibirDoc")]
        public ActionResult RecibirDoc(long ID_EXPE)
        {
            RecibirModelView modelo = new RecibirModelView();
            modelo.ID_EXPE = ID_EXPE;
            return View(modelo);
        }

        [HttpGet, Route("~/Digitalizacion/Recepcion/VerDoc")]
        public ActionResult VerDoc(long ID_EXPE)
        {
            RecibirModelView modelo = new RecibirModelView();
            modelo.ID_EXPE = ID_EXPE;
            return View(modelo);
        }

        [HttpGet, Route("~/Digitalizacion/Recepcion/editar-documento")]
        public ActionResult EditarDocumento(long id)
        {
            RecibirModelView modelo = new RecibirModelView();
            modelo.ID_DOC = id;
            return View(modelo);
        }

        [HttpPost, Route("~/Digitalizacion/Recepcion/recibir-expediente")]
        public async Task<ActionResult> ExpedienteRecibir(List<IFormFile> files, ExpedienteModels entidad, string ListaAdj)
        {
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar();
            try
            {
                entidad.ListaAdjuntos = new List<AdjuntoModels>();
                entidad.ListaAdjuntos = JsonConvert.DeserializeObject<List<AdjuntoModels>>(ListaAdj);
                List<AdjuntoModels> listaDocPrincipal = entidad.ListaAdjuntos.Where(x => x.DocPrincipal == "1").ToList();
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var archivo = ms.ToArray();
                            auditoria = new Proxy().UploadFileService(
                                         entidad.IdExpediente,
                                         file.FileName,
                                         int.Parse(User.GetUserId()), archivo);
                            if (auditoria.EjecucionProceso)
                            {
                                if (auditoria.Objeto != null)
                                {
                                    entidad.ListaAdjuntos.Add(new AdjuntoModels
                                    {
                                        IdArchivo = Convert.ToInt64(auditoria.Objeto),
                                        NombreArchivo = file.FileName,
                                        PesoArchivo = (int)file.Length,
                                        Extension = System.IO.Path.GetExtension(file.FileName),
                                        FlgTipo = 1
                                    });
                                }
                            }
                        }
                    }
                }
                string _url = "";
                byte[] document = null;
                foreach (var item in listaDocPrincipal)
                {
                    using (WCFSeguridadEncripDesencripClient client = new WCFSeguridadEncripDesencripClient())
                    {
                        string llave = await client.traeLlaveAsync();
                        string tex = "{ IdDocCms:" + item.IdArchivo + ", IdUsu:" + User.GetUserId() + ", IdSis:" + AppSettings.AppId + "}";
                        string DOC = HttpUtility.UrlEncode(await client.encriptarAESAsync(tex, llave));
                        var urlVisorLF = AppSettings.UrlApiDownload;
                        _url = urlVisorLF + DOC + "&descarga=false";
                    }
                    using (WebClient client = new WebClient())
                    {
                        document = await client.DownloadDataTaskAsync(_url);
                    }
                    auditoria = new Proxy().UploadFileService(
                                         entidad.IdExpediente,
                                         item.NombreArchivo,
                                         int.Parse(User.GetUserId()), document);
                    if (auditoria.EjecucionProceso)
                    {
                        if (auditoria.Objeto != null)
                        {
                            entidad.ListaAdjuntos.Where(x => x.NombreArchivo == item.NombreArchivo).ToList().ForEach(d => d.IdArchivo = long.Parse(auditoria.Objeto.ToString()));

                        }
                    }
                }
                enAuditoria ApiExpedienteInser = await new CssApi().PostApi<enAuditoria>(new ApiParams
                {
                    EndPoint = AppSettings.baseUrlApi,
                    Url = $"ventanilla/DocRecepcion/recibir-expediente",
                    UserAD = AppSettings.UserAD,
                    PassAD = AppSettings.PassAD,
                    parametros = entidad
                });
                if (ApiExpedienteInser != null)
                    auditoria = ApiExpedienteInser;
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string codigo = Css_Log.Guardar(ex.Message.ToString());
                auditoria.MensajeSalida = codigo;
            }

            return Json(auditoria);
        }

        [HttpGet, Route("~/Digitalizacion/Recepcion/expediente-documento")]
        public async Task<ActionResult> ExpedienteVerDocumentoCompleto(long ID_EXPE)
        {
            int ID_USUARIO = int.Parse(User.GetUserId());
            DocumentoValidarModelView modelo = new DocumentoValidarModelView();
            enAuditoria auditoria = new enAuditoria();
            modelo.ID_DOCUMENTO = ID_EXPE;
            modelo.VALIDAR_ID_CONFORME = "";

            enAuditoria apiDocumento = await new CssApi().GetApi<enAuditoria>(new ApiParams
            {
                EndPoint = AppSettings.baseUrlApi,
                Url = $"ventanilla/documento/get-documento/{ID_EXPE}",
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


        [HttpPost, Route("~/Digitalizacion/Recepcion/expediente-guardarLF")]
        public async Task<ActionResult> ExpeditenteLFGuardar(long ID_DOC)
        {
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar();
            string _url = "";
            byte[] document = null;
            try
            {
                using (WCFSeguridadEncripDesencripClient client = new WCFSeguridadEncripDesencripClient())
                {
                    string llave = await client.traeLlaveAsync();
                    string tex = "{ IdDocCms:" + ID_DOC + ", IdUsu:" + User.GetUserId() + ", IdSis:" + AppSettings.AppId + "}";
                    string DOC = HttpUtility.UrlEncode(await client.encriptarAESAsync(tex, llave));
                    var urlVisorLF = AppSettings.UrlApiDownload;
                    _url = urlVisorLF + DOC + "&descarga=false";
                }
                using (WebClient client = new WebClient())
                {
                    document = await client.DownloadDataTaskAsync(_url);
                }
                //   using (var ms = new MemoryStream())
                // {
                // document.CopyTo(ms);
                var archivo = document.ToArray();
                string nombre_archivo = ID_DOC.ToString();
                int usuario = int.Parse(User.GetUserId());
                using (subir.WCFGeneralesDocCmsRegistroClient proxy = new subir.WCFGeneralesDocCmsRegistroClient())
                {
                    subir.DocCmsSubir datos = new subir.DocCmsSubir();
                    subir.Resultado respuesta = new subir.Resultado();
                    datos.IdSis = AppSettings.AppId;
                    datos.DesNomAbr = nombre_archivo;
                    datos.DesRuta = "VV/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + ID_DOC.ToString();
                    datos.Archivo = document;
                    datos.IdUsu = usuario;
                    datos.IdDocCms = -1;
                    datos.FlgPin = 0;
                    datos.IdDoc = -1;
                    datos.FlgDoc = 0;
                    datos.FlgCms = 1;
                    datos.IpAcceso = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    datos.Dato = string.Empty;
                    respuesta = proxy.insertarAsync(datos).Result;
                    if (!string.IsNullOrEmpty(respuesta.Valor))
                    {
                        auditoria.Objeto = respuesta.Valor;
                    }
                    else
                    {
                        auditoria.Rechazar(respuesta.DesError);
                    }
                }
                //  }
            }
            catch (Exception ex)
            {
                Css_Log.Guardar(ex.Message.ToString());
                auditoria.Error(ex);
            }
            return Json(auditoria);
        }

    }
}
