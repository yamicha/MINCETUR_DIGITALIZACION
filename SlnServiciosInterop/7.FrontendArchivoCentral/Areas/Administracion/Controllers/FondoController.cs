using System;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models;
using Frotend.ArchivoCentral.Micetur.Filters;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Frotend.ArchivoCentral.Micetur.Authorization;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Controllers
{
    [MyAuthorize]
    [Area("Administracion")]
    [Route("[action]")]
    public class FondoController : Controller
    {
        [HttpGet, Route("~/Administracion/Fondo")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet, Route("~/Administracion/Fondo/Mantenimiento")]
        public async Task<ActionResult> Mantenimiento(int id, string Accion)
        {
            enAuditoria auditoria = new enAuditoria();
            FondoModelView model = new FondoModelView
            {
                ACCION = Accion,
                ID_FONDO = id
            };
            try
            {
                if (Accion == "M")
                {
                    //enAuditoria respuestapi = await new CssApi().GetApi<enAuditoria>($"archivo-central/Fondo/get-fondo/{id}");
                    enAuditoria respuestapi = await new CssApi().GetApi<enAuditoria>($"archivo-central/Fondo/get-fondo/{id}",User.GetUserToken());
                    if (!respuestapi.EjecucionProceso)
                    {
                        if (respuestapi.Rechazo)
                            Log.Guardar(respuestapi.ErrorLog);
                    }
                    else
                    {
                        if (respuestapi.Objeto != null)
                        {
                            enFondo item = JsonConvert.DeserializeObject<enFondo>(respuestapi.Objeto.ToString());
                            model.DESC_FONDO = item.DESC_FONDO;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            return View(model);
        }

    }
}
