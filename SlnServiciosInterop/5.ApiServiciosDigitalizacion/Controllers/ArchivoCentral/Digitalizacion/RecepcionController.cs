using System;
using EnServiciosDigitalizacion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos;
using ApiServiciosDigitalizacion.resource.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using System.Collections.Generic;
using System.Linq;
using ApiServiciosDigitalizacion.Models.ArchivoCentral.Digitalizacion;
using System.Net;

namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Digitalizacion
{
    [EnableCors("AccesoCors")]
    [Route("api/archivo-central/recepcion")]
    public class RecepcionController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public RecepcionController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpGet]
        [Route("listar-lotes/{id:int}")]
        public IActionResult Lote_Listar(long id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (RepcepcionRepositorio repositorio = new RepcepcionRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Lote_Listar(new enLote
                    {
                         ID_LOTE    = id 
                    }, ref auditoria);
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Log.Mensaje(CodigoLog);
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                auditoria.MensajeSalida = ex.Message;
            }
            return StatusCode(auditoria.Code, auditoria);
        }


    }
}
