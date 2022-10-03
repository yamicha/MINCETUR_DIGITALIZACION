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
        public async Task<ActionResult> Mantenimiento(string accion)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            try
            {
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
