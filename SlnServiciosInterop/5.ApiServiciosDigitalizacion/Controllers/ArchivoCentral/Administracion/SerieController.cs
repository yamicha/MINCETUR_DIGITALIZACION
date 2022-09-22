using System;
using System.Net;
using ApiServiciosDigitalizacion.Models.ArchivoCentral;
using ApiServiciosDigitalizacion.resource.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos; 

namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Administracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {

        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public SerieController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpPost]
        [Route("listar")]
        public IActionResult Serie_Listar([FromBody] SeccionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SerieRepositorio repositorio = new SerieRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Serie_Listar(new enSerie
                    {
                        //DES_CORTA_SECCION = entidad.DescCortaSeccion,
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
        [Route("get-seccion/{id}")]
        public IActionResult Serie_ListarUno(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SerieRepositorio repositorio = new SerieRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Serie_ListarUno(new enSerie
                    {
                        ID_SECCION = id
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
        public IActionResult Serie_Insertar([FromBody] SeccionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SerieRepositorio repositorio = new SerieRepositorio(_ConfigurationManager))
                {
                    repositorio.Serie_Insertar(new enSerie
                    {
                        ID_SECCION = entidad.IdSeccion,
                        //DES_SERIE = entidad.de,
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
        public IActionResult Serie_Actualizar(int id, [FromBody] SeccionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SerieRepositorio repositorio = new SerieRepositorio(_ConfigurationManager))
                {
                    repositorio.Serie_Actualizar(new enSerie
                    {
                        ID_SECCION = id,
                        //DES_LARGA_SECCION = entidad.DescCortaSeccion,
                        //DES_CORTA_SECCION = entidad.DescCortaSeccion,
                        USU_MODIFICACION = entidad.UsuModificacion
                    }, ref auditoria);
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Log.Mensaje(CodigoLog);
                    }
                    else
                    {
                        if (auditoria.Rechazo)
                            auditoria.Code = (int)HttpStatusCode.NoContent;
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
        public IActionResult Serie_Estado(int id, [FromBody] SeccionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SerieRepositorio repositorio = new SerieRepositorio(_ConfigurationManager))
                {
                    repositorio.Serie_Estado(new enSerie
                    {
                        ID_SECCION = entidad.IdSeccion,
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
                        ID_SECCION = id
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
