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
    [Route("api/archivo-central/fondo")]
    [ApiController]
    public class FondoController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public FondoController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpPost]
        [Route("listar")]
        public IActionResult Fondo_Listar([FromBody] FondoModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (FondoRepositorio repositorio = new FondoRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Fondo_Listar(new enFondo
                    {
                        DESC_FONDO = entidad.DescFondo,
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
        [Route("get-fondo/{id:int}")]
        public IActionResult Fondo_ListarUno(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (FondoRepositorio repositorio = new FondoRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Fondo_ListarUno(new enFondo
                    {
                        ID_FONDO = id
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
        public IActionResult Fondo_Insertar([FromBody] FondoModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (FondoRepositorio repositorio = new FondoRepositorio(_ConfigurationManager))
                {
                    repositorio.Fondo_Insertar(new enFondo
                    {
                        DESC_FONDO = entidad.DescFondo,
                        IP_CREACION = IPUser.ObtenerIP(),
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
        public IActionResult Fondo_Actualizar(int id, [FromBody] FondoModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (FondoRepositorio repositorio = new FondoRepositorio(_ConfigurationManager))
                {
                    repositorio.Fondo_Actualizar(new enFondo
                    {
                        ID_FONDO = id,
                        DESC_FONDO = entidad.DescFondo,
                        USU_MODIFICACION = entidad.UsuModificacion,
                        IP_MODIFICACION = IPUser.ObtenerIP()
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
        public IActionResult Fondo_Estado(int id, [FromBody] FondoModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (FondoRepositorio repositorio = new FondoRepositorio(_ConfigurationManager))
                {
                    repositorio.Fondo_Estado(new enFondo
                    {
                        ID_FONDO = entidad.IdFondo,
                        FLG_ESTADO = entidad.FlgEstado,
                        IP_MODIFICACION = IPUser.ObtenerIP(),
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
        [Route("eliminar/{id:int}")]
        public IActionResult Fondo_Eliminar(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (FondoRepositorio repositorio = new FondoRepositorio(_ConfigurationManager))
                {
                    repositorio.Fondo_Eliminar(new enFondo
                    {
                        ID_FONDO = id
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
