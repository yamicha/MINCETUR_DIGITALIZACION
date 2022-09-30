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
    public class ObservacionController : Controller
    {
        [HttpGet, Route("~/Administracion/Observacion")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Administracion/Observacion/Mantenimiento")]
        public async Task<ActionResult> Mantenimiento(int id, string Accion)
        {
            enAuditoria auditoria = new enAuditoria();
            ObservacionModelView model = new ObservacionModelView
            {
                ACCION = Accion,
                ID_OBSERVACION = id
            };
            try
            {
                if (Accion == "M")
                {
                    enAuditoria respuestapi = await new CssApi().GetApi<enAuditoria>($"archivo-central/observacion/get-observacion/{id}");
                    if (!respuestapi.EjecucionProceso)
                    {
                        if (respuestapi.Rechazo)
                            Log.Guardar(respuestapi.ErrorLog);
                    }
                    else
                    {
                        if (respuestapi.Objeto != null)
                        {
                            enObservacion item = JsonConvert.DeserializeObject<enObservacion>(respuestapi.Objeto.ToString());
                            model.DESC_OBSERVACION = item.DESC_OBSERVACION;
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
