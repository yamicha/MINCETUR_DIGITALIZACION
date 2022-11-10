﻿using System;
using EnServiciosDigitalizacion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos;
using ApiServiciosDigitalizacion.resource.Ventanilla.Digitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion; 
using System.Collections.Generic;
using System.Linq;
using ApiServiciosDigitalizacion.Recursos.Paginacion;
using EnServiciosDigitalizacion.Models.Ventanilla;
using System.Net;

namespace ApiServiciosDigitalizacion.Controllers.Ventanilla.Digitalizacion
{

    [EnableCors("AccesoCors")]
    [Route("api/ventanilla/documento")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {

        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public DocumentoController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }
        [HttpPost]
        [Route("listar-paginado")]
        public IActionResult Documento_Ventanilla_Pendiente([FromBody] GridTable grid)
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
                            item.ID_ESTADO_DOCUMENTO.ToString(),
                            item.DESCRIPCION_ESTADO,
                            null,
                            null, 
                            item.NOMBRE_USUARIO,
                            item.NRO_REPROCESADOS.ToString(),
                            null,
                            null,
                            item.USU_CREACION,
                            item.STR_FEC_CREACION,
                            item.USU_MODIFICACION,
                            item.STR_FEC_MODIFICACION,
                            item.PESO_ADJ.ToString(),

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


        //[HttpPost]
        //[Route("documento-exportar")]
        //public IActionResult Documento_Exportar([FromBody] GridTable grid)
        //{
        //    enAuditoria auditoria = new enAuditoria();
        //    try
        //    {
        //        var @where = (Css_Paginacion.GetWhere(null, grid.rules));
        //        if (string.IsNullOrEmpty(@where))
        //        {
        //            @where = "1=1";
        //        }
        //        using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
        //        {
        //            HashSet<enDocumento> lista = repositorio.Documento_Exportar(@where, ref auditoria);
        //            if (auditoria.EjecucionProceso)
        //            {
        //                Titulo _Titulo = new Titulo
        //                {
        //                    TITULO = "MINCETUR - Listado de Documentos",
        //                    TITULO_CELDA = "F",
        //                    TITULO_INT = 3,
        //                    RUTA_LOGO = Directory.GetCurrentDirectory() + @"/assets/img/logo-mincetur.png",
        //                };
        //                string CODIGO_TEMPORAL = GenerarCodigo.GenerarCodigoTemporal() + ".xlsx";
        //                string RUTA_TEMPORAL = Rutas.Ruta_Temporal();
        //                string RUTA_ARCHIVO_TEMPORAL = string.Format("{0}{1}", RUTA_TEMPORAL, CODIGO_TEMPORAL);

        //                List<Columnas> columnas = new List<Columnas>();
        //                columnas.Add(new Columnas { ID_COLUMNA = "ID_DOCUMENTO", DESCRIPCION_COLUMNA = "N°", CELDA_INICIO = "A", CELDA_FIN = "A", INT_CELDAS = 1, AUTO_INCREMENTAR = true });
        //                columnas.Add(new Columnas { ID_COLUMNA = "NOMBRE_USUARIO", DESCRIPCION_COLUMNA = "Digitalizador", CELDA_INICIO = "B", CELDA_FIN = "B", INT_CELDAS = 1 });
        //                columnas.Add(new Columnas { ID_COLUMNA = "DESCRIPCION_ESTADO", DESCRIPCION_COLUMNA = "Estado", CELDA_INICIO = "C", CELDA_FIN = "C", INT_CELDAS = 1 });
        //                columnas.Add(new Columnas { ID_COLUMNA = "NOM_DOCUMENTO", DESCRIPCION_COLUMNA = "Nombre Documento", CELDA_INICIO = "D", CELDA_FIN = "E", INT_CELDAS = 1 });
        //                columnas.Add(new Columnas { ID_COLUMNA = "DES_FONDO", DESCRIPCION_COLUMNA = "Fondo", CELDA_INICIO = "F", CELDA_FIN = "F", INT_CELDAS = 1 });
        //                columnas.Add(new Columnas { ID_COLUMNA = "DES_LARGA_SECCION", DESCRIPCION_COLUMNA = "Sección", CELDA_INICIO = "G", CELDA_FIN = "G", INT_CELDAS = 1 });
        //                columnas.Add(new Columnas { ID_COLUMNA = "DES_SERIE", DESCRIPCION_COLUMNA = "Serie", CELDA_INICIO = "H", CELDA_FIN = "H", INT_CELDAS = 1 });
        //                columnas.Add(new Columnas { ID_COLUMNA = "DESCRIPCION", DESCRIPCION_COLUMNA = "Descripción", CELDA_INICIO = "I", CELDA_FIN = "J", INT_CELDAS = 1 });
        //                columnas.Add(new Columnas { ID_COLUMNA = "ANIO", DESCRIPCION_COLUMNA = "Año", CELDA_INICIO = "K", CELDA_FIN = "K", INT_CELDAS = 1 });
        //                columnas.Add(new Columnas { ID_COLUMNA = "FOLIOS", DESCRIPCION_COLUMNA = "Folios", CELDA_INICIO = "L", CELDA_FIN = "L", INT_CELDAS = 1 });
        //                columnas.Add(new Columnas { ID_COLUMNA = "OBSERVACION", DESCRIPCION_COLUMNA = "Observación", CELDA_INICIO = "M", CELDA_FIN = "N", INT_CELDAS = 1 });

        //                CreateExcelFile.CreateExcelDocument(lista.ToList(), RUTA_ARCHIVO_TEMPORAL, _Titulo, false, "Documentos", columnas);
        //                return StatusCode(auditoria.Code, CODIGO_TEMPORAL);
        //            }
        //            else
        //                return StatusCode(auditoria.Code, auditoria);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Guardar(ex.ToString());
        //        return StatusCode(auditoria.Code, auditoria);
        //    }

        //}

        [HttpGet]
        [Route("get-documento/{idDocumento}")]
        public IActionResult Documento_ListarUno(int idDocumento)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Documento_ListarUno(new enDocumento
                    {
                        ID_DOCUMENTO = idDocumento
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

        [HttpGet]
        [Route("get-adjuntos/{idDocumento}")]
        public IActionResult DocumentoAdjuntos_Listar(int idDocumento)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.DocumentoAdjuntos_Listar(new enAdjuntos
                    {
                        ID_EXPE = idDocumento
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
                            USU_CREACION = entidad.UsuCreacion,
                            IP_CREACION = entidad.IpCreacion,
                            FLG_DIGITALIZAR = entidad.FlgDigitalizar 
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
                else
                {
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

        [HttpPost]
        [Route("actualizar-asignacion")]
        public IActionResult Documento_AsignacionActualizar([FromBody] DocumentoModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                if (entidad.ListaIdsDocumento.Count > 0)
                {
                    using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                    {
                        repositorio.Documento_AsignacionActualizar(new enDocumento
                        {
                            ListaDocumento = entidad.ListaIdsDocumento.Select(x => new enDocumento()
                            {
                                ID_DOCUMENTO_ASIGNADO = x.IdDocumentoAsignado,
                                ID_DOCUMENTO = x.IdDocumento,
                                ID_USUARIO = x.IdUsuario
                            }).ToList(),
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
                else
                {
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

        [HttpGet]
        [Route("listado-obs-documento/{idDocumento}")]
        public IActionResult DocumentoObservado_Listar(int idDocumento)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.DocumentoObservado_Listar(new enDocumento_Obs
                    {
                        ID_DOCUMENTO = idDocumento
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
    }
}
