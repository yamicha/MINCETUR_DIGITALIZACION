using EnServiciosDigitalizacion.Models.Ventanilla;
using ApiServiciosDigitalizacion.resource.Ventanilla.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Administracion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Utilitarios.Recursos;
namespace ApiServiciosDigitalizacion.Controllers.Ventanilla.Administracion
{
    [EnableCors("AccesoCors")]
    [Route("api/ventanilla/operador")]
    [ApiController]
    public class OperadorController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public OperadorController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpPost]
        [Route("listar")]
        public IActionResult Operador_Listar([FromBody] OperadorModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (OperadorRepositorio repositorio = new OperadorRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Operador_Listar(new enOperador
                    {
                        NOMBRE_USUARIO = entidad.NombreUsuario,
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

        [HttpPost]
        [Route("insertar")]
        public IActionResult Operador_Insertar([FromBody] OperadorModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (OperadorRepositorio repositorio = new OperadorRepositorio(_ConfigurationManager))
                {
                    string ClientIP = Response.HttpContext.Connection.RemoteIpAddress.ToString();
                    if (ClientIP == "::1")
                    {
                        ClientIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();

                    }
                    repositorio.Operador_Insertar(new enOperador
                    {
                        ID_USUARIO = entidad.IdUsuario,
                        IP_CREACION = ClientIP,
                        USU_CREACION = entidad.UsuCreacion
                    }, ref auditoria);
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Log.Mensaje(CodigoLog);
                    }
                    else
                    {
                        if (!auditoria.Rechazo)
                            auditoria.Code = (int)HttpStatusCode.Created;
                        else
                            auditoria.Code = (int)HttpStatusCode.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Log.Guardar(auditoria.ErrorLog);
                auditoria.MensajeSalida = Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.Code, auditoria);
        }

        [HttpPut]
        [Route("estado/{id:int}")]
        public IActionResult Operador_Estado(int id, [FromBody] OperadorModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (OperadorRepositorio repositorio = new OperadorRepositorio(_ConfigurationManager))
                {
                    string ClientIP = Response.HttpContext.Connection.RemoteIpAddress.ToString();
                    if (ClientIP == "::1")
                    {
                        ClientIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                    }
                    repositorio.Operador_Estado(new enOperador
                    {
                        ID_USUARIO = entidad.IdUsuario,
                        FLG_ESTADO = entidad.FlgEstado,
                        IP_MODIFICACION = ClientIP,
                        USU_MODIFICACION = entidad.UsuModificacion
                    }, ref auditoria); ;
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
                string CodigoLog = Log.Guardar(auditoria.ErrorLog);
                auditoria.MensajeSalida = Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.Code, auditoria);
        }

    }
}
