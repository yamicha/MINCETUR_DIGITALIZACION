using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Filters;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using EnServiciosDigitalizacion.Models;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using Frotend.ArchivoCentral.Micetur.Authorization;
using EnServiciosDigitalizacion.Enums;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class MicroformaController : Controller
    {
        // GET: MicroformaController
        [HttpGet, Route("~/Digitalizacion/microformas")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet, Route("~/Digitalizacion/microformas/mantenimiento")]
        public ActionResult Mantenimiento(string accion, long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            try
            {

                model.ID_MICROFORMA = ID_MICROFORMA;
                model.Accion = accion;
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

        [HttpGet, Route("~/Digitalizacion/microformas/microforma-ver")]
        public async Task<ActionResult> Microforma_Ver(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA; 
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

        [HttpGet, Route("~/Digitalizacion/microformas/microforma-GrabadaVer")]
        public ActionResult MicroformaGrabada_Ver(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA;
            model.Lista_MICROFORMA_ID_TIPO_SOPORTE.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/microformas/microforma-validar")]
        public async Task<ActionResult> Microforma_Validar(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA;
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
                            model.Lista_MICROFORMA_ID_CONFORME = ListaDominios
                              .Where(s => s.ID_DOMINIO_PADRE == (long)Dominios.EvalucionCalidad)
                             .Select(x => new SelectListItem
                             {
                                 Text = x.DESC_ITEM,
                                 Value = x.COD_ITEM,
                             }).ToList();
                            model.Lista_MICROFORMA_ID_CONFORME.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
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

        [HttpGet, Route("~/Digitalizacion/microformas/ver-observaciones")]
        public ActionResult Microforma_Obs(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA;

            return View(model);
        }


        [HttpGet, Route("~/Digitalizacion/microformas/proceso")]
        public ActionResult Microforma_VerProceso(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA;

            return View(model);
        }

    }
}
