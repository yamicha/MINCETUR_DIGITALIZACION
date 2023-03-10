using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Filters;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Utilitarios.Helpers;
using EnServiciosDigitalizacion.Enums;
using Newtonsoft.Json;
using System.Linq;

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
            enAuditoria ApiDominio = await new CssApi().GetApi<enAuditoria>(new ApiParams
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
                        // lista conforme
                        model.Lista_Conforme = ListaDominios
                        .Where(s => s.ID_DOMINIO_PADRE == (long)Dominios.EvalucionCalidad)
                        .Select(x => new SelectListItem
                        {
                            Text = x.DESC_ITEM,
                            Value = x.COD_ITEM,
                        }).ToList();
                        // lista prueba
                        model.Lista_TipoPrueba = ListaDominios
                         .Where(s => s.ID_DOMINIO_PADRE == (long)Dominios.TipoRevision)
                         .Select(x => new SelectListItem
                         {
                             Text = x.DESC_ITEM,
                             Value = x.COD_ITEM,
                         }).ToList();
                        // lista accion
                        model.Lista_Accion = ListaDominios
                          .Where(s => s.ID_DOMINIO_PADRE == (long)Dominios.AccionRevision)
                         .Select(x => new SelectListItem
                         {
                             Text = x.DESC_ITEM,
                             Value = x.COD_ITEM,
                         }).ToList();

                        
                        model.Lista_Conforme.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
                        model.Lista_Accion.Insert(0, new SelectListItem { Value = "0", Text = "-- selecione --" });
                    }
                }
            }

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
                enAuditoria ApiDominio = await new CssApi().GetApi<enAuditoria>(new ApiParams
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

                            model.Lista_TipoMicroArchivo = ListaDominios
                              .Where(s => s.ID_DOMINIO_PADRE == (long)Dominios.TipoMicroArchivo)
                             .Select(x => new SelectListItem
                             {
                                 Text = x.DESC_ITEM,
                                 Value = x.COD_ITEM,
                             }).ToList();
                            model.Lista_TipoMicroArchivo.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });

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
