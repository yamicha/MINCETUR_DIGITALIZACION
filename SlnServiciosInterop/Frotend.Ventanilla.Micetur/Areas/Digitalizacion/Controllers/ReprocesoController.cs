using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;
using Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models;
using Frotend.Ventanilla.Micetur.Filters;
using Frotend.Ventanilla.Micetur.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Utilitarios.Helpers;

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class ReprocesoController : Controller
    {

        [HttpGet, Route("~/Digitalizacion/reproceso")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Digitalizacion/reproceso/mantinimiento")]
        public async Task<ActionResult> Mantenimiento(long ID_DOCUMENTO)
        {
            ReprocesoModels modelo = new ReprocesoModels();
            modelo.ID_DOCUMENTO = ID_DOCUMENTO;
            enAuditoria apiDocumento = await new CssApi().GetApi<enAuditoria>(new ApiParams
            {
                EndPoint = AppSettings.baseUrlApi,
                Url = $"ventanilla/documento/get-documento/{ID_DOCUMENTO}",
                UserAD = AppSettings.UserAD,
                PassAD = AppSettings.PassAD
            });
            if (apiDocumento != null)
            {
                if (!apiDocumento.Rechazo)
                {
                    if (apiDocumento.Objeto != null)
                    {
                        enDocumento Documento = JsonConvert.DeserializeObject<enDocumento>(apiDocumento.Objeto.ToString());
                        if (Documento != null)
                        {
                            modelo.EXP_OBSERVACION = Documento.EXP_OBSERVACION;
                        }

                    }
                }
            }
            return View(modelo);
        }

        [HttpGet, Route("~/Digitalizacion/reproceso/editar-adjunto")]
        public ActionResult EditarAdjunto()
        {
            return View();
        }

    }
}
