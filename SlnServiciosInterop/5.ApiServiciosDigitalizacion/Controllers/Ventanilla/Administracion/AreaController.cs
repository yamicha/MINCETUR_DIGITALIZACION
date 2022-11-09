using System;
using ApiServiciosDigitalizacion.resource.Ventanilla.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Administracion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos;
using EnServiciosDigitalizacion.Models.Ventanilla; 

namespace ApiServiciosDigitalizacion.Controllers.Ventanilla.Administracion
{
    [EnableCors("AccesoCors")]
    [Route("api/ventanilla/area")]
    public class AreaController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public AreaController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpPost]
        [Route("listar")]
        public IActionResult Area_Listar([FromBody] AreaModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (AreaRepositorio repositorio = new AreaRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Area_Listar(new enArea
                    {
                        DES_AREA = entidad.DescArea,
                        FLG_ESTADO = entidad.FlgEstado
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
