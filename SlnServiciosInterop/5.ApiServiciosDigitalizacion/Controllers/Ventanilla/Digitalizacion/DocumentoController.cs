using System;
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
using EnServiciosDigitalizacion.Base;
using System.IO;
using Utilitarios.Excel;

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
                            item.NRO_LOTE,
                            item.NOMBRE_USUARIO,
                            null,
                            null,
                            item.STR_FEC_EXPEDIENTE,
                            //item.STR_FEC_CREACION,
                            item.DES_PERSONA,
                            item.DES_ASUNTO,
                            item.DES_CLASIF,
                            item.NRO_REPROCESADOS.ToString(),
                            null,
                            item.DES_TIP_DOC,
                            item.NUM_DOC,
                            item.NUM_FOLIOS.ToString(),
                            item.DES_OBS,
                            item.USU_CREACION,
                            item.STR_FEC_CREACION,
                            item.USU_MODIFICACION,
                            item.STR_FEC_MODIFICACION,
                            item.PESO_ADJ.ToString()

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
        [Route("documento-exportar")]
        public IActionResult Documento_Exportar([FromBody] GridTable grid)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                var @where = (Css_Paginacion.GetWhere(null, grid.rules));
                if (string.IsNullOrEmpty(@where))
                {
                    @where = "1=1";
                }
                using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                {
                    HashSet<enDocumento> lista = repositorio.Documento_Exportar(@where, ref auditoria);
                    if (auditoria.EjecucionProceso)
                    {
                        Titulo _Titulo = new Titulo
                        {
                            TITULO = "MINCETUR - Listado de Expedientes",
                            TITULO_CELDA = "F",
                            TITULO_INT = 3,
                            RUTA_LOGO = Directory.GetCurrentDirectory() + @"/assets/img/logo-mincetur.png",
                        };
                        string CODIGO_TEMPORAL = GenerarCodigo.GenerarCodigoTemporal() + ".xlsx";
                        string RUTA_TEMPORAL = Rutas.Ruta_Temporal();
                        string RUTA_ARCHIVO_TEMPORAL = string.Format("{0}{1}", RUTA_TEMPORAL, CODIGO_TEMPORAL);

                        List<Columnas> columnas = new List<Columnas>();
                        columnas.Add(new Columnas { ID_COLUMNA = "ID_DOCUMENTO", DESCRIPCION_COLUMNA = "Nro. Expediente", CELDA_INICIO = "A", CELDA_FIN = "A", INT_CELDAS = 1, AUTO_INCREMENTAR = false });
                        columnas.Add(new Columnas { ID_COLUMNA = "NOMBRE_USUARIO", DESCRIPCION_COLUMNA = "Digitalizador", CELDA_INICIO = "B", CELDA_FIN = "B", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "DESCRIPCION_ESTADO", DESCRIPCION_COLUMNA = "Estado", CELDA_INICIO = "C", CELDA_FIN = "C", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "DES_TIP_DOC", DESCRIPCION_COLUMNA = "Tipo", CELDA_INICIO = "D", CELDA_FIN = "D", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "DES_ASUNTO", DESCRIPCION_COLUMNA = "Asunto", CELDA_INICIO = "E", CELDA_FIN = "F", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "DES_OBS", DESCRIPCION_COLUMNA = "Observación", CELDA_INICIO = "G", CELDA_FIN = "H", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "NUM_FOLIOS", DESCRIPCION_COLUMNA = "Folios", CELDA_INICIO = "I", CELDA_FIN = "J", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "NUM_DOC", DESCRIPCION_COLUMNA = "Nro. Documento", CELDA_INICIO = "K", CELDA_FIN = "K", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "DES_CLASIF", DESCRIPCION_COLUMNA = "Clasificación", CELDA_INICIO = "L", CELDA_FIN = "L", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "DES_PERSONA", DESCRIPCION_COLUMNA = "Solicitante", CELDA_INICIO = "M", CELDA_FIN = "N", INT_CELDAS = 1 });

                        CreateExcelFile.CreateExcelDocument(lista.ToList(), RUTA_ARCHIVO_TEMPORAL, _Titulo, false, "Expedientes", columnas);
                        return StatusCode(auditoria.Code, CODIGO_TEMPORAL);
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
        [Route("proceso-paginado")]
        public IActionResult DocumentoProceso_Paginado([FromBody] GridTable grid)
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
                    IList<enDocumento_Proceso> lista = repositorio.DocumentoProceso_Paginado(grid.sidx, grid.sord, grid.rows, grid.page, @where, ref auditoria);
                    if (auditoria.EjecucionProceso)
                    {
                        var generic = Recursos.Paginacion.Css_Paginacion.BuscarPaginador(grid.page, grid.rows, (int)auditoria.Objeto, lista);
                        generic.Value.rows = generic.List.Select(item => new Recursos.Paginacion.Css_Row
                        {
                            id = item.ID_DOCUMENTO_PROCESO.ToString(),
                            cell = new string[] {
                            item.ID_DOCUMENTO_PROCESO.ToString(),
                            item.ID_DOCUMENTO.ToString(),
                            item.DESCRIPCION_ESTADO,
                            null,
                            item.NRO_LOTE,
                            item.NOMBRE_USUARIO,
                            item.ID_DOCUMENTO.ToString(),
                            null,
                            item.DES_CLASIF,
                            item.DES_TIP_DOC,
                            item.DES_ASUNTO,
                            item.HORA_INICIO,
                            item.HORA_FIN,
                            item.OBSERVACION,
                            item.USU_CREACION,
                            item.STR_FEC_CREACION
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
        [Route("adjuntos-insertar")]
        public IActionResult DocumentoAdjuntos_Insertar(AdjuntoModels entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                {
                    repositorio.DocumentoAdjuntos_Insertar(new enAdjuntos
                    {
                        ID_EXPEDIENTE = entidad.IdExpediente,
                        DES_NOM_ABR = entidad.NombreArchivo,
                        EXTENSION = entidad.Extension,
                        NUM_SIZE_ARCHIVO = entidad.PesoArchivo,
                        ID_DOC_CMS = entidad.IdArchivo,
                        FLG_LINK = entidad.FlgLink,
                        FLG_TIPO = entidad.FlgTipo,
                        USU_CREACION = entidad.UsuCreacion,
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

        [HttpPost]
        [Route("adjuntos-actualizar")]
        public IActionResult DocumentoAdjuntos_Actualizar(AdjuntoModels entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                {
                    repositorio.DocumentoAdjuntos_Actualizar(new enAdjuntos
                    {
                        ID_DOC_ADJ = entidad.IdocAdjunto,
                        NUM_SIZE_ARCHIVO = entidad.PesoArchivo,
                        EXTENSION = entidad.Extension,
                        USU_MODIFICACION = entidad.UsuCreacion,
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

        [HttpDelete]
        [Route("adjuntos-eliminar/{IdocAdjunto:long}")]
        public IActionResult DocumentoAdjuntos_Eliminar(long IdocAdjunto)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                {
                    repositorio.DocumentoAdjuntos_Eliminar(new enAdjuntos
                    {
                        ID_DOC_ADJ = IdocAdjunto,
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
