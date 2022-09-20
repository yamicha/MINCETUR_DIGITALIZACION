using System;
using EnServiciosDigitalizacion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos;
using ApiServiciosDigitalizacion.resource.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using System.Collections.Generic;
using System.Linq;

namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Digitalizacion
{
    [EnableCors("AccesoCors")]
    [Route("api/archivo-central/recepcion")]
    public class RecepcionController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public RecepcionController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }
        [HttpPost]
        [Route("documento-temporal-paginado")]
        public IActionResult Documento_TemporalListar(Recursos.Paginacion.GridTable grid)
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
                using (DocumentoRepositorio repositorio = new DocumentoRepositorio(_ConfigurationManager))
                {
                    IList<enDocumentoTemporal> lista = repositorio.DocumentoTemporal_Paginado(grid.sidx, grid.sord, grid.rows, grid.page, /*grid._search, grid.searchField, grid.searchOper, grid.searchString,*/ @where, ref auditoria);
                    var generic = Recursos.Paginacion.Css_Paginacion.BuscarPaginador(grid.page, grid.rows, (int)auditoria.Objeto, lista); // BuscarPaginador<OrdenLogic, ORDENCAB>(grid, OrdenLogic.Instancia, "OrdenExpedienteCount", "OrdenExpedienteBuscar");

                    generic.Value.rows = generic.List.Select(item => new Recursos.Paginacion.Css_Row
                    {
                        id = item.ID_DOCUMENTO.ToString(),
                        cell = new string[] {
                            item.ID_DOCUMENTO.ToString(),
                            item.ID_CONTROL_CARGA.ToString(),
                            item.ID_FONDO,
                            item.ID_SECCION,
                            item.ID_SERIE,
                            item.DES_LARGA_SECCION,
                            item.DES_SERIE,
                            item.NOM_DOCUMENTO,
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

                    //var jsonResult = Json(generic.Value, JsonRequestBehavior.AllowGet);
                    //jsonResult.MaxJsonLength = int.MaxValue;
                    return StatusCode(auditoria.Code, generic.Value);
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
