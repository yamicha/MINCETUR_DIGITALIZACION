using System;
using System.Collections.Generic;
using Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models;
using Frotend.Ventanilla.Micetur.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Utilitarios.Recursos; 

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class MicroformaController : Controller
    {
        // GET: MicroformaController
        [HttpGet, Route("~/Digitalizacion/microformas")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet, Route("~/Digitalizacion/microformas/mantenimiento")]
        public ActionResult Mantenimiento(string accion, long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            try
            {

                model.ID_MICROFORMA = ID_MICROFORMA;
                model.Accion = accion;
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

        [HttpGet, Route("~/Digitalizacion/microformas/microforma-ver")]
        public ActionResult Microforma_Ver(long ID_MICROFORMA)
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

        [HttpGet, Route("~/Digitalizacion/microformas/microforma-GrabadaVer")]
        public ActionResult MicroformaGrabada_Ver(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA;
            model.Lista_MICROFORMA_ID_TIPO_SOPORTE.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/microformas/microforma-validar")]
        public ActionResult Microforma_Validar(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA;
            try
            {
                model.Lista_MICROFORMA_ID_CONFORME = new List<SelectListItem>();
                model.Lista_MICROFORMA_ID_CONFORME.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
                model.Lista_MICROFORMA_ID_CONFORME.Insert(1, new SelectListItem { Value = "1", Text = "Conforme" });
                model.Lista_MICROFORMA_ID_CONFORME.Insert(2, new SelectListItem { Value = "0", Text = "No Conforme" });
              
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

        [HttpGet, Route("~/Digitalizacion/microformas/ver-observaciones")]
        public ActionResult Microforma_Obs(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA;

            return View(model);
        }


        [HttpGet, Route("~/Digitalizacion/microformas/proceso")]
        public ActionResult Microforma_VerProceso(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA;

            return View(model);
        }

    }
}
