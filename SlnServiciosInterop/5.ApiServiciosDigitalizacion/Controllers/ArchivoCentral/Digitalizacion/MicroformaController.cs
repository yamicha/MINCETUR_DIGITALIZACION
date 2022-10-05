using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiServiciosDigitalizacion.resource.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion.Enums;
using EnServiciosDigitalizacion.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos;

namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Digitalizacion
{
    [EnableCors("AccesoCors")]
    [Route("api/archivo-central/microforma")]
    public class MicroformaController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public MicroformaController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }


        [HttpPost]
        [Route("listar")]
        public IActionResult Microforma_Listar([FromBody] MicroModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Microforma_Listar(new enMicroforma
                    {
                        ID_ESTADO = entidad.IdEstado
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
        [Route("insertar")]
        public IActionResult Microforma_Insertar([FromBody] MicroModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    if (entidad.ListaIdsLotes.Count > 0)
                    {
                        repositorio.Microforma_Insertar(entidad, ref auditoria);
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
        [Route("editar")]
        public IActionResult Microforma_Editar([FromBody] MicroModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                        repositorio.Microforma_Reprocesar(entidad, ref auditoria);
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
        [Route("lote-microforma")]      
        public IActionResult Microforma_ListarLotes([FromBody] parameters param)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Microforma_LotesListar(param.id, ref auditoria);
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
        [Route("get-microforma/{IdMicroforma:long}")]
        public IActionResult Microforma_ListarUno(long IdMicroforma)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Microforma_ListarUno(IdMicroforma, ref auditoria);
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
        [Route("evaluar")]
        public IActionResult Microforma_Evaluar([FromBody] MicroEvaluarModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                if (entidad.FlgConforme == 1)
                {
                    entidad.IdEstado = (int)EstadoMicro.Conforme;
                }
                else
                    entidad.IdEstado = (int)EstadoMicro.Observado;

                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    repositorio.Microforma_Evaluar(entidad, ref auditoria);
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
