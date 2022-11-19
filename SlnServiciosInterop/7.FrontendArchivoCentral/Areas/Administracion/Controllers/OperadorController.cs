using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models;
using Frotend.ArchivoCentral.Micetur.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Controllers
{
    [MyAuthorize]
    [Area("Administracion")]
    [Route("[action]")]
    public class OperadorController : Controller
    {
        // GET: OperadorController
        [HttpGet, Route("~/Administracion/Operador")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Administracion/Operador/Mantenimiento")]
        public ActionResult Mantenimiento()
        {
            OperadorModelView model = new OperadorModelView();
            model.ListaUsuarios.Insert(0, new SelectListItem { Value = "", Text = "-- seleccione--" }); 
            return View(model);
        }

    }
}
