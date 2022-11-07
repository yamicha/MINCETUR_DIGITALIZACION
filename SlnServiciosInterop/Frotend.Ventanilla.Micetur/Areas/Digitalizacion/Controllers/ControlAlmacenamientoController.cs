﻿using System;
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
    public class ControlAlmacenamientoController : Controller
    {

        // GET: ControlAlamcenamientioController
        [HttpGet, Route("~/Digitalizacion/control-almacenamiento")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Digitalizacion/control-almacenamiento/mantenimiento-microarchivo")]
        public ActionResult Mantenimiento_MicroArchivo(long ID_MICROFORMA, string Accion)
        {
            MicroArchivoModel model = new MicroArchivoModel();
            model.ID_MICROFORMA = ID_MICROFORMA;
            model.Accion = Accion;
            try
            {
                model.Lista_TipoMicroArchivo = new List<SelectListItem>();
                model.Lista_TipoMicroArchivo.Insert(0, new SelectListItem { Value = "", Text = "-- Seleccione --" });
                model.Lista_TipoMicroArchivo.Insert(1, new SelectListItem { Value = "1", Text = "Propio" });
                model.Lista_TipoMicroArchivo.Insert(2, new SelectListItem { Value = "2", Text = "Tercerizado" });
                model.MA_RESPONSABLE = User.GetUserName();
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/control-almacenamiento/Ver-microarchivo")]
        public ActionResult MicroArchivo_Ver(long ID_MICROFORMA, string Accion)
        {
            MicroArchivoModel model = new MicroArchivoModel();
            model.ID_MICROFORMA = ID_MICROFORMA;
            model.Accion = Accion;
            model.Lista_TipoMicroArchivo = new List<SelectListItem>();
            model.Lista_TipoMicroArchivo.Insert(0, new SelectListItem { Value = "", Text = "-- Seleccione --" });
            model.Lista_TipoMicroArchivo.Insert(1, new SelectListItem { Value = "1", Text = "Propio" });
            model.Lista_TipoMicroArchivo.Insert(2, new SelectListItem { Value = "2", Text = "Tercerizado" });
            return View(model);
        }

    }
}