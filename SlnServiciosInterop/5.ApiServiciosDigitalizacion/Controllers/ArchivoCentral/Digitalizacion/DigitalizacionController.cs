using System;
using System.Linq;
using System.Net;
using ApiServiciosDigitalizacion.Models.ArchivoCentral.Digitalizacion;
using ApiServiciosDigitalizacion.resource.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion.Enums;
using EnServiciosDigitalizacion.Models.ArchivoCentral;
using EnServiciosDigitalizacion.Models; 
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos;

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

        [HttpPost]
        [Route("listar-lotes")]
        public IActionResult Lote_Listar([FromBody] LotesModels entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DigitalizacionRepositorio repositorio = new DigitalizacionRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Lote_Listar(new enLote
                    {
                        FLG_DEVOLUCION = entidad.flgDevuelto,
                        FLG_MICROFORMA = entidad.flgMicroforma
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
        [Route("digitalizado-calidad-validar")]
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
                    entidad.IdEstadoDocumento = (long)EstadoDocumento.CalidadObservado;

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

        [HttpPost]
        [Route("digitalizado-fedatario-validar")]
        public IActionResult Documento_Digitalizado_Fedatario([FromBody] DocumentoValidarModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DigitalizacionRepositorio repositorio = new DigitalizacionRepositorio(_ConfigurationManager))
                {
                    if (entidad.FlgConforme == 1)
                        entidad.IdEstadoDocumento = (long)EstadoDocumento.FedatarioConforme;
                    else
                        entidad.IdEstadoDocumento = (long)EstadoDocumento.FedatarObservado;
                    repositorio.Documento_Fedatario_Validar(entidad, ref auditoria);
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
        [Route("fedatario-validar-masivo")]
        public IActionResult Documento_Fedatario_validar_masivo([FromBody] DocumentoValidarModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DigitalizacionRepositorio repositorio = new DigitalizacionRepositorio(_ConfigurationManager))
                {

                    if (entidad.LisIdDocumento.Count() > 0)
                    {
                        foreach (DocumentoValidarModel item in entidad.LisIdDocumento)
                        {
                            item.IdEstadoDocumento = (long)EstadoDocumento.FedatarioConforme;
                            //item.FlgConforme = 1; 
                            repositorio.Documento_Fedatario_Validar(item, ref auditoria);
                            if (auditoria.Rechazo)
                                break; 
                        }
                    }
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
        [Route("devolver-documentos")]
        public IActionResult Documento_DevolverDocumentos([FromBody] DevolucionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DigitalizacionRepositorio repositorio = new DigitalizacionRepositorio(_ConfigurationManager))
                {
                    if (entidad.ListaIdsLotes.Count > 0)
                    {
                        entidad.FecDevolucion = DateTime.Now;
                        repositorio.Documento_Devolver(entidad, ref auditoria);
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
                    else
                    {
                        auditoria.Rechazar("Sin lotes para procesar.");
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
        [Route("documento-validar-lote")]
        public IActionResult Documento_ValidarFinalizados([FromBody] DevolucionModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                bool valido = true;
                using (DigitalizacionRepositorio repositorio = new DigitalizacionRepositorio(_ConfigurationManager))
                {
                    if (entidad.ListaIdsLotes.Count > 0)
                    {
                        foreach (DevolucionModel itemx in entidad.ListaIdsLotes)
                        {
                            repositorio.Documento_LoteValidar(itemx, ref auditoria);
                            if (auditoria.Rechazo)
                            {
                                valido = false;
                                break;
                            }
                        }
                        auditoria.Objeto = valido;
                    }
                    else
                    {
                        auditoria.Rechazar("Sin lotes para procesar.");
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
