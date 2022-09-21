using System;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utilitarios.Recursos;
using EnServiciosDigitalizacion.ArchivoCentral.Carga.Vistas;
using System.Collections.Generic;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class RecepcionController : Controller
    {

        // GET: SeccionController
        [HttpGet, Route("~/Digitalizacion/recepcion")]
        public async Task<ActionResult> Index()
        {
            int id = 0; 
            enAuditoria auditoria = new enAuditoria();
            RecepcionModelView modelo = new RecepcionModelView(); 
            try
            {
                enAuditoria respuestapi = await new CssApi().GetApi<enAuditoria>($"archivo-central/carga/listar/{id}");
                if (!respuestapi.EjecucionProceso)
                {
                    if (respuestapi.Rechazo)
                        Log.Guardar(respuestapi.ErrorLog);
                }
                else
                {
                    if (respuestapi.Objeto != null)
                    {
                        List<enControlCarga> Lista = JsonConvert.DeserializeObject<List<enControlCarga>>(respuestapi.Objeto.ToString());

                        //model.DESC_CORTA_SECCION = Lista.DES_CORTA_SECCION;
                        //model.DESC_LARGA_SECCION = Lista.DES_LARGA_SECCION;
                    }
                }

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);

            }
            return View(modelo);
        }


      
    }
}
