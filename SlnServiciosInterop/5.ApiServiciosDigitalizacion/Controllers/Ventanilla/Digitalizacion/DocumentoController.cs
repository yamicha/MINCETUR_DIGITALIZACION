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
                            item.STR_FEC_MODIFICACION

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
