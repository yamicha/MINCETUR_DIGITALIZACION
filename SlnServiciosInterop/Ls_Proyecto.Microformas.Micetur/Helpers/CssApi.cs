using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EnServiciosMicroformas.ArchivoCentral;
using Newtonsoft.Json;

namespace Ls_Proyecto.Microformas.Micetur.Helpers
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
    }
}
