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
    [Route("api/archivo-central/area")]
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
                        //SIGLA = entidad.Sigla,
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
        [Route("get-area/{id:int}")]
        public IActionResult Area_ListarUno(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (AreaRepositorio repositorio = new AreaRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Area_ListarUno(new enArea
                    {
                        ID_AREA = id
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
        public IActionResult Area_Insertar([FromBody] AreaModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (AreaRepositorio repositorio = new AreaRepositorio(_ConfigurationManager))
                {
                    repositorio.Area_Insertar(new enArea
                    {
                        DES_AREA = entidad.DescArea,
                        SIGLA = entidad.Sigla,
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
        public IActionResult Area_Actualizar(int id, [FromBody] AreaModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (AreaRepositorio repositorio = new AreaRepositorio(_ConfigurationManager))
                {
                    repositorio.Area_Actualizar(new enArea
                    {
                        ID_AREA = id,
                        DES_AREA = entidad.DescArea,
                        SIGLA = entidad.Sigla,
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
        public IActionResult Area_Estado(int id, [FromBody] AreaModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (AreaRepositorio repositorio = new AreaRepositorio(_ConfigurationManager))
                {
                    repositorio.Area_Estado(new enArea
                    {
                        ID_AREA = entidad.IdArea,
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

    }
}
