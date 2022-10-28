using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Helpers.Authorization;
using EnServiciosDigitalizacion;
using ServiceReference2;
using Frotend.ArchivoCentral.Micetur.Helpers;
using Frotend.ArchivoCentral.Micetur.Authorization;
using System.IO;
using System.Text.Json;
using Frotend.ArchivoCentral.Micetur.Recursos;
using ServiceReference1;
using System.Web;

namespace Frotend.ArchivoCentral.Micetur.Controllers
{
    public class BaseController : Controller
    {
        // GET: BaseController
        public ActionResult UploadFileService(IFormFile fileArchivo)
        {
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar();
            try
            {
                if (fileArchivo != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        fileArchivo.CopyTo(ms);
                        var archivo = ms.ToArray();
                        string nombre_archivo = fileArchivo.FileName;
                        int usuario = int.Parse(User.GetUserId());
                        using (WCFGeneralesDocCmsRegistroClient proxy = new WCFGeneralesDocCmsRegistroClient())
                        {
                            DocCmsSubir datos = new DocCmsSubir();
                            Resultado respuesta = new Resultado();
                            datos.IdSis = AppSettings.AppId;
                            datos.DesNomAbr = nombre_archivo;
                            datos.DesRuta = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString();
                            datos.Archivo = archivo;
                            datos.IdUsu = usuario;
                            datos.IpAcceso = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                            respuesta = proxy.insertar(datos);
                            if (!string.IsNullOrEmpty(respuesta.Valor))
                            {
                                auditoria.Objeto = respuesta.Valor;
                            }
                            else
                            {
                                auditoria.Rechazar(respuesta.DesError);
                            }
                        }
                    }
                }
                else
                {
                    auditoria.Rechazar("No se encontro archivo para procesar.");
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
                auditoria.Error(ex);
            }
            return Json(auditoria);
        }

        public async Task<ActionResult> DownloadFileService(long ID_DOC)
        {
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar();
            try
            {
                using (WCFSeguridadEncripDesencripClient client = new WCFSeguridadEncripDesencripClient())
                {
                    string llave = await client.traeLlaveAsync();
                    string tex = "{ IdDocCms:" + ID_DOC + ", IdUsu:" + User.GetUserId() + ", IdSis:" + AppSettings.AppId + "}";
                    string DOC = HttpUtility.UrlEncode(await client.encriptarAESAsync(tex, llave));
                    var urlVisorLF = AppSettings.UrlApiDownload;
                    auditoria.Objeto = urlVisorLF + DOC + "&descarga=false";
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
                auditoria.Error(ex);
            }
            return Json(auditoria);
        }

    }
}
