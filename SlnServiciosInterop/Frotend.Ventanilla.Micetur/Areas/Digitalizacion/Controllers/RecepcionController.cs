using System;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
//using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models;
using Frotend.Ventanilla.Micetur.Filters;
using Frotend.Ventanilla.Micetur.Helpers;
using Frotend.Ventanilla.Micetur.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EnServiciosDigitalizacion.Models.Ventanilla;
using Frotend.Ventanilla.Micetur.Controllers;
using System.IO;
using Frotend.Ventanilla.Micetur.Authorization;
using Utilitarios.Helpers;
using System.Linq;
using System.Collections.Generic;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            enAuditoria ApiUsuarios = await new CssApi().GetApi<enAuditoria>(new ApiParams
            {
                EndPoint = AppSettings.baseUrlApi,
                Url = $"archivo-central/usuario/listar",
                UserAD = AppSettings.UserAD,
                PassAD = AppSettings.PassAD,
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
            else {
                model.ListaPersonal.Insert(0, new SelectListItem { Value = "", Text = "--sin usuarios--" }); 
            }
            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/Recepcion/RecibirDoc")]
        public ActionResult RecibirDoc(long ID_EXPE)
        {
            RecibirModelView modelo = new RecibirModelView();
            modelo.ID_EXPE = ID_EXPE;
            try
            {
      
            }
            catch (Exception ex)
            {
                Css_Log.Guardar(ex.Message.ToString());
            }
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
        public async Task<ActionResult> ExpedienteRecibir([FromBody] ExpedienteModels entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar(); 
            ExpedienteModels model = new ExpedienteModels();
            try
            {
                model.IdExpediente = entidad.IdExpediente;
                model.UsuCrea = entidad.UsuCrea; 
                if (entidad.ListaAdjuntos != null)
                {
                    foreach (AdjuntoModels item in entidad.ListaAdjuntos)
                    {
                        string path = Directory.GetCurrentDirectory() + @"\Recursos\Temporal\" + item.CodigoArchivo;
                        if (System.IO.File.Exists(path) && item.FlgTipo == 1 && item.FlgLink == 0) // archivos de expdientes 
                        {
                            var Archivo = System.IO.File.ReadAllBytes(path);
                            auditoria = new Proxy().UploadFileService(entidad.IdExpediente, item.NombreArchivo, int.Parse(User.GetUserId()), Archivo);
                            if (!auditoria.EjecucionProceso)
                            {
                                //if (auditoria.Objeto != null)
                                //    model.ListaAdjuntos.Add(new AdjuntoModels
                                //    {
                                //        IdArchivo = (long)auditoria.Objeto,
                                //        FlgTipo = item.FlgTipo, // archivos de expediente
                                //        NombreArchivo = item.NombreArchivo,
                                //        Extension = item.Extension,
                                //        PesoArchivo = item.PesoArchivo,
                                //        FlgLink = item.FlgLink
                                //    });
                            }
                        }
                    }
                }
                if (auditoria.EjecucionProceso)
                {
                    model.ListaAdjuntos = entidad.ListaAdjuntos.Where(x => x.FlgTipo == 2).ToList();  // documentos extras
                    enAuditoria ApiExpedienteInser = await new CssApi().PostApi<enAuditoria>(new ApiParams
                    {
                        EndPoint = AppSettings.baseUrlApi,
                        Url = $"ventanilla/DocRecepcion/recibir-expediente",
                        UserAD = AppSettings.UserAD,
                        PassAD = AppSettings.PassAD,
                        parametros = model
                    });
                    if (ApiExpedienteInser != null)
                        auditoria = ApiExpedienteInser; 
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string codigo = Css_Log.Guardar(ex.Message.ToString());
                auditoria.MensajeSalida = codigo;
            }
            return Json(auditoria);
        }


    }
}
