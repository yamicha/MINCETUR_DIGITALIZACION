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
                            item.ID_PERSONA.ToString(),
                            item.ID_SUB.ToString(),
                            item.ID_SUBOFI.ToString(),
                            item.ABR_SUBOFI,
                            item.DES_SUBOFI,
                            item.ID_TIP_DOC.ToString(),
                            item.DES_TIP_DOC,
                            item.DES_OBS,
                            item.ID_DOC.ToString(),
                            item.NUM_DOC,
                            item.NUM_FOLIOS.ToString(),
                            item.USU_CREA.ToString(),
                            item.COD_LOG,
                            item.ID_TUPA.ToString(),
                            item.ID_CLASIF.ToString(),
                         
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
    }
}
