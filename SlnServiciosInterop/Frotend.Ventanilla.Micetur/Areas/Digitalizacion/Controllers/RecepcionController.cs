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

    }
}
