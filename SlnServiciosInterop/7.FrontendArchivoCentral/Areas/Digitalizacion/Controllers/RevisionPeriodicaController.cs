using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Filters;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class RevisionPeriodicaController : Controller
    {
        // GET: RevisionPeriodicaController
        [HttpGet, Route("~/Digitalizacion/revision-periodica")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Digitalizacion/revision-periodica/evaluar")]
        public async Task<ActionResult> Revision_Evaluar()
        {
            RevisionPeriodicaModel model = new RevisionPeriodicaModel();
            model.Lista_Conforme.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            model.Lista_Conforme.Insert(1, new SelectListItem { Value = "1", Text = "Conforme" });
            model.Lista_Conforme.Insert(2, new SelectListItem { Value = "0", Text = "No Conforme" });

            model.Lista_TipoPrueba.Insert(0, new SelectListItem { Value = "1", Text = "Funcionalidad de los medios de soporte" });
            model.Lista_TipoPrueba.Insert(1, new SelectListItem { Value = "2", Text = "Identificación y recuperación de imágenes" });
            model.Lista_TipoPrueba.Insert(2, new SelectListItem { Value = "3", Text = "Integridad"});
            model.Lista_TipoPrueba.Insert(3, new SelectListItem { Value = "4", Text = "Legibilidad de Imagen/Impresión"});

            model.Lista_Accion.Insert(0, new SelectListItem { Value = "0", Text = "-- selecione --" });
            model.Lista_Accion.Insert(1, new SelectListItem { Value = "1", Text = "Reprocesar" });
            model.Lista_Accion.Insert(2, new SelectListItem { Value = "2", Text = "Anular" });

            enAuditoria resUsuario = await new CssApi().GetApi<enAuditoria>($"archivo-central/usuario/listar");
            if (resUsuario != null && !resUsuario.EjecucionProceso)
            {
                if (resUsuario.Rechazo)
                    Log.Guardar(resUsuario.ErrorLog);
            }
            else
            {
                if (resUsuario.Objeto != null)
                {
                    List<enUsuario> Lista = JsonConvert.DeserializeObject<List<enUsuario>>(resUsuario.Objeto.ToString());
                    if (Lista == null)
                        Lista = new List<enUsuario>();
                    model.Lista_Usuarios = Lista.Select(e => new SelectListItem()
                    {
                        Value = e.ID_USUARIO.ToString(), 
                        Text = e.NOMBRE_USUARIO         
                    }).ToList();
                    model.Lista_Usuarios.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
                }
            }

            return View(model);
        }

    }
}
