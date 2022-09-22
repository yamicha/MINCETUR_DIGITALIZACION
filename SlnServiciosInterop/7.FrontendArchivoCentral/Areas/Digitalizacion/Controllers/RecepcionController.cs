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
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            int id = 25; 
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
                        modelo.Lista_ID_CONTROL_CARGA = Lista.Select(x => new SelectListItem()
                        {
                            Text = "N° : " + x.ID_CONTROL_CARGA.ToString() + " | Fecha : " + x.STR_FEC_CREACION + " | N° Registros : " + x.NRO_REGISTROS,
                            Value = x.ID_CONTROL_CARGA.ToString()
                        }).ToList();
                        modelo.Lista_ID_CONTROL_CARGA.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });
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
