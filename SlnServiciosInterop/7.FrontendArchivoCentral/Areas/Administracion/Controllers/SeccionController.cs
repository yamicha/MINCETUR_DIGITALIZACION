﻿using System;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion; 
using Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    [Route("[action]")]
    public class SeccionController : Controller
    {
        // GET: SeccionController
        [HttpGet, Route("~/Administracion/Seccion")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Administracion/Seccion/Mantenimiento")]
        public async Task<ActionResult> Mantenimiento(int id, string Accion)
        {
            enAuditoria auditoria = new enAuditoria();
            SeccionModelView model = new SeccionModelView
            {
                ACCION = Accion,
                ID_SECCION = id
            };
            try
            {
                if (Accion == "M")
                {
                 
                    enAuditoria respuestapi = await new CssApi().GetApi<enAuditoria>($"archivo-central/seccion/get-seccion/{id}");
                    if (!respuestapi.EjecucionProceso)
                    {
                        if (respuestapi.Rechazo)
                            Css_Log.Guardar(respuestapi.ErrorLog);
                    }
                    else
                    {
                        enSeccion item = JsonConvert.DeserializeObject<enSeccion>(respuestapi.Objeto.ToString());
                        model.DESC_CORTA_SECCION = item.DES_CORTA_SECCION;
                        model.DESC_LARGA_SECCION = item.DES_LARGA_SECCION;
                    }
                }
            }
            catch (Exception ex) {
                auditoria.Error(ex); 
            }
            return View(model);
        }

    }
}
