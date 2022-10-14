using ApiServiciosDigitalizacion.Models.ArchivoCentral.Administracion;
using ApiServiciosDigitalizacion.resource.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Utilitarios.Recursos;


namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Administracion
{
    [EnableCors("AccesoCors")]
    [Route("api/archivo-central/usuario")]
    public class UsuariosController : ControllerBase
    {

        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public UsuariosController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Usuario_Listar()
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (UsuarioRepositorio repositorio = new UsuarioRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Usuario_Listar( ref auditoria);
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
