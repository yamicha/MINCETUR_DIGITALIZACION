using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.Lista_MICROFORMA_ID_CONFORME.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            model.Lista_MICROFORMA_ID_CONFORME.Insert(1, new SelectListItem { Value = "1", Text = "Conforme" });
            model.Lista_MICROFORMA_ID_CONFORME.Insert(2, new SelectListItem { Value = "0", Text = "No Conforme" });

            model.Lista_Tipo_Pruebas.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            model.Lista_Tipo_Pruebas.Insert(1, new SelectListItem { Value = "1", Text = "Funcionalidad de los medios de soporte" });
            model.Lista_Tipo_Pruebas.Insert(2, new SelectListItem { Value = "2", Text = "Identificación y recuperación de imágenes" });
            model.Lista_Tipo_Pruebas.Insert(2, new SelectListItem { Value = "3", Text = "Integridad, Legibilidad de Imagen" });
            model.Lista_Tipo_Pruebas.Insert(2, new SelectListItem { Value = "4", Text = "Impresión" });

            return View(model);
        }

    }
}
