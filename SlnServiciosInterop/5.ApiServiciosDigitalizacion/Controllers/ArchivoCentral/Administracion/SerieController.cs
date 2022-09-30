using System;
using System.Net;
using ApiServiciosDigitalizacion.Models.ArchivoCentral;
using ApiServiciosDigitalizacion.Models.ArchivoCentral.Administracion;
using ApiServiciosDigitalizacion.resource.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion.Vistas;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos; 

namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Administracion
{
    [EnableCors("AccesoCors")]
    [Route("api/archivo-central/serie")]
    public class SerieController : ControllerBase
    {

        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public SerieController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpPost]
        [Route("listar")]
        public IActionResult Serie_Listar([FromBody] SerieModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SerieRepositorio repositorio = new SerieRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Serie_Listar(new Vserie
                    {
                        ID_SECCION = entidad.IdSeccion,
                        COD_SERIE = entidad.DescCodSerie,
                        DES_SERIE = entidad.DescSerie,
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
        [Route("get-serie/{id}")]
        public IActionResult Serie_ListarUno(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SerieRepositorio repositorio = new SerieRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Serie_ListarUno(new Vserie
                    {
                        ID_SERIE = id
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
        public IActionResult Serie_Insertar([FromBody] SerieModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SerieRepositorio repositorio = new SerieRepositorio(_ConfigurationManager))
                {
                    repositorio.Serie_Insertar(new enSerie
                    {
                        ID_SECCION = (long)entidad.IdSeccion,
                        COD_SERIE = entidad.DescCodSerie,
                        DES_SERIE = entidad.DescSerie,
                        IP_CREACION = IPUser.ObtenerIP(),
                        USU_CREACION = entidad.UsuCreacion
                    }, ref auditoria);
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Log.Mensaje(CodigoLog);
                    }
                    else
                        auditoria.Code = (int)HttpStatusCode.Created;
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
        public IActionResult Serie_Actualizar(int id, [FromBody] SerieModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SerieRepositorio repositorio = new SerieRepositorio(_ConfigurationManager))
                {
                    repositorio.Serie_Actualizar(new enSerie
                    {
                        ID_SERIE = id,
                        ID_SECCION = (long)entidad.IdSeccion,
                        COD_SERIE = entidad.DescCodSerie,
                        DES_SERIE = entidad.DescSerie,
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
        public IActionResult Serie_Estado(int id, [FromBody] SerieModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SerieRepositorio repositorio = new SerieRepositorio(_ConfigurationManager))
                {
                    repositorio.Serie_Estado(new enSerie
                    {
                        ID_SERIE = entidad.IdSerie,
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
        [Route("eliminar/{id}")]
        public IActionResult Serie_Eliminar(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SerieRepositorio repositorio = new SerieRepositorio(_ConfigurationManager))
                {
                    repositorio.Serie_Eliminar(new enSerie
                    {
                        ID_SERIE = id
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
