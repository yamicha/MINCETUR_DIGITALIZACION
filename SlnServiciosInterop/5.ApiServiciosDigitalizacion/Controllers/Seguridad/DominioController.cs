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


namespace ApiServiciosDigitalizacion.Controllers.Seguridad
{
    [EnableCors("AccesoCors")]
    [Route("api/recursivo/dominio/")]
    public class DominioController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public DominioController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }
        [HttpGet]
        [Route("listar/{FlgEstado:int}")]
        public IActionResult Dominio_Listar(int FlgEstado)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DominioRepositorio repositorio = new DominioRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Dominio_Listar(new enDominio { FLG_ESTADO = FlgEstado }, ref auditoria);
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
