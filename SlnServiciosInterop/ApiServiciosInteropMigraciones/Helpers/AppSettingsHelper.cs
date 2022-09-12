using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace ApiServiciosMicroformas.Helpers
{
    public class AppSettingsHelper
    {
        public static int AppId => Convert.ToInt16(GetAppSetting("IdSis"));
        public static string MailAvisoIngemmet => GetAppSetting("MailAvisoIngemmet");
        public static string MensajeLog => GetAppSetting("MensajeLog");


        /// <summary>
        /// Obtiene valor de la configuración del web.config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetAppSetting(string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return builder.GetSection($"ConfigurationManager:AppSettings:{key}").Value;
        }
    }
}
