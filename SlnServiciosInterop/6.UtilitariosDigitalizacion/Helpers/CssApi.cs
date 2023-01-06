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
using Newtonsoft.Json;
using Utilitarios.Helpers;
using Utilitarios.Recursos;
namespace Utilitarios.Helpers
{
    public class CssApi
    {
        public async Task<T> GetApi<T>(ApiParams param) where T : class
        {
            var entidad = JsonConvert.DeserializeObject<T>("");
            try
            {
                using (var cliente = new HttpClient(new HttpClientHandler { Credentials = new NetworkCredential(param.UserAD, param.PassAD) }))
                {
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    cliente.BaseAddress = new Uri(param.EndPoint);
                    var response = await cliente.GetAsync(param.Url);
                    var json_respuesta = await response.Content.ReadAsStringAsync();
                     entidad = JsonConvert.DeserializeObject<T>(json_respuesta);
                 
                }
            }
            catch (Exception ex) 
            {
                var ex_ = ex.ToString();
                // using (var cliente = new HttpClient(new HttpClientHandler { }))
                //  {
                HttpClient cliente = new HttpClient();
                   // cliente.DefaultRequestHeaders.Clear();
                   // cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    cliente.BaseAddress = new Uri(param.EndPoint);
                    var response = await cliente.GetAsync(param.Url);
                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    entidad = JsonConvert.DeserializeObject<T>(json_respuesta);

               // }
            }
            return entidad;
        }


        public async Task<T> PostApi<T>(ApiParams param) where T : class
        {
            var entidad= JsonConvert.DeserializeObject<T>("");
            try
            {
                using (var cliente = new HttpClient(new HttpClientHandler { Credentials = new NetworkCredential(param.UserAD, param.PassAD) }))
                {
                    cliente.BaseAddress = new Uri(param.EndPoint);
                    var content = new StringContent(JsonConvert.SerializeObject(param.parametros), Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(param.Url, content);
                    var json_respuesta = await response.Content.ReadAsStringAsync();

                     entidad = JsonConvert.DeserializeObject<T>(json_respuesta);
        
                }
            }
            catch (Exception)
            {

                using (var cliente = new HttpClient(new HttpClientHandler { }))
                {
                    cliente.BaseAddress = new Uri(param.EndPoint);
                    var content = new StringContent(JsonConvert.SerializeObject(param.parametros), Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(param.Url, content);
                    var json_respuesta = await response.Content.ReadAsStringAsync();

                    entidad = JsonConvert.DeserializeObject<T>(json_respuesta);

                }
            }
            return entidad;
        }

    }

    public class ApiParams
    {
        public string EndPoint { get; set; }
        public string Url { get; set; }
        public object Params { get; set; }
        public string UserAD { get; set; }
        public string PassAD { get; set; }
        public object parametros { get; set; }
    }
}
