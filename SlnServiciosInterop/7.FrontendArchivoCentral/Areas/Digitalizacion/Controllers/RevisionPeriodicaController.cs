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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class RevisionPeriodicaController : Controller
    {
        // GET: RevisionPeriodicaController
        [HttpGet, Route("~/Digitalizacion/revision-periodica")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Digitalizacion/revision-periodica/evaluar")]
        public async Task<ActionResult> Revision_Evaluar()
        {
            RevisionPeriodicaModel model = new RevisionPeriodicaModel();
            model.Lista_Conforme.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            model.Lista_Conforme.Insert(1, new SelectListItem { Value = "1", Text = "Conforme" });
            model.Lista_Conforme.Insert(2, new SelectListItem { Value = "0", Text = "No Conforme" });

            model.Lista_TipoPrueba.Insert(0, new SelectListItem { Value = "1", Text = "Funcionalidad de los medios de soporte" });
            model.Lista_TipoPrueba.Insert(1, new SelectListItem { Value = "2", Text = "Identificación y recuperación de imágenes" });
            model.Lista_TipoPrueba.Insert(2, new SelectListItem { Value = "3", Text = "Integridad"});
            model.Lista_TipoPrueba.Insert(3, new SelectListItem { Value = "4", Text = "Legibilidad de Imagen/Impresión"});

            model.Lista_Accion.Insert(0, new SelectListItem { Value = "0", Text = "-- selecione --" });
            model.Lista_Accion.Insert(1, new SelectListItem { Value = "1", Text = "Reprocesar" });
            model.Lista_Accion.Insert(2, new SelectListItem { Value = "2", Text = "Anular" });

            enAuditoria resUsuario = await new CssApi().GetApi<enAuditoria>($"archivo-central/usuario/listar");
            if (resUsuario != null && !resUsuario.EjecucionProceso)
            {
                if (resUsuario.Rechazo)
                    Log.Guardar(resUsuario.ErrorLog);
            }
            else
            {
                if (resUsuario.Objeto != null)
                {
                    List<enUsuario> Lista = JsonConvert.DeserializeObject<List<enUsuario>>(resUsuario.Objeto.ToString());
                    if (Lista == null)
                        Lista = new List<enUsuario>();
                    model.Lista_Usuarios = Lista.Select(e => new SelectListItem()
                    {
                        Value = e.ID_USUARIO.ToString(), 
                        Text = e.NOMBRE_USUARIO         
                    }).ToList();
                    model.Lista_Usuarios.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
                }
            }

           //var task1 =  Task.Run(() => {
           //     // Just loop.
           //     int ctr = 0;
           //     for (ctr = 0; ctr <= 1000; ctr++)
           //     {
           //        Log.Guardar("task estoy trabajando"); 
           //      }
               
           // });
      
            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/revision-periodica/ver-revisiones")]
        public ActionResult Microforma_VerRevisiones(long ID_MICROFORMA)
        {
            RevisionPeriodicaModel model = new RevisionPeriodicaModel();
            model.ID_MICROFORMA = ID_MICROFORMA;

            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/revision-periodica/mantenimiento-reprocesar")]
        public async Task<ActionResult> Microforma_Reprocesar(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA; 
            try
            {
                model.Lista_TipoMicroArchivo = new List<SelectListItem>();
                model.Lista_TipoMicroArchivo.Insert(0, new SelectListItem { Value = "", Text = "-- Seleccione --" });
                model.Lista_TipoMicroArchivo.Insert(1, new SelectListItem { Value = "1", Text = "Propio" });
                model.Lista_TipoMicroArchivo.Insert(2, new SelectListItem { Value = "2", Text = "Tercerizado" });

                var parametessp = new parameters()
                {
                    FlgEstado = "1"
                };
                enAuditoria postseccion = await new CssApi().PostApi<enAuditoria>($"archivo-central/soporte/listar", parametessp);
                if (postseccion != null)
                {
                    if (!postseccion.EjecucionProceso)
                    {
                        if (postseccion.Rechazo)
                            Log.Guardar(postseccion.ErrorLog);
                    }
                    else
                    {
                        if (postseccion.Objeto != null)
                        {
                            List<enSoporte> Lista = JsonConvert.DeserializeObject<List<enSoporte>>(postseccion.Objeto.ToString());
                            if (Lista != null)
                            {
                                model.Lista_MICROFORMA_ID_TIPO_SOPORTE = Lista.Select(x => new SelectListItem
                                {
                                    Value = x.ID_SOPORTE.ToString(),
                                    Text = x.DESC_SOPORTE
                                }).ToList();
                            }
                        }
                    }
                }

                enAuditoria getmicroforma = await new CssApi().GetApi<enAuditoria>($"archivo-central/microforma/get-microforma/{ID_MICROFORMA}");
                if (getmicroforma != null)
                {
                    if (!getmicroforma.EjecucionProceso)
                    {
                        if (getmicroforma.Rechazo)
                            Log.Guardar(getmicroforma.ErrorLog);
                    }
                    else
                    {
                        if (getmicroforma.Objeto != null)
                        {
                            enMicroforma item = JsonConvert.DeserializeObject<enMicroforma>(getmicroforma.Objeto.ToString());
                            if (item == null) item = new enMicroforma();
                            model.MICROFORMA_ID_TIPO_SOPORTE = item.ID_TIPO_SOPORTE;
                            model.MICROFORMA_CODIGO_FEDATARIO = item.CODIGO_FEDATARIO;
                            model.MICROFORMA_FECHA = item.FECHA;
                            model.MICROFORMA_HORA = item.HORA;
                            model.MICROFORMA_ACTA = item.NRO_ACTA;
                            model.MICROFORMA_COPIAS = item.NRO_COPIAS;
                            model.MICROFORMA_OBSERVACION = item.OBSERVACION;
                            model.MICROFORMA_CODIGO_SOPORTE = item.CODIGO_SOPORTE;
                            model.MICROFORMA_NROVOLUMEN = item.NRO_VOLUMEN;
                            model.ID_DOC_APERTURA = item.ID_DOC_APERTURA;
                            model.ID_DOC_CIERRE = item.ID_DOC_CIERRE;
                            model.ID_DOC_CONFORMIDAD = item.ID_DOC_CONFORMIDAD;

                            model.MA_TIPO_ARCHIVO = item.MicroArchivo.TIPO_ARCHIVO;
                            model.MA_RESPONSABLE = item.MicroArchivo.RESPONSABLE;
                            model.MA_OBSERVACION = item.MicroArchivo.OBSERVACION;
                            model.MA_DIRECCION = item.MicroArchivo.DIRECCION;
                            model.MA_FECHA = item.MicroArchivo.FECHA;
                            model.MA_HORA = item.MicroArchivo.HORA;
                            model.MA_ID_DOC_ALMACENAMIENTO = item.MicroArchivo.ID_DOC_ALMACENAMIENTO;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            finally
            {
                model.Lista_MICROFORMA_ID_TIPO_SOPORTE.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            }

            return View(model);
        }

    }
}
