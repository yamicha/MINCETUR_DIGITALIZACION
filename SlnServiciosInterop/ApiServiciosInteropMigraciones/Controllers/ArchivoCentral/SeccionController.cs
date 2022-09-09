using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiServiciosMicroformas.resource.ArchivoCentral;
using EnServiciosMicroformas.ArchivoCentral;
using EnServiciosMicroformas;
using ApiServiciosMicroformas.Recursos;
using System.Net;
using System.Net.Http;

namespace ApiServiciosMicroformas.Controllers.ArchivoCentral
{
    [Route("api/archivo-central/seccion")]
    public class SeccionController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;

        public SeccionController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }



        [HttpPost]
        [Route("listar")]
        public ActionResult Seccion_Listar(enSeccion entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
                {
                    auditoria.OBJETO = repositorio.Seccion_Listar(entidad, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        string CodigoLog = Recursos.Css_Log.Guardar(auditoria.ERROR_LOG);
                        auditoria.MENSAJE_SALIDA = Recursos.Css_Log.Mensaje(CodigoLog);
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                auditoria.MENSAJE_SALIDA = ex.Message;
                auditoria.CODE = (int)HttpStatusCode.InternalServerError;
            }
            return Ok(auditoria);
        }

        //[HttpPost]
        //[Route("seccion-insertar")]
        //public ActionResult Seccion_Insertar(enSeccion entidad)
        //{
        //    enAuditoria auditoria = new enAuditoria();
        //    try
        //    {
        //        using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
        //        {
        //            auditoria.OBJETO = repositorio.Seccion_Listar(entidad, ref auditoria);
        //            if (!auditoria.EJECUCION_PROCEDIMIENTO)
        //            {
        //                string CodigoLog = Recursos.Css_Log.Guardar(auditoria.ERROR_LOG);
        //                auditoria.MENSAJE_SALIDA = Recursos.Css_Log.Mensaje(CodigoLog);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        auditoria.Error(ex);
        //        auditoria.MENSAJE_SALIDA = ex.Message;
        //        auditoria.CODE = (int)HttpStatusCode.InternalServerError;
        //    }
        //    return Content(HttpStatusCode.OK.ToString(), auditoria);
        //}

    }
}
