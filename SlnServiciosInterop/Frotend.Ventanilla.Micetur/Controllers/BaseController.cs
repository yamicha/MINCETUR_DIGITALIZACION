using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using EnServiciosDigitalizacion;
using Frotend.Ventanilla.Micetur.Authorization;
using Frotend.Ventanilla.Micetur.Helpers;
using Frotend.Ventanilla.Micetur.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using subir = docSubirDocumento;
using Utilitarios.Recursos;

namespace Frotend.Ventanilla.Micetur.Controllers
{
    public class BaseController : Controller
    {

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
                        using (subir.WCFGeneralesDocCmsRegistroClient proxy = new subir.WCFGeneralesDocCmsRegistroClient())
                        {
                            subir.DocCmsSubir datos = new subir.DocCmsSubir();
                            subir.Resultado respuesta = new subir.Resultado();
                            datos.IdSis = AppSettings.AppId;
                            datos.DesNomAbr = nombre_archivo;
                            datos.DesRuta = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString();
                            datos.Archivo = archivo;
                            datos.IdUsu = usuario;
                            datos.IpAcceso = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                            respuesta = proxy.insertarAsync(datos).Result;
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

        public ActionResult UploadFileLaserficherService(IFormFile fileArchivo, long ID_EXPE)
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
                        using (subir.WCFGeneralesDocCmsRegistroClient proxy = new subir.WCFGeneralesDocCmsRegistroClient())
                        {
                            subir.DocCmsSubir datos = new subir.DocCmsSubir();                         
                            subir.Resultado respuesta = new subir.Resultado();
                            datos.IdSis = AppSettings.AppId;
                            datos.DesNomAbr = nombre_archivo;
                            datos.DesRuta = "VV/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + ID_EXPE.ToString();
                            datos.Archivo = archivo;
                            datos.IdUsu = usuario;
                            datos.IdDocCms = -1;
                            datos.FlgPin = 0;
                            datos.IdDoc = -1;
                            datos.FlgDoc = 0;
                            datos.FlgCms = 1;
                            datos.IpAcceso = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                            datos.Dato = string.Empty; 
                            respuesta =  proxy.insertarAsync(datos).Result;
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
                Css_Log.Guardar(ex.Message.ToString());
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
                Css_Log.Guardar(ex.Message.ToString());
                auditoria.Error(ex);
            }
            return Json(auditoria);
        }

        public async Task<ActionResult> guardarTemporalArchivo(IFormFile filearchivo)
        {
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar();
            enArchivo Miarchivo = new enArchivo();
            if (filearchivo != null)
            {
                try
                {
                    Miarchivo.extension = System.IO.Path.GetExtension(filearchivo.FileName).ToString();
                    Miarchivo.codigoArchivo = GenerarCodigo.GenerarCodigoTemporal();
                    string RutaTemporal = Css_Ruta.Ruta_Temporal + Miarchivo.codigoArchivo + Miarchivo.extension;
                    using (Stream fileStream = new FileStream(RutaTemporal, FileMode.Create))
                    {
                        Miarchivo.nombreArchivo = filearchivo.FileName;
                        Miarchivo.pesoArchivo = filearchivo.Length;
                        Miarchivo.codigoArchivo = Miarchivo.codigoArchivo + Miarchivo.extension;
                        await filearchivo.CopyToAsync(fileStream);
                        auditoria.Objeto = Miarchivo;
                    }

                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                    string CodigoLog = Css_Log.Guardar(ex.ToString());
                    auditoria.MensajeSalida = Css_Log.Mensaje(CodigoLog);
                }
            }
            else
            {
                auditoria.Rechazar("No se encontró el archivo");
            }
            return Json(auditoria);
        }


    }
}
