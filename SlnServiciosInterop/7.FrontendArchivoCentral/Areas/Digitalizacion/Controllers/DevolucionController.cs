using Frotend.ArchivoCentral.Micetur.Filters;
using Microsoft.AspNetCore.Mvc;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Authorization;
using System;
using Frotend.ArchivoCentral.Micetur.Recursos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using EnServiciosDigitalizacion.Models;
using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Helpers;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class DevolucionController : Controller
    {
        // GET: DevolucionController
        [HttpGet, Route("~/Digitalizacion/devolucion-documento")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Digitalizacion/devolucion/mantenimiento")]
        public async Task<ActionResult> Mantenimiento(string Accion)
        {
            DevolverModelView model = new DevolverModelView();
            try
            {
                model.NOMBRE_USUARIO = User.GetUserName();
                model.ListaArea = new List<SelectListItem>();
                var paramarea= new parameters()
                {
                    FlgEstado = "1"
                };
                enAuditoria postArea = await new CssApi().PostApi<enAuditoria>($"archivo-central/area/listar", paramarea);
                if (postArea != null)
                {
                    if (!postArea.EjecucionProceso)
                    {
                        if (postArea.Rechazo)
                            Log.Guardar(postArea.ErrorLog);
                    }
                    else
                    {
                        if (postArea.Objeto != null)
                        {
                            List<enArea> Lista = JsonConvert.DeserializeObject<List<enArea>>(postArea.Objeto.ToString());
                            if (Lista != null)
                            {
                                model.ListaArea = Lista.Select(x => new SelectListItem
                                {
                                    Value = x.ID_AREA.ToString(),
                                    Text = x.DES_AREA
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
                model.ListaArea.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            }

            return View(model);
        }


    }
}
