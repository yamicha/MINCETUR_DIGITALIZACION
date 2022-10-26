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
        public  ActionResult Mantenimiento(string Accion)
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
