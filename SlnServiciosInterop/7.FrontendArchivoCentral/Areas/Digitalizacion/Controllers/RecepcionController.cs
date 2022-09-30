using System;
using System.Web;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utilitarios.Recursos;
using EnServiciosDigitalizacion.ArchivoCentral.Carga.Vistas;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using EnServiciosDigitalizacion.ArchivoCentral.Carga;
using Frotend.ArchivoCentral.Micetur.Controllers;
using Frotend.ArchivoCentral.Micetur.Authorization;
using Frotend.ArchivoCentral.Micetur.Filters;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class RecepcionController : BaseController           
    {   

        // GET: SeccionController
        [HttpGet, Route("~/Digitalizacion/recepcion")]
        public async Task<ActionResult> Index()
        {
            enAuditoria auditoria = new enAuditoria();
            RecepcionModelView modelo = new RecepcionModelView();
            try
            {
                enAuditoria respuestapi = await new CssApi().GetApi<enAuditoria>($"archivo-central/carga/listar/{User.GetUserId()}");
                if (respuestapi != null)
                {
                    if (!respuestapi.EjecucionProceso)
                    {
                        if (respuestapi.Rechazo)
                            Log.Guardar(respuestapi.ErrorLog);
                    }
                    else
                    {
                        if (respuestapi.Objeto != null)
                        {
                            List<enControlCarga> Lista = JsonConvert.DeserializeObject<List<enControlCarga>>(respuestapi.Objeto.ToString());
                            modelo.Lista_ID_CONTROL_CARGA = Lista.Select(x => new SelectListItem()
                            {
                                Text = "N° : " + x.ID_CONTROL_CARGA.ToString() + " | Fecha : " +
                                x.STR_FEC_CREACION + " | N° Registros : " + x.NRO_REGISTROS + " | N° Folios : " + x.NRO_FOLIOS,
                                Value = x.ID_CONTROL_CARGA.ToString()
                            }).ToList();     
                        }
                    }

                    enAuditoria formatosAuditoria = await new CssApi().GetApi<enAuditoria>($"archivo-central/carga/lista-formato");
                    if (!formatosAuditoria.EjecucionProceso)
                    {
                        if (formatosAuditoria.Rechazo)
                            Log.Guardar(formatosAuditoria.ErrorLog);
                    }
                    else
                    {
                        if (formatosAuditoria.Objeto != null)
                        {
                            List<enTabla> Lista = JsonConvert.DeserializeObject<List<enTabla>>(formatosAuditoria.Objeto.ToString());
                            modelo.Lista_ID_TABLA = Lista.Select(x => new SelectListItem()
                            {
                                Text = x.DESCRIPCION_TABLA,
                                Value = x.ID_TABLA.ToString()
                            }).ToList();     
                        }
                    }
                }
                modelo.ListaPersonal = new List<SelectListItem>();
                modelo.ListaPersonal.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });
                modelo.ListaPersonal.Insert(1, new SelectListItem() { Value = "25", Text = "Ivan perez tintaya" });
                modelo.ListaPersonal.Insert(2, new SelectListItem() { Value = "24", Text = "Yordan Yauyo Carbajal" });

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
            finally{
                modelo.Lista_ID_CONTROL_CARGA.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });
                modelo.Lista_ID_TABLA.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });
            }
            return View(modelo);
        }
        [HttpGet, Route("~/Digitalizacion/formato-ver")]
        public ActionResult FormatoCarga_Ver(long ID_TABLA)
        {
            FormatoModelView modelo = new FormatoModelView();
            modelo.ID_TABLA = ID_TABLA;
            return View(modelo);
        }

    }
}
