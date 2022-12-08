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
using Utilitarios.Helpers;
using EnServiciosDigitalizacion.Models;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;

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
            modelo.Lista_ID_CONTROL_CARGA.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });
            modelo.Lista_ID_TABLA.Insert(0, new SelectListItem() { Value = "", Text = "--Seleccione--" });

            enAuditoria ApiArea = await new CssApi().PostApi<enAuditoria>(new ApiParams
            {
                EndPoint = AppSettings.baseUrlApi,
                Url = $"archivo-central/area/listar",
                UserAD = AppSettings.UserAD,
                PassAD = AppSettings.PassAD,
                parametros = new parameters { FlgEstado = "1" }
            });
            if (ApiArea != null)
            {
                if (!ApiArea.Rechazo)
                {
                    if (ApiArea.Objeto != null)
                    {
                        var Lista = JsonConvert.DeserializeObject<List<enArea>>(ApiArea.Objeto.ToString());
                        modelo.ListaArea = Lista.Select(x => new SelectListItem
                        {
                            Value = x.ID_AREA.ToString(),
                            Text = x.DES_AREA
                        }).ToList();
                    }
                }
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
