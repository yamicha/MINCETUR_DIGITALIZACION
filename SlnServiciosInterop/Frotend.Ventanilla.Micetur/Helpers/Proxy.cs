using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using Frotend.Ventanilla.Micetur.Recursos;
using docSubirDocumento;

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
                        Resultado respuesta = new Resultado();
                        datos.IdSis = AppSettings.AppId;
                        datos.DesNomAbr = name;
                        datos.DesRuta = "VV/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + ID_EXPE.ToString();
                        datos.Archivo = Archivo;
                        datos.IdUsu = IdUsu;
                        datos.IdDocCms = -1;
                        datos.FlgPin = 0;
                        datos.IdDoc = -1;
                        datos.FlgDoc = 0;
                        datos.FlgCms = 1;
                        datos.IpAcceso ="::1"; 
                        datos.Dato = string.Empty;
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
