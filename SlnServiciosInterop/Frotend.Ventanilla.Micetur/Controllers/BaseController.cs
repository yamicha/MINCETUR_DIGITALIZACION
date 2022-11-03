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
using Frotend.Ventanilla.Micetur.Helpers;
using Frotend.Ventanilla.Micetur.Authorization;
using System.IO;
using System.Text.Json;
using Frotend.Ventanilla.Micetur.Recursos;
using ServiceReference1;
using System.Web;
using Utilitarios.Recursos;
using Utilitarios;
using EnServiciosDigitalizacion.Enums;

namespace Frotend.Ventanilla.Micetur.Controllers
{
    public class BaseController : Controller
    {

        public ActionResult UploadFileService(IFormFile fileArchivo, long  ID_EXPE)
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
                            Task<Resultado> respuesta;
                            datos.IdSis = AppSettings.AppId;
                            datos.DesNomAbr = nombre_archivo;
                            datos.DesRuta = "VV/"+DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" +ID_EXPE.ToString();
                            datos.Archivo = archivo;
                            datos.IdUsu = usuario;
                            datos.FlgCms = 1;
                            datos.IpAcceso = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                            respuesta = proxy.insertarAsync(datos);
                            if (!string.IsNullOrEmpty(respuesta.Result.Valor))
                            {
                                auditoria.Objeto = respuesta.Result.Valor;
                            }
                            else
                            {
                                auditoria.Rechazar(respuesta.Result.DesError);
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

        public ActionResult guardarTemporalArchivo(IFormFile filearchivo)
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
                    string RutaTemporal = Directory.GetCurrentDirectory() + @"\Recursos\Temporal\" + Miarchivo.codigoArchivo + Miarchivo.extension;
                    using (Stream fileStream = new FileStream(RutaTemporal, FileMode.Create))
                    {
                        Miarchivo.nombreArchivo = filearchivo.FileName;
                        Miarchivo.pesoArchivo = Util.ConvertSizeFile(filearchivo.Length,(int)TypeSizeFile.KB);
                        Miarchivo.codigoArchivo = Miarchivo.codigoArchivo + Miarchivo.extension; 
                        filearchivo.CopyToAsync(fileStream);
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
