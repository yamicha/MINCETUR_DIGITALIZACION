using EnServiciosDigitalizacion;
using Frotend.Ventanilla.Micetur.Areas.Administracion.Models;
using Frotend.Ventanilla.Micetur.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.Ventanilla.Micetur.Areas.Administracion.Controllers
{
    [MyAuthorize]
    [Area("Administracion")]
    [Route("[action]")]
    public class OperadorController : Controller
    {
        [HttpGet, Route("~/Administracion/Operador")]
        public IActionResult Index()
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
