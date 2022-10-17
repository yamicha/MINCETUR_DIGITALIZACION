using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models;
using Frotend.ArchivoCentral.Micetur.Authorization;
using Frotend.ArchivoCentral.Micetur.Filters;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Controllers
{
    [MyAuthorize]
    [Area("Digitalizacion")]
    [Route("[action]")]
    public class ControlAlmacenamientoController : Controller
    {

        // GET: ControlAlamcenamientioController
        [HttpGet, Route("~/Digitalizacion/control-almacenamiento")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("~/Digitalizacion/control-almacenamiento/mantenimiento-microarchivo")]
        public ActionResult Mantenimiento_MicroArchivo(long ID_MICROFORMA, string Accion)
        {
            MicroArchivoModel model = new MicroArchivoModel();
            model.ID_MICROFORMA = ID_MICROFORMA;
            model.Accion = Accion;
            try
            {
                model.Lista_TipoMicroArchivo = new List<SelectListItem>();
                model.Lista_TipoMicroArchivo.Insert(0, new SelectListItem { Value = "", Text = "-- Seleccione --" });
                model.Lista_TipoMicroArchivo.Insert(1, new SelectListItem { Value = "1", Text = "Propio" });
                model.Lista_TipoMicroArchivo.Insert(2, new SelectListItem { Value = "2", Text = "Tercerizado" });
                model.MA_RESPONSABLE = User.GetUserName();
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            return View(model);
        }

        [HttpGet, Route("~/Digitalizacion/control-almacenamiento/Ver-microarchivo")]
        public async Task<ActionResult> MicroArchivo_Ver(long ID_MICROFORMA, string Accion)
        {
            MicroArchivoModel model = new MicroArchivoModel();
            model.ID_MICROFORMA = ID_MICROFORMA;
            model.Accion = Accion;

            model.Lista_TipoMicroArchivo = new List<SelectListItem>();
            model.Lista_TipoMicroArchivo.Insert(0, new SelectListItem { Value = "", Text = "-- Seleccione --" });
            model.Lista_TipoMicroArchivo.Insert(1, new SelectListItem { Value = "1", Text = "Propio" });
            model.Lista_TipoMicroArchivo.Insert(2, new SelectListItem { Value = "2", Text = "Tercerizado" });
            try
            {
                enAuditoria getmircoArchivo = await new CssApi().GetApi<enAuditoria>($"archivo-central/microforma/get-microArchivo/{ID_MICROFORMA}/1");
                if (getmircoArchivo != null)
                {
                    if (!getmircoArchivo.EjecucionProceso)
                    {
                        if (getmircoArchivo.Rechazo)
                            Log.Guardar(getmircoArchivo.ErrorLog);
                    }
                    else
                    {
                        if (getmircoArchivo.Objeto != null)
                        {
                            List<enMicroArchivo> item = JsonConvert.DeserializeObject<List<enMicroArchivo>>(getmircoArchivo.Objeto.ToString());
                            if (item == null) item = new List<enMicroArchivo>();
                            if (item.Count > 0)
                            {
                                model.MA_TIPO_ARCHIVO = item[0].TIPO_ARCHIVO;
                                model.MA_RESPONSABLE = item[0].RESPONSABLE;
                                model.MA_OBSERVACION = item[0].OBSERVACION;
                                model.MA_DIRECCION = item[0].DIRECCION;
                                model.MA_FECHA = item[0].FECHA;
                                model.MA_HORA = item[0].HORA;
                                model.MA_ID_DOC_ALMACENAMIENTO = item[0].ID_DOC_ALMACENAMIENTO;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
            }
            return View(model);
        }

    }
}
