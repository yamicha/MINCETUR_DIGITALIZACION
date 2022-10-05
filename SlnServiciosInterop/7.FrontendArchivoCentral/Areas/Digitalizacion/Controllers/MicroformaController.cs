﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Filters;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using EnServiciosDigitalizacion.Models;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class MicroformaController : Controller
    {
        // GET: MicroformaController
        [HttpGet, Route("~/Digitalizacion/microformas")]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet, Route("~/Digitalizacion/microformas/mantenimiento")]
        public async Task<ActionResult> Mantenimiento(string accion, long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA;
            model.Accion = accion; 
            try
            {
                var parametessp = new parameters()
                {
                    FlgEstado = "1"
                };
                enAuditoria postseccion = await new CssApi().PostApi<enAuditoria>($"archivo-central/soporte/listar", parametessp);
                if (postseccion != null)
                {
                    if (!postseccion.EjecucionProceso)
                    {
                        if (postseccion.Rechazo)
                            Log.Guardar(postseccion.ErrorLog);
                    }
                    else
                    {
                        if (postseccion.Objeto != null)
                        {
                            List<enSoporte> Lista = JsonConvert.DeserializeObject<List<enSoporte>>(postseccion.Objeto.ToString());
                            if (Lista != null)
                            {
                                model.Lista_MICROFORMA_ID_TIPO_SOPORTE = Lista.Select(x => new SelectListItem
                                {
                                    Value = x.ID_SOPORTE.ToString(),
                                    Text = x.DESC_SOPORTE
                                }).ToList();
                            }
                        }
                    }
                }
                enAuditoria getmicroforma = await new CssApi().GetApi<enAuditoria>($"archivo-central/microforma/get-microforma/{ID_MICROFORMA}");
                if (getmicroforma != null)
                {
                    if (!getmicroforma.EjecucionProceso)
                    {
                        if (getmicroforma.Rechazo)
                            Log.Guardar(getmicroforma.ErrorLog);
                    }
                    else
                    {
                        if (getmicroforma.Objeto != null)
                        {
                            enMicroforma item = JsonConvert.DeserializeObject<enMicroforma>(getmicroforma.Objeto.ToString());
                            if (item == null) item = new enMicroforma();
                            model.MICROFORMA_ID_TIPO_SOPORTE = item.ID_TIPO_SOPORTE;
                            model.MICROFORMA_CODIGO_FEDATARIO = item.CODIGO_FEDATARIO;
                            model.MICROFORMA_FECHA = item.FECHA;
                            model.MICROFORMA_HORA = item.HORA;
                            model.MICROFORMA_ACTA = item.NRO_ACTA;
                            model.MICROFORMA_COPIAS = item.NRO_COPIAS;
                            model.MICROFORMA_OBSERVACION = item.OBSERVACION;
                            model.MICROFORMA_CODIGO_SOPORTE = item.CODIGO_SOPORTE;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            finally
            {
                model.Lista_MICROFORMA_ID_TIPO_SOPORTE.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            }

            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/microformas/microforma-ver")]
        public async Task<ActionResult> Microforma_Ver(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            try
            {
                var parametessp = new parameters()
                {
                    FlgEstado = "1"
                };
                enAuditoria postseccion = await new CssApi().PostApi<enAuditoria>($"archivo-central/soporte/listar", parametessp);
                if (postseccion != null)
                {
                    if (!postseccion.EjecucionProceso)
                    {
                        if (postseccion.Rechazo)
                            Log.Guardar(postseccion.ErrorLog);
                    }
                    else
                    {
                        if (postseccion.Objeto != null)
                        {
                            List<enSoporte> Lista = JsonConvert.DeserializeObject<List<enSoporte>>(postseccion.Objeto.ToString());
                            if (Lista != null)
                            {
                                model.Lista_MICROFORMA_ID_TIPO_SOPORTE = Lista.Select(x => new SelectListItem
                                {
                                    Value = x.ID_SOPORTE.ToString(),
                                    Text = x.DESC_SOPORTE
                                }).ToList();
                            }
                        }
                    }
                }

                enAuditoria getmicroforma = await new CssApi().GetApi<enAuditoria>($"archivo-central/microforma/get-microforma/{ID_MICROFORMA}");
                if (getmicroforma != null)
                {
                    if (!getmicroforma.EjecucionProceso)
                    {
                        if (getmicroforma.Rechazo)
                            Log.Guardar(getmicroforma.ErrorLog);
                    }
                    else
                    {
                        if (getmicroforma.Objeto != null)
                        {
                            enMicroforma item = JsonConvert.DeserializeObject<enMicroforma>(getmicroforma.Objeto.ToString());
                            if (item == null) item = new enMicroforma();
                            model.MICROFORMA_ID_TIPO_SOPORTE = item.ID_TIPO_SOPORTE;
                            model.MICROFORMA_CODIGO_FEDATARIO = item.CODIGO_FEDATARIO;
                            model.MICROFORMA_FECHA = item.FECHA;
                            model.MICROFORMA_HORA = item.HORA;
                            model.MICROFORMA_ACTA = item.NRO_ACTA;
                            model.MICROFORMA_COPIAS = item.NRO_COPIAS;
                            model.MICROFORMA_OBSERVACION = item.OBSERVACION;
                            model.MICROFORMA_CODIGO_SOPORTE = item.CODIGO_SOPORTE;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            finally
            {
                model.Lista_MICROFORMA_ID_TIPO_SOPORTE.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            }

            return View(model);
        }


        [HttpGet, Route("~/Digitalizacion/microformas/microforma-validar")]
        public async Task<ActionResult> Microforma_Validar(long ID_MICROFORMA)
        {
            MicroformaGrabaModelView model = new MicroformaGrabaModelView();
            model.ID_MICROFORMA = ID_MICROFORMA; 
            try
            {
                model.Lista_MICROFORMA_ID_CONFORME = new List<SelectListItem>();
                model.Lista_MICROFORMA_ID_CONFORME.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
                model.Lista_MICROFORMA_ID_CONFORME.Insert(1, new SelectListItem { Value = "1", Text = "Conforme" });
                model.Lista_MICROFORMA_ID_CONFORME.Insert(2, new SelectListItem { Value = "0", Text = "No Conforme" });
                var parametessp = new parameters()
                {
                    FlgEstado = "1"
                };
                enAuditoria postseccion = await new CssApi().PostApi<enAuditoria>($"archivo-central/soporte/listar", parametessp);
                if (postseccion != null)
                {
                    if (!postseccion.EjecucionProceso)
                    {
                        if (postseccion.Rechazo)
                            Log.Guardar(postseccion.ErrorLog);
                    }
                    else
                    {
                        if (postseccion.Objeto != null)
                        {
                            List<enSoporte> Lista = JsonConvert.DeserializeObject<List<enSoporte>>(postseccion.Objeto.ToString());
                            if (Lista != null)
                            {
                                model.Lista_MICROFORMA_ID_TIPO_SOPORTE = Lista.Select(x => new SelectListItem
                                {
                                    Value = x.ID_SOPORTE.ToString(),
                                    Text = x.DESC_SOPORTE
                                }).ToList();
                            }
                        }
                    }
                }

                enAuditoria getmicroforma = await new CssApi().GetApi<enAuditoria>($"archivo-central/microforma/get-microforma/{ID_MICROFORMA}");
                if (getmicroforma != null)
                {
                    if (!getmicroforma.EjecucionProceso)
                    {
                        if (getmicroforma.Rechazo)
                            Log.Guardar(getmicroforma.ErrorLog);
                    }
                    else
                    {
                        if (getmicroforma.Objeto != null)
                        {
                            enMicroforma item = JsonConvert.DeserializeObject<enMicroforma>(getmicroforma.Objeto.ToString());
                            if (item == null) item = new enMicroforma();
                            model.MICROFORMA_ID_TIPO_SOPORTE = item.ID_TIPO_SOPORTE;
                            model.MICROFORMA_CODIGO_FEDATARIO = item.CODIGO_FEDATARIO;
                            model.MICROFORMA_FECHA = item.FECHA;
                            model.MICROFORMA_ACTA = item.NRO_ACTA;
                            model.MICROFORMA_COPIAS = item.NRO_COPIAS;
                            model.MICROFORMA_OBSERVACION = item.OBSERVACION;
                            model.MICROFORMA_CODIGO_SOPORTE = item.CODIGO_SOPORTE;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            finally
            {
                model.Lista_MICROFORMA_ID_TIPO_SOPORTE.Insert(0, new SelectListItem { Value = "", Text = "-- selecione --" });
            }

            return View(model);
        }
    }
}
