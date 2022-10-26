using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion.Models;
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
        public ActionResult Revision_Evaluar()
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
            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/revision-periodica/ver-revisiones")]
        public ActionResult Microforma_VerRevisiones(long ID_MICROFORMA)
        {
            RevisionPeriodicaModel model = new RevisionPeriodicaModel();
            model.ID_MICROFORMA = ID_MICROFORMA;

            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/revision-periodica/mantenimiento-reprocesar")]
        public ActionResult Microforma_Reprocesar(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA; 
            try
            {
                model.Lista_TipoMicroArchivo = new List<SelectListItem>();
                model.Lista_TipoMicroArchivo.Insert(0, new SelectListItem { Value = "", Text = "-- Seleccione --" });
                model.Lista_TipoMicroArchivo.Insert(1, new SelectListItem { Value = "1", Text = "Propio" });
                model.Lista_TipoMicroArchivo.Insert(2, new SelectListItem { Value = "2", Text = "Tercerizado" });
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
