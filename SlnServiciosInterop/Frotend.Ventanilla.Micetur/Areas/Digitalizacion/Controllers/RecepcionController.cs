﻿using System;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
//using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
//using Frotend.Ventanilla.Micetur.Areas.Administracion.Models;
using Frotend.Ventanilla.Micetur.Filters;
using Frotend.Ventanilla.Micetur.Helpers;
using Frotend.Ventanilla.Micetur.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Frotend.Ventanilla.Micetur.Authorization;

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
    }
}