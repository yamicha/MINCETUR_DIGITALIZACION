using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models; 

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class RecepcionController : Controller
    {

        // GET: SeccionController
        [HttpGet, Route("~/Digitalizacion/recepcion")]
        public ActionResult Index()
        {
            enAuditoria auditoria = new enAuditoria();
            RecepcionModelView modelo = new RecepcionModelView(); 
            try
            {
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);

            }
            return View(modelo);
        }


      
    }
}
