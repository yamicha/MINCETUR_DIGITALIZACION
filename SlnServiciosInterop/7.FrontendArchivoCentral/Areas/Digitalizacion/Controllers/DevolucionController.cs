using Frotend.ArchivoCentral.Micetur.Filters;
using Microsoft.AspNetCore.Mvc;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Authorization;
using System;
using Frotend.ArchivoCentral.Micetur.Recursos ;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public ActionResult Mantenimiento(string Accion)
        {
            DevolverModelView model = new DevolverModelView();
            try
            {
                model.NOMBRE_USUARIO = User.GetUserName();
                model.ListaArea = new List<SelectListItem>(); 
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            finally {
                model.ListaArea.Insert(0, new SelectListItem {Value = "" , Text = "-- selecione --" }); 
            }

            return View(model);
        }


    }
}
