using System;
using System.Net;
using ApiServiciosMicroformas.Recursos;
using ApiServiciosMicroformas.resource.ArchivoCentral;
using EnServiciosMicroformas;
using EnServiciosMicroformas.ArchivoCentral;
using Microsoft.AspNetCore.Mvc;
using ApiServiciosMicroformas.Models.ArchivoCentral;
namespace ApiServiciosMicroformas.Controllers.ArchivoCentral
{
    [Route("api/archivo-central/seccion")]
    public class SeccionController : BaseApiController
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public SeccionController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpPost]
        [Route("listar")]
        public IActionResult Seccion_Listar(SeccionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
                {
                    auditoria.OBJETO = repositorio.Seccion_Listar(new enSeccion
                    {
                        DES_CORTA_SECCION = entidad.DescCortaSeccion,
                        FLG_ESTADO = entidad.FlgEstado
                    }, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ERROR_LOG);
                        auditoria.MENSAJE_SALIDA = Css_Log.Mensaje(CodigoLog);
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                auditoria.MENSAJE_SALIDA = ex.Message;
            }
            return StatusCode(auditoria.CODE, auditoria);
        }


        [HttpGet]
        [Route("get-seccion/{id}")]
        public IActionResult Seccion_ListarUno(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
                {
                    auditoria.OBJETO = repositorio.Seccion_ListarUno(new enSeccion
                    {
                        ID_SECCION = id
                    }, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ERROR_LOG);
                        auditoria.MENSAJE_SALIDA = Css_Log.Mensaje(CodigoLog);
                    }
                    else
                       if (auditoria.OBJETO == null)
                         auditoria.CODE = (int)HttpStatusCode.NotFound;
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Css_Log.Guardar(auditoria.ERROR_LOG);
                auditoria.MENSAJE_SALIDA = Css_Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.CODE, auditoria);
        }

        [HttpPost]
        [Route("insertar")]
        public IActionResult Seccion_Insertar(SeccionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
                {
                    repositorio.Seccion_Insertar(new enSeccion
                    {
                        DES_LARGA_SECCION = entidad.DescCortaSeccion,
                        DES_CORTA_SECCION = entidad.DescCortaSeccion,
                        USU_CREACION = entidad.UsuCreacion
                    }, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ERROR_LOG);
                        auditoria.MENSAJE_SALIDA = Css_Log.Mensaje(CodigoLog);
                    }
                    else
                        auditoria.CODE = (int)HttpStatusCode.Created;
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Css_Log.Guardar(auditoria.ERROR_LOG);
                auditoria.MENSAJE_SALIDA = Css_Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.CODE, auditoria);
        }


        [HttpPut]
        [Route("actualizar")]
        public IActionResult Seccion_Actualizar(SeccionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
                {
                    repositorio.Seccion_Actualizar(new enSeccion
                    {
                        ID_SECCION = entidad.IdSeccion,
                        DES_LARGA_SECCION = entidad.DescCortaSeccion,
                        DES_CORTA_SECCION = entidad.DescCortaSeccion,
                        USU_MODIFICACION = entidad.UsuModificacion
                    }, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ERROR_LOG);
                        auditoria.MENSAJE_SALIDA = Css_Log.Mensaje(CodigoLog);
                    }
                    else
                    {
                        if (!auditoria.RECHAZAR)
                            auditoria.CODE = (int)HttpStatusCode.NoContent;
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Css_Log.Guardar(auditoria.ERROR_LOG);
                auditoria.MENSAJE_SALIDA = Css_Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.CODE, auditoria);
        }

        [HttpPut]
        [Route("estado")]
        public IActionResult Seccion_Estado(SeccionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
                {
                    repositorio.Seccion_Estado(new enSeccion
                    {
                        ID_SECCION = entidad.IdSeccion,
                        FLG_ESTADO = entidad.FlgEstado,
                        USU_MODIFICACION = entidad.UsuModificacion
                    }, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ERROR_LOG);
                        auditoria.MENSAJE_SALIDA = Css_Log.Mensaje(CodigoLog);
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Css_Log.Guardar(auditoria.ERROR_LOG);
                auditoria.MENSAJE_SALIDA = Css_Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.CODE, auditoria);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult Seccion_Eliminar(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
                {
                    repositorio.Seccion_Eliminar(new enSeccion
                    {
                        ID_SECCION = id
                    }, ref auditoria);
                    if (!auditoria.EJECUCION_PROCEDIMIENTO)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ERROR_LOG);
                        auditoria.MENSAJE_SALIDA = Css_Log.Mensaje(CodigoLog);
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Css_Log.Guardar(auditoria.ERROR_LOG);
                auditoria.MENSAJE_SALIDA = Css_Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.CODE, auditoria);
        }


    }
}
