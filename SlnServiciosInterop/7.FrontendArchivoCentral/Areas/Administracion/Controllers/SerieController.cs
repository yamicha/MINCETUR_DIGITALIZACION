using System;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    [Route("[action]")]
    public class SerieController : Controller
    {
        [HttpGet, Route("~/Administracion/Serie")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Administracion/Serie/Mantenimiento")]
        public async Task<ActionResult> Mantenimiento(int id, string Accion)
        {
            enAuditoria auditoria = new enAuditoria();
            SerieModelView model = new SerieModelView
            {
                ACCION = Accion,
                ID_SERIE = id
            };
            try
            {
                if (Accion == "M")
                {
                    enAuditoria respuestapi = await new CssApi().GetApi<enAuditoria>($"archivo-central/Serie/get-serie/{id}");
                    if (!respuestapi.EjecucionProceso)
                    {
                        if (respuestapi.Rechazo)
                            Log.Guardar(respuestapi.ErrorLog);
                    }
                    else
                    {
                        if (respuestapi.Objeto != null)
                        {
                            enSerie item = JsonConvert.DeserializeObject<enSerie>(respuestapi.Objeto.ToString());
                            model.DES_SERIE = item.DES_SERIE;
                        }
                    }
                }
                else
                {
                    enAuditoria respuestapi = await new CssApi().GetApi<enAuditoria>($"archivo-central/seccion/listar");
                    if (!respuestapi.EjecucionProceso)
                    {
                        if (respuestapi.Rechazo)
                            Log.Guardar(respuestapi.ErrorLog);
                    }
                    else
                    {
                        if (respuestapi.Objeto != null)
                        {
                            enSerie item = JsonConvert.DeserializeObject<enSerie>(respuestapi.Objeto.ToString());
                            model.DES_SERIE = item.DES_SERIE;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            return View(model);
        }


    }
}
