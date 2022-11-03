using System;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
//using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models;
using Frotend.Ventanilla.Micetur.Filters;
using Frotend.Ventanilla.Micetur.Helpers;
using Frotend.Ventanilla.Micetur.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Frotend.Ventanilla.Micetur.Authorization;
//using Utilitarios.Helpers;
using EnServiciosDigitalizacion.Ventanilla.Consulta;
using Utilitarios.Helpers;

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]

    public class RecepcionController : Controller
    {
        [HttpGet, Route("~/Digitalizacion/recepcion")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Digitalizacion/Recepcion/RecibirDoc")]
        public async Task<ActionResult> RecibirDoc(long ID_EXPE)
        {
            RecibirModelView modelo = new RecibirModelView();
            modelo.ID_EXPE = ID_EXPE;
            try
            {
            }
            catch (Exception ex)
            {
                Css_Log.Guardar(ex.Message.ToString());
            }
            return View(modelo);
        }

        [HttpGet, Route("~/Digitalizacion/Recepcion/editar-documento")]
        public async Task<ActionResult>  EditarDocumento(long id)
        {
            RecibirModelView modelo = new RecibirModelView();
            modelo.ID_DOC = id; 
            return View(modelo);
        }


    }
}
