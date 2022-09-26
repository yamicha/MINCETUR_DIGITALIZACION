using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EnServiciosDigitalizacion.ArchivoCentral;
using Newtonsoft.Json;

namespace Frotend.ArchivoCentral.Micetur.Helpers
{
    public class CssApi 
    {
        public async Task<T> GetApi<T>(string _baseUrl) where T : class
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(AppSettingsHelper.baseUrlApi);
            var response = await cliente.GetAsync(_baseUrl);
            var json_respuesta = await response.Content.ReadAsStringAsync();

            var entidad = JsonConvert.DeserializeObject<T>(json_respuesta);
            return  entidad; 
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
