using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Newtonsoft.Json;
using ServiceReference1;
namespace Frotend.ArchivoCentral.Micetur.Helpers
{
    public class CssApi
    {
        public async Task<T> GetApi<T>(string _baseUrl, string token = "") where T : class
        {
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Clear();
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "cf1bEdmMXAeHLkHL2wIGNWRXyezDtPx8");
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                cliente.BaseAddress = new Uri(AppSettingsHelper.baseUrlApi);
                var response = await cliente.GetAsync(_baseUrl);
                var json_respuesta = await response.Content.ReadAsStringAsync();
                Log.Guardar(json_respuesta);
                var entidad = JsonConvert.DeserializeObject<T>(json_respuesta);
                return entidad;
            }
        }

        public enAuditoria APi2(string Url)
        {
            enAuditoria auditoria = new enAuditoria();
            var url = AppSettingsHelper.baseUrlApi + Url;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return new enAuditoria();
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string resp = objReader.ReadToEnd();
                            Log.Guardar(resp);
                            auditoria = JsonConvert.DeserializeObject<enAuditoria>(resp);
                        }
                    }
                }
                return auditoria;
            }
            catch (WebException ex)
            {
                Log.Guardar(ex.Message.ToString());
                return new enAuditoria();
            }
        }

        public async Task<T> PostApi<T>(string _baseUrl, object param) where T : class
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(AppSettingsHelper.baseUrlApi);
            var content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync(_baseUrl, content);
            var json_respuesta = await response.Content.ReadAsStringAsync();

            var entidad = JsonConvert.DeserializeObject<T>(json_respuesta);
            return entidad;
        }
        public async Task<string> ClientEncriptarIdLaser(long ID_LASER, int cod_usuario)
        {
            using (WCFSeguridadEncripDesencripClient client = new WCFSeguridadEncripDesencripClient())
            {
                string llave = await client.traeLlaveAsync();
                string ID_LASERX = ID_LASER + "|" + AppSettingsHelper.AppId;
                string COD_ENCRIPTADO = string.Format("{0}{1}{2}", HttpUtility.UrlEncode(await client.encriptarAESAsync(ID_LASERX, llave)), "&Cod=",
                    HttpUtility.UrlEncode(await client.encriptarAESAsync(cod_usuario.ToString(), llave)));
                return COD_ENCRIPTADO;
            }
        }



    }
}
