using System;
using EnServiciosDigitalizacion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos;
using ApiServiciosDigitalizacion.resource.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using System.Collections.Generic;
using System.Linq;
using ApiServiciosDigitalizacion.Models.ArchivoCentral.Digitalizacion;
using System.Net;

namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Digitalizacion
{
    [EnableCors("AccesoCors")]
    [Route("api/archivo-central/documento")]
    public class DocumentoController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public DocumentoController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpPost]
        [Route("listado-temporal-paginado")]
        public IActionResult Documento_TemporalListar([FromBody] Recursos.Paginacion.GridTable grid)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                grid.page = (grid.page == 0) ? 1 : grid.page;
                grid.rows = (grid.rows == 0) ? 100 : grid.rows;
                var @where = (Recursos.Paginacion.Css_Paginacion.GetWhere(grid.filters, grid.rules));
                if (!string.IsNullOrEmpty(@where))
                {
                    grid._search = true;
                    if (!string.IsNullOrEmpty(grid.searchString))
                    {
                        @where = @where + " and ";
                    }
                }
                else
                    @where = "1=1";

                using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                {
                    IList<enDocumentoTemporal> lista = repositorio.DocumentoTemporal_Paginado(grid.sidx, grid.sord, grid.rows, grid.page, @where, ref auditoria);
                    if (auditoria.EjecucionProceso)
                    {
                        var generic = Recursos.Paginacion.Css_Paginacion.BuscarPaginador(grid.page, grid.rows, (int)auditoria.Objeto, lista);

                        generic.Value.rows = generic.List.Select(item => new Recursos.Paginacion.Css_Row
                        {
                            id = item.ID_DOCUMENTO.ToString(),
                            cell = new string[] {
                            item.ID_DOCUMENTO.ToString(),
                            item.ID_CONTROL_CARGA.ToString(),
                            item.ID_FONDO,
                            item.ID_SECCION,
                            item.ID_SERIE,
                            item.DES_FONDO,
                            item.NOM_DOCUMENTO,
                            item.DES_LARGA_SECCION,
                            item.DES_SERIE,
                            item.DESCRIPCION,
                            item.ANIO,
                            item.FOLIOS,
                            item.OBSERVACION,
                            item.USU_CREACION,
                            item.STR_FEC_CREACION,
                            item.USU_MODIFICACION,
                            item.STR_FEC_MODIFICACION,
                      }
                        }).ToArray();
                        return StatusCode(auditoria.Code, generic.Value);
                    }
                    else
                        return StatusCode(auditoria.Code, auditoria);
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.ToString());
                return StatusCode(auditoria.Code, auditoria);
            }

        }

        [HttpPost]
        [Route("listado-paginado")]
        public IActionResult Documento_Paginado([FromBody] Recursos.Paginacion.GridTable grid)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                grid.page = (grid.page == 0) ? 1 : grid.page;
                grid.rows = (grid.rows == 0) ? 100 : grid.rows;
                var @where = (Recursos.Paginacion.Css_Paginacion.GetWhere(grid.filters, grid.rules));
                if (!string.IsNullOrEmpty(@where))
                {
                    grid._search = true;
                    if (!string.IsNullOrEmpty(grid.searchString))
                    {
                        @where = @where + " and ";
                    }
                }
                else
                    @where = "1=1";

                using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                {
                    IList<enDocumento> lista = repositorio.Documento_Paginado(grid.sidx, grid.sord, grid.rows, grid.page, @where, ref auditoria);
                    if (auditoria.EjecucionProceso)
                    {
                        var generic = Recursos.Paginacion.Css_Paginacion.BuscarPaginador(grid.page, grid.rows, (int)auditoria.Objeto, lista);

                        generic.Value.rows = generic.List.Select(item => new Recursos.Paginacion.Css_Row
                        {
                            id = item.ID_DOCUMENTO.ToString(),
                            cell = new string[] {
                            item.ID_DOCUMENTO.ToString(),
                            item.ID_DOCUMENTO_ASIGNADO.ToString(), 
                            item.ID_CONTROL_CARGA.ToString(),
                            item.ID_FONDO.ToString(),
                            item.ID_SECCION.ToString(),
                            item.ID_SERIE.ToString(),
                            item.ID_ESTADO_DOCUMENTO.ToString(),
                            item.DESCRIPCION_ESTADO, 
                            null,
                            null, 
                            item.NOMBRE_USUARIO, 
                            null,
                            null, 
                            item.DES_FONDO,
                            item.NOM_DOCUMENTO,
                            item.DES_LARGA_SECCION,
                            item.DES_SERIE,
                            item.DESCRIPCION,
                            item.ANIO.ToString(),
                            item.FOLIOS.ToString(),
                            item.OBSERVACION,
                            item.USU_CREACION,
                            item.STR_FEC_CREACION,
                            item.USU_MODIFICACION,
                            item.STR_FEC_MODIFICACION,
                      }
                        }).ToArray();
                        return StatusCode(auditoria.Code, generic.Value);
                    }
                    else
                        return StatusCode(auditoria.Code, auditoria);
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.ToString());
                return StatusCode(auditoria.Code, auditoria);
            }

        }

        [HttpPost]
        [Route("grabar-documentos")]
        public IActionResult Documento_Grabar([FromBody] DocumentoModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                {
                    repositorio.Documento_Grabar(new enDocumento
                    {
                        ID_CONTROL_CARGA = entidad.IdControlCarga,
                        USU_MODIFICACION = entidad.UsuModificacion,
                        IP_MODIFICACION = entidad.IpModificacion,
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
        [Route("grabar-asignacion")]
        public IActionResult Documento_AsignacionInsertar([FromBody] DocumentoModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                if (entidad.ListaIdsDocumento.Count > 0)
                {
                    using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                    {
                        repositorio.Documento_AsignacionInsertar(new enDocumento
                        {
                            ListaDocumento = entidad.ListaIdsDocumento.Select(x => new enDocumento() 
                            { 
                                ID_DOCUMENTO = x.IdDocumento, 
                                ID_USUARIO = x.IdUsuario
                            }).ToList(),
                            USU_CREACION = entidad.UsuModificacion,
                            IP_CREACION = entidad.IpCreacion,
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
                else {
                    auditoria.Rechazar("Ingrese al menos un documento a la lista."); 
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
