using System;
using EnServiciosDigitalizacion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos;
using ApiServiciosDigitalizacion.resource.Ventanilla.Consulta;
using EnServiciosDigitalizacion.Ventanilla.Consulta;
using System.Collections.Generic;
using System.Linq;
//using ApiServiciosDigitalizacion.Models.Ventanilla.Digitalizacion;
using System.Net;
using ApiServiciosDigitalizacion.Recursos.Paginacion;
using EnServiciosDigitalizacion.Base;
using System.IO;
using Utilitarios.Excel;

namespace ApiServiciosDigitalizacion.Controllers.Ventanilla.Consulta
{
    [EnableCors("AccesoCors")]
    [Route("api/Ventanilla/DocVentanilla")]
    [ApiController]
    public class Vent_DocumentoController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public Vent_DocumentoController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }
        [HttpPost]
        [Route("listado-doc-ventanilla-paginado")]
        public IActionResult Documento_Ventanilla([FromBody] GridTable grid)
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

                using (ConsultaRepositorio repositorio = new ConsultaRepositorio(_ConfigurationManager))
                {
                    IList<enDocumentoVen> lista = repositorio.Documento_Ventanilla(grid.sidx, grid.sord, grid.rows, grid.page, @where, ref auditoria);
                    if (auditoria.EjecucionProceso)
                    {
                        var generic = Recursos.Paginacion.Css_Paginacion.BuscarPaginador(grid.page, grid.rows, (int)auditoria.Objeto, lista);

                        generic.Value.rows = generic.List.Select(item => new Recursos.Paginacion.Css_Row
                        {
                            id = item.ID_EXPE.ToString(),
                            cell = new string[] {
                            item.ID_EXPE.ToString(),
                            item.FEC_EXPE_STR.ToString(),
                            item.DES_PERSONA,
                            item.DES_ASUNTO,
                            item.DES_CLASIF.ToString(),
                            item.DESCRIPCION_ESTADO
                         
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
                using (ConsultaRepositorio repositorio = new ConsultaRepositorio(_ConfigurationManager))
                {
                    HashSet<enDocumentoVen> lista = repositorio.Documento_Exportar(@where, ref auditoria);
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
                        columnas.Add(new Columnas { ID_COLUMNA = "ID_EXPE", DESCRIPCION_COLUMNA = "Nro. Expediente", CELDA_INICIO = "A", CELDA_FIN = "A", INT_CELDAS = 1, AUTO_INCREMENTAR = false });
                        columnas.Add(new Columnas { ID_COLUMNA = "FEC_EXPE_STR", DESCRIPCION_COLUMNA = "Fec. Reg. Expediente", CELDA_INICIO = "B", CELDA_FIN = "B", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "DES_PERSONA", DESCRIPCION_COLUMNA = "Solicitante", CELDA_INICIO = "C", CELDA_FIN = "C", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "DES_ASUNTO", DESCRIPCION_COLUMNA = "Asunto", CELDA_INICIO = "D", CELDA_FIN = "D", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "DES_CLASIF", DESCRIPCION_COLUMNA = "Clasificación", CELDA_INICIO = "E", CELDA_FIN = "F", INT_CELDAS = 1 });
                        columnas.Add(new Columnas { ID_COLUMNA = "DESCRIPCION_ESTADO", DESCRIPCION_COLUMNA = "Estado", CELDA_INICIO = "G", CELDA_FIN = "G", INT_CELDAS = 1 });
                        //columnas.Add(new Columnas { ID_COLUMNA = "DES_TIP_DOC", DESCRIPCION_COLUMNA = "Tipo Expediente", CELDA_INICIO = "G", CELDA_FIN = "H", INT_CELDAS = 1 });
                        //columnas.Add(new Columnas { ID_COLUMNA = "DES_OBS", DESCRIPCION_COLUMNA = "Observación", CELDA_INICIO = "I", CELDA_FIN = "J", INT_CELDAS = 1 });
                        //columnas.Add(new Columnas { ID_COLUMNA = "NUM_DOC", DESCRIPCION_COLUMNA = "Nro. Documento", CELDA_INICIO = "K", CELDA_FIN = "K", INT_CELDAS = 1 });
                        //columnas.Add(new Columnas { ID_COLUMNA = "NUM_FOLIOS", DESCRIPCION_COLUMNA = "Folios", CELDA_INICIO = "L", CELDA_FIN = "L", INT_CELDAS = 1 });
                        //columnas.Add(new Columnas { ID_COLUMNA = "DES_PERSONA", DESCRIPCION_COLUMNA = "Solicitante", CELDA_INICIO = "M", CELDA_FIN = "N", INT_CELDAS = 1 });

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


    }
}
