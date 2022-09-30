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
    public class SoporteController : Controller
    {
        [HttpGet, Route("~/Administracion/Soporte")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet, Route("~/Administracion/Soporte/Mantenimiento")]
        public async Task<ActionResult> Mantenimiento(int id, string Accion)
        {
            enAuditoria auditoria = new enAuditoria();
            SoporteModelView model = new SoporteModelView
            {
                ACCION = Accion,
                ID_SOPORTE = id
            };
            try
            {
                if (Accion == "M")
                {
                    enAuditoria respuestapi = await new CssApi().GetApi<enAuditoria>($"archivo-central/soporte/get-soporte/{id}");
                    if (!respuestapi.EjecucionProceso)
                    {
                        if (respuestapi.Rechazo)
                            Log.Guardar(respuestapi.ErrorLog);
                    }
                    else
                    {
                        if (respuestapi.Objeto != null)
                        {
                            enSoporte item = JsonConvert.DeserializeObject<enSoporte>(respuestapi.Objeto.ToString());
                            model.DESC_SOPORTE = item.DESC_SOPORTE;
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
