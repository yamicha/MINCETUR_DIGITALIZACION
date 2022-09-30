using System;
using EnServiciosDigitalizacion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos;
using ApiServiciosDigitalizacion.resource.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion.Enums;
using System.Collections.Generic;
using System.Linq;
using ApiServiciosDigitalizacion.Models.ArchivoCentral.Digitalizacion;
using System.Net;
using EnServiciosDigitalizacion.Models;

namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Digitalizacion
{
    [EnableCors("AccesoCors")]
    [Route("api/archivo-central/digitalizacion")]
    public class DigitalizacionController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public DigitalizacionController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpGet]
        [Route("listar-lotes/{id:int}")]
        public IActionResult Lote_Listar(long id)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DigitalizacionRepositorio repositorio = new DigitalizacionRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Lote_Listar(new enLote
                    {
                        ID_LOTE = id
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
        [Route("digitalizar-documento")]
        public IActionResult Documento_digitalizar([FromBody] DocumentoModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DigitalizacionRepositorio repositorio = new DigitalizacionRepositorio(_ConfigurationManager))
                {
                    repositorio.Documento_Digitalizar(new enDocumento_Asignado
                    {
                        ID_DOCUMENTO = entidad.IdDocumento,
                        ID_DOCUMENTO_ASIGNADO = entidad.IdDocumentoAsignado,
                        ID_LASERFICHE = entidad.IdLaserfiche,
                        HORA_INICIO = entidad.HoraInicio,
                        HORA_FIN = entidad.HoraFIn,
                        USU_CREACION = entidad.UsuCreacion,
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

        [HttpPost]
        [Route("reprocesar-documento")]
        public IActionResult Documento_Reprocesar([FromBody] DocumentoModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DigitalizacionRepositorio repositorio = new DigitalizacionRepositorio(_ConfigurationManager))
                {
                    repositorio.Documento_Reprocesar(new enDocumento_Asignado
                    {
                        ID_DOCUMENTO = entidad.IdDocumento,
                        ID_DOCUMENTO_ASIGNADO = entidad.IdDocumentoAsignado,
                        ID_LASERFICHE = entidad.IdLaserfiche,
                        HORA_INICIO = entidad.HoraInicio,
                        HORA_FIN = entidad.HoraFIn,
                        USU_CREACION = entidad.UsuCreacion,
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

        [HttpGet]
        [Route("listar-documento-proceso/{idDocumento:int}")]
        public IActionResult Documento_Proceso_Listar(long idDocumento)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DigitalizacionRepositorio repositorio = new DigitalizacionRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Documento_Proceso_Listar(new enDocumento_Proceso
                    {
                        ID_DOCUMENTO = idDocumento
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
        [Route("digitalizado-validar")]
        public IActionResult Documento_Digitalizado_Validar([FromBody] DocumentoValidarModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                if (entidad.FlgConforme == 1)
                {
                    entidad.IdEstadoDocumento = (long)EstadoDocumento.CalidadConforme; 
                }
                else
                    entidad.IdEstadoDocumento = (long)EstadoDocumento.CalidadNoCondorme;

                using (DigitalizacionRepositorio repositorio = new DigitalizacionRepositorio(_ConfigurationManager))
                {
                    repositorio.Documento_Digitalizado_Validar(entidad, ref auditoria);
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
        
    }
}
