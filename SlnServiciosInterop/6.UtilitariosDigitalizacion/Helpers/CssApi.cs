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
namespace Frotend.Ventanilla.Micetur.Helpers
{
    public class CssApi
    {
        public async Task<T> GetApi<T>(string _baseUrl) where T : class
        {
            using (var cliente = new HttpClient(new HttpClientHandler{ Credentials = new NetworkCredential(@"w-mincetur\gesfiles", "Soporte100") }))
            {
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                cliente.BaseAddress = new Uri(AppSettingsHelper.baseUrlApi);
                var response = await cliente.GetAsync(_baseUrl);
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var entidad = JsonConvert.DeserializeObject<T>(json_respuesta);
                return entidad;
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


    }
}
