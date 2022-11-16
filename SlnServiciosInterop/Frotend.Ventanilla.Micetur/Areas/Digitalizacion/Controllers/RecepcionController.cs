using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion.Models.Ventanilla;
using Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models;
using Frotend.Ventanilla.Micetur.Authorization;
using Frotend.Ventanilla.Micetur.Controllers;
using Frotend.Ventanilla.Micetur.Filters;
using Frotend.Ventanilla.Micetur.Helpers;
using Frotend.Ventanilla.Micetur.Recursos;
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
            model.ListaAdjuntos = new List<AdjuntoModels>();
            try
            {
                model.IdExpediente = entidad.IdExpediente;
                model.UsuCrea = entidad.UsuCrea;
                if (entidad.ListaAdjuntos != null)
                {
                    for (var i = 0; i < entidad.ListaAdjuntos.Count(); i++)
                    {
                        if (entidad.ListaAdjuntos[i].FlgTipo == 1 && entidad.ListaAdjuntos[i].FlgLink == 0) // archivos de expdientes 
                        {
                            string path = Css_Ruta.Ruta_Temporal + entidad.ListaAdjuntos[i].CodigoArchivo;
                            if (System.IO.File.Exists(path))
                            {
                                var Archivo = System.IO.File.ReadAllBytes(path);
                                auditoria = new Proxy().UploadFileService(
                                            entidad.IdExpediente,
                                            entidad.ListaAdjuntos[i].NombreArchivo,
                                            int.Parse(User.GetUserId()), Archivo);
                                if (auditoria.EjecucionProceso)
                                {
                                    if (auditoria.Objeto != null)
                                        entidad.ListaAdjuntos[i].IdArchivo = Convert.ToInt64(auditoria.Objeto);
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
            finally
            {
                Task.Run(() =>
                {
                    foreach (var item in entidad.ListaAdjuntos)
                    {
                        if (item.FlgTipo == 1 && item.FlgLink == 0) // archivos de expdientes 
                        {
                            string path = Css_Ruta.Ruta_Temporal + item.CodigoArchivo;
                            if (System.IO.File.Exists(path))
                                System.IO.File.Delete(path);
                        }
                    }
                });
            }
            return Json(auditoria);
        }

   
    }
}
