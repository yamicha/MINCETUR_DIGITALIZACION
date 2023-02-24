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
    [Route("api/archivo-central/soporte")]
    public class SoporteController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public SoporteController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpPost]
        [Route("listar")]
        public IActionResult Soporte_Listar([FromBody] SoporteModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SoporteRepositorio repositorio = new SoporteRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Soporte_Listar(new enSoporte
                    {
                        DESC_SOPORTE = entidad.DescSoporte,
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


        [HttpGet]
        [Route("get-soporte/{id}")]
        public IActionResult Soporte_ListarUno(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SoporteRepositorio repositorio = new SoporteRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Soporte_ListarUno(new enSoporte
                    {
                        ID_SOPORTE = id
                    }, ref auditoria);
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Log.Mensaje(CodigoLog);
                    }
                    else
                       if (auditoria.Objeto == null)
                        auditoria.Code = (int)HttpStatusCode.NotFound;
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

        [HttpPost]
        [Route("insertar")]
        public IActionResult Soporte_Insertar([FromBody] SoporteModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SoporteRepositorio repositorio = new SoporteRepositorio(_ConfigurationManager))
                {
                    string ClientIP = Response.HttpContext.Connection.RemoteIpAddress.ToString();
                    if (ClientIP == "::1")
                    {
                        ClientIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                    }
                    repositorio.Soporte_Insertar(new enSoporte
                    {
                        DESC_SOPORTE = entidad.DescSoporte,
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
        [Route("actualizar/{id:int}")]
        public IActionResult Soporte_Actualizar(int id, [FromBody] SoporteModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SoporteRepositorio repositorio = new SoporteRepositorio(_ConfigurationManager))
                {
                    string ClientIP = Response.HttpContext.Connection.RemoteIpAddress.ToString();
                    if (ClientIP == "::1")
                    {
                        ClientIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                    }
                    repositorio.Soporte_Actualizar(new enSoporte
                    {
                        ID_SOPORTE = id,
                        DESC_SOPORTE = entidad.DescSoporte,
                        USU_MODIFICACION = entidad.UsuModificacion,
                        IP_MODIFICACION = ClientIP
                    }, ref auditoria);
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Log.Mensaje(CodigoLog);
                    }
                    else
                    {
                        if (auditoria.Rechazo)
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
        public IActionResult Soporte_Estado(int id, [FromBody] SoporteModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SoporteRepositorio repositorio = new SoporteRepositorio(_ConfigurationManager))
                {
                    string ClientIP = Response.HttpContext.Connection.RemoteIpAddress.ToString();
                    if (ClientIP == "::1")
                    {
                        ClientIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                    }
                    repositorio.Soporte_Estado(new enSoporte
                    {
                        ID_SOPORTE = entidad.IdSoporte,
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

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult Soporte_Eliminar(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SoporteRepositorio repositorio = new SoporteRepositorio(_ConfigurationManager))
                {
                    repositorio.Soporte_Eliminar(new enSoporte
                    {
                        ID_SOPORTE = id
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
                string CodigoLog = Log.Guardar(auditoria.ErrorLog);
                auditoria.MensajeSalida = Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.Code, auditoria);
        }

    }
}
