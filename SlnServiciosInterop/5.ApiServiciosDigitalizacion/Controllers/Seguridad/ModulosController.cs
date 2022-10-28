using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServiciosDigitalizacion.resource.Seguridad;
using EnServiciosDigitalizacion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Helpers.Authorization;
using Utilitarios.Recursos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServiciosDigitalizacion.Controllers.Seguridad
{
    [EnableCors("AccesoCors")]
    [Route("api/seguridad/modulos/")]
    public class ModulosController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public ModulosController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpGet]
        [Route("listar/{ID_USU:long}/{ID_SIS:long}")]
        public IActionResult Modulos_Listar(long ID_USU, long ID_SIS)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (ModulosRepositorio repositorio = new ModulosRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Modulos_Listar(new enModulos { ID_USU = ID_USU, ID_SIS = ID_SIS }, ref auditoria);
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
