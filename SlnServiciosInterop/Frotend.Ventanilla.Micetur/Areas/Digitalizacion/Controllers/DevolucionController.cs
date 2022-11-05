using System;
using System.Collections.Generic;
using Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models;
using Frotend.Ventanilla.Micetur.Authorization;
using Frotend.Ventanilla.Micetur.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Utilitarios.Recursos;
namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Controllers
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
        public ActionResult Mantenimiento(string Accion)
        {
            DevolverModelView model = new DevolverModelView();
            try
            {
                model.NOMBRE_USUARIO = User.GetUserName();
                model.ListaArea = new List<SelectListItem>();
                model.ListaArea.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            return View(model);
        }


    }
}
