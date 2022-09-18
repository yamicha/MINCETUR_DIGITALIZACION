using System;
using System.Net;
using ApiServiciosDigitalizacion.Recursos;
using ApiServiciosDigitalizacion.resource.ArchivoCentral.Administracion; 
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion; 
using Microsoft.AspNetCore.Mvc;
using ApiServiciosDigitalizacion.Models.ArchivoCentral;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Administracion
{
    [EnableCors("AccesoCors")]
    [Route("api/archivo-central/seccion")]
    public class SeccionController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public SeccionController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpPost]
        [Route("listar")]
        public IActionResult Seccion_Listar([FromBody] SeccionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Seccion_Listar(new enSeccion
                    {
                        DES_CORTA_SECCION = entidad.DescCortaSeccion,
                        FLG_ESTADO = entidad.FlgEstado
                    }, ref auditoria);
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
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
        public IActionResult Seccion_ListarUno(int id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Seccion_ListarUno(new enSeccion
                    {
                        ID_SECCION = id
                    }, ref auditoria);
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
                    }
                    else
                       if (auditoria.Objeto == null)
                         auditoria.Code = (int)HttpStatusCode.NotFound;
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Css_Log.Guardar(auditoria.ErrorLog);
                auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.Code, auditoria);
        }

        [HttpPost]
        [Route("insertar")]
        public IActionResult Seccion_Insertar([FromBody] SeccionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
                {
                    repositorio.Seccion_Insertar(new enSeccion
                    {
                        DES_LARGA_SECCION = entidad.DescLargaSeccion,
                        DES_CORTA_SECCION = entidad.DescCortaSeccion,
                        IP_CREACION = Css_IP.ObtenerIP(),
                        USU_CREACION = entidad.UsuCreacion
                    }, ref auditoria);
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
                    }
                    else
                        auditoria.Code = (int)HttpStatusCode.Created;
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Css_Log.Guardar(auditoria.ErrorLog);
                auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.Code, auditoria);
        }


        [HttpPut]
        [Route("actualizar/{id:int}")]
        public IActionResult Seccion_Actualizar(int id, [FromBody]SeccionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (SeccionRepositorio repositorio = new SeccionRepositorio(_ConfigurationManager))
                {
                    repositorio.Seccion_Actualizar(new enSeccion
                    {
                        ID_SECCION = id,
                        DES_LARGA_SECCION = entidad.DescCortaSeccion,
                        DES_CORTA_SECCION = entidad.DescCortaSeccion,
                        USU_MODIFICACION = entidad.UsuModificacion
                    }, ref auditoria);
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
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
                string CodigoLog = Css_Log.Guardar(auditoria.ErrorLog);
                auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.Code, auditoria);
        }

        [HttpPut]
        [Route("estado/{id:int}")]
        public IActionResult Seccion_Estado(int id, [FromBody]SeccionModel entidad)
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
                        IP_MODIFICACION = Css_IP.ObtenerIP(),
                        USU_MODIFICACION = entidad.UsuModificacion
                    }, ref auditoria); ;
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Css_Log.Guardar(auditoria.ErrorLog);
                auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.Code, auditoria);
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
                    if (!auditoria.EjecucionProceso)
                    {
                        string CodigoLog = Css_Log.Guardar(auditoria.ErrorLog);
                        auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Css_Log.Guardar(auditoria.ErrorLog);
                auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.Code, auditoria);
        }


    }
}
