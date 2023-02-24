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
    [Route("api/archivo-central/observacion")]
    public class ObservacionController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public ObservacionController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpPost]
        [Route("listar")]
        public IActionResult Observacion_Listar([FromBody] ObservacionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (ObservacionRepositorio repositorio = new ObservacionRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Observacion_Listar(new enObservacion
                    {
                        DESC_OBSERVACION = entidad.DescObservacion,
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
        [Route("get-observacion/{id}")]
        public IActionResult Observacion_ListarUno(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (ObservacionRepositorio repositorio = new ObservacionRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Observacion_ListarUno(new enObservacion
                    {
                        ID_OBSERVACION = id
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
        public IActionResult Observacion_Insertar([FromBody] ObservacionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (ObservacionRepositorio repositorio = new ObservacionRepositorio(_ConfigurationManager))
                {
                    string ClientIP = Response.HttpContext.Connection.RemoteIpAddress.ToString();
                    if (ClientIP == "::1")
                    {
                        ClientIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                    }
                    repositorio.Observacion_Insertar(new enObservacion
                    {
                        DESC_OBSERVACION = entidad.DescObservacion,
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
        public IActionResult Observacion_Actualizar(int id, [FromBody] ObservacionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (ObservacionRepositorio repositorio = new ObservacionRepositorio(_ConfigurationManager))
                {
                    string ClientIP = Response.HttpContext.Connection.RemoteIpAddress.ToString();
                    if (ClientIP == "::1")
                    {
                        ClientIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                    }
                    repositorio.Observacion_Actualizar(new enObservacion
                    {
                        ID_OBSERVACION = id,
                        DESC_OBSERVACION = entidad.DescObservacion,
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
        public IActionResult Observacion_Estado(int id, [FromBody] ObservacionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (ObservacionRepositorio repositorio = new ObservacionRepositorio(_ConfigurationManager))
                {
                    string ClientIP = Response.HttpContext.Connection.RemoteIpAddress.ToString();
                    if (ClientIP == "::1")
                    {
                        ClientIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                    }
                    repositorio.Observacion_Estado(new enObservacion
                    {
                        ID_OBSERVACION = entidad.IdObservacion,
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
        public IActionResult Observacion_Eliminar(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (ObservacionRepositorio repositorio = new ObservacionRepositorio(_ConfigurationManager))
                {
                    repositorio.Observacion_Eliminar(new enObservacion
                    {
                        ID_OBSERVACION = id
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
