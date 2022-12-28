using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Enums;
using Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models;
using Frotend.Ventanilla.Micetur.Authorization;
using Frotend.Ventanilla.Micetur.Filters;
using Frotend.Ventanilla.Micetur.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Utilitarios.Recursos; 
namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class ControlAlmacenamientoController : Controller
    {

        // GET: ControlAlamcenamientioController
        [HttpGet, Route("~/Digitalizacion/control-almacenamiento")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Digitalizacion/control-almacenamiento/mantenimiento-microarchivo")]
        public async Task<ActionResult> Mantenimiento_MicroArchivo(long ID_MICROFORMA, string Accion)
        {
            MicroArchivoModel model = new MicroArchivoModel();
            model.ID_MICROFORMA = ID_MICROFORMA;
            model.Accion = Accion;
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

                model.MA_RESPONSABLE = User.GetUserName();
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/control-almacenamiento/Ver-microarchivo")]
        public async Task<ActionResult> MicroArchivo_Ver(long ID_MICROFORMA, string Accion)
        {
            MicroArchivoModel model = new MicroArchivoModel();
            model.ID_MICROFORMA = ID_MICROFORMA;
            model.Accion = Accion;

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
            return View(model);
        }

    }
}
