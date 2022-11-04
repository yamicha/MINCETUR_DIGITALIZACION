using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using Frotend.Ventanilla.Micetur.Recursos;
using ServiceReference2;

namespace Frotend.Ventanilla.Micetur.Helpers
{
    public class Proxy
    {
        public enAuditoria UploadFileService(long ID_EXPE,string name, int IdUsu, byte[] Archivo)
        {
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar();
            try
            {
                if (Archivo != null)
                {
                    using (WCFGeneralesDocCmsRegistroClient proxy = new WCFGeneralesDocCmsRegistroClient())
                    {
                        DocCmsSubir datos = new DocCmsSubir();
                        Task<Resultado> respuesta;
                        datos.IdSis = AppSettings.AppId;
                        datos.DesNomAbr = name;
                        datos.DesRuta = "VV/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + ID_EXPE.ToString();
                        datos.Archivo = Archivo;
                        datos.IdUsu = IdUsu;
                        datos.FlgCms = 1;
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
            return auditoria;
        }

    }
}
