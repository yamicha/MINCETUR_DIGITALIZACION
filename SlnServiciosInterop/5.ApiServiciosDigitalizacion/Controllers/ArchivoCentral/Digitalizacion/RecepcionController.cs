using System;
using EnServiciosDigitalizacion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos;
namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Digitalizacion
{
    [EnableCors("AccesoCors")]
    [Route("api/archivo-central/recepcion")]
    public class RecepcionController : ControllerBase
    {
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

                //IList<Cls_V_Documento_Temporal> lista = _cls_Serv_V_Documento_Temporal.Documento_Temporal_Listar_Todo(grid.sidx, grid.sord, grid.rows, grid.page, /*grid._search, grid.searchField, grid.searchOper, grid.searchString,*/ @where, ref auditoria);
                //var generic = Recursos.Paginacion.Css_Paginacion.BuscarPaginador(grid.page, grid.rows, (int)auditoria.Objeto, lista); // BuscarPaginador<OrdenLogic, ORDENCAB>(grid, OrdenLogic.Instancia, "OrdenExpedienteCount", "OrdenExpedienteBuscar");

                //generic.Value.rows = generic.List.Select(item => new Recursos.Paginacion.Css_Row
                //{
                //    id = item.ID_DOCUMENTO.ToString(),
                //    cell = new string[] {
                //        item.ID_DOCUMENTO.ToString(),
                //        item.ID_CONTROL_CARGA.ToString(),
                //        item.ID_FONDO,
                //        item.ID_SECCION,
                //        item.ID_SUB_SECCION,
                //        item.ID_SERIE,
                //        item.ID_TIPO_DOCUMENTO,
                //        item.COD_DOCUMENTO,
                //        item.CAJA,
                //        item.DESC_FONDO,
                //        item.DESC_LARGA_SECCION,
                //        item.DESC_LARGA_SUBSECCION,
                //        item.DESC_SERIE,
                //        item.DESC_TIPO_DOCUMENTO,
                //        item.NUM_REGISTRO,
                //        item.NUM_EXPEDIENTE,
                //        item.VOLUMEN,
                //        item.DESCR_A,
                //        item.DESCR_B,
                //        item.DESCR_C,
                //        item.FECHA_INI,
                //        item.FECHA_FIN,
                //        item.FOLIOS,
                //        item.TOT_IMAGENES,

                //        item.OBSERVACION,
                //        //item.FLG_ESTADO,
                //        item.USU_CREACION,
                //        item.STR_FEC_CREACION,
                //        item.IP_CREACION,
                //        item.USU_MODIFICACION,
                //        item.STR_FEC_MODIFICACION,
                //        item.IP_MODIFICACION

                //  }
                //}).ToArray();

                //var jsonResult = Json(generic.Value, JsonRequestBehavior.AllowGet);
                //jsonResult.MaxJsonLength = int.MaxValue;
                return null;
                //return StatusCode(auditoria.Code, generic.Value);
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.ToString());
                return StatusCode(auditoria.Code, auditoria);
            }
          

        }
    }
}
