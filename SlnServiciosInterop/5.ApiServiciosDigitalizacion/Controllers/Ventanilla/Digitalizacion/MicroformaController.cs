using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiServiciosDigitalizacion.resource.Ventanilla.Digitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;
using EnServiciosDigitalizacion.Enums;
using EnServiciosDigitalizacion.Models.Ventanilla;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Recursos;

namespace ApiServiciosDigitalizacion.Controllers.Ventanilla.Digitalizacion
{
    [EnableCors("AccesoCors")]
    [Route("api/ventanilla/microforma")]
    public class MicroformaController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        public MicroformaController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }

        [HttpPost]
        [Route("listado-paginado")]
        public IActionResult Microforma_Paginado([FromBody] Recursos.Paginacion.GridTable grid)
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

                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    IList<enMicroforma> lista = repositorio.Microforma_Paginado(grid.sidx, grid.sord, grid.rows, grid.page, @where, ref auditoria);
                    if (auditoria.EjecucionProceso)
                    {
                        var generic = Recursos.Paginacion.Css_Paginacion.BuscarPaginador(grid.page, grid.rows, (int)auditoria.Objeto, lista);

                        generic.Value.rows = generic.List.Select(item => new Recursos.Paginacion.Css_Row
                        {
                            id = item.ID_MICROFORMA.ToString(),
                            cell = new string[] {
                            item.ID_MICROFORMA.ToString(),
                            null,
                            item.NRO_VOLUMEN,
                            item.NRO_REVISIONES.ToString(),
                            item.CODIGO_SOPORTE,
                            item.DESC_SOPORTE,
                            null,
                            item.DESC_ESTADO,
                            item.STR_FEC_CREACION,
                            item.ID_ESTADO.ToString(),
                            item.FLG_CONFORME

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

        [HttpGet]
        [Route("get-microArchivo/{IdMicroforma:long}/{FlgEstado:int}")]
        public IActionResult MicroArchivo_Listar(long IdMicroforma, int FlgEstado)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.MicroArchivo_Listar(IdMicroforma, FlgEstado, ref auditoria);
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
        [Route("get-revision/{IdMicroforma:long}")]
        public IActionResult Revision_Listar(long IdMicroforma)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Revision_Listar(IdMicroforma, ref auditoria);
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
        [Route("listar-control")]
        public IActionResult Microforma_ListarControl()
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Microforma_ListarControl(new enMicroforma(), ref auditoria);
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
        [Route("get-procesos")]
        public IActionResult Microforma_ListarProcesos([FromBody] MicroModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    auditoria.Objeto = repositorio.Microforma_ListarProcesos(new enMicroformaProceso
                    {
                        ID_MICROFORMA = entidad.IdMicroforma,
                        ID_ESTADO_MICROFORMA = entidad.IdEstado
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

        [HttpPost]
        [Route("micro-archivo-insertar")]
        public IActionResult MicroArchivo_Insertar([FromBody] MicroArchivoModels entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    repositorio.Microforma_MicroArchivo(entidad, ref auditoria);
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
        [Route("micro-archivo-editar")]
        public IActionResult MicroArchivo_Editar([FromBody] MicroArchivoModels entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    if (entidad.ListaIdsMicroforma.Count > 0)
                    {
                        foreach (MicroArchivoModels item in entidad.ListaIdsMicroforma)
                        {
                            entidad.IdMicroforma = item.IdMicroforma;
                            repositorio.Microforma_MicroArchivo(entidad, ref auditoria);
                            if (auditoria.Rechazo)
                                break;
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
        [Route("revision-periodica")]
        public IActionResult Microforma_RevisionPeriodica([FromBody] RevsionPeriodicaModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                if (entidad.FlgConforme == 1)
                {
                    entidad.IdEstado = (int)EstadoMicro.RevisionConforme;
                }
                else
                    entidad.IdEstado = (int)EstadoMicro.RevisionObservada;

                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    if (entidad.ListaIdsMicroforma.Count() > 0)
                    {
                        foreach (MicroEvaluarModel item in entidad.ListaIdsMicroforma)
                        {
                            entidad.IdMicroforma = item.IdMicroforma;
                            repositorio.Microforma_RevisionPeriodica(entidad, ref auditoria);
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
        [Route("desarchivar-microforma")]
        public IActionResult Microforma_Desarchivar([FromBody] MicroArchivoModels entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    repositorio.Microforma_Desarchivar(entidad, ref auditoria);

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
        [Route("revision-reprocesar")]
        public IActionResult Microforma_RevisionReprocesar([FromBody] MicroModel entidad)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                using (MicroformaRepositorio repositorio = new MicroformaRepositorio(_ConfigurationManager))
                {
                    repositorio.Microforma_RevisionReprocesar(entidad, ref auditoria);
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
