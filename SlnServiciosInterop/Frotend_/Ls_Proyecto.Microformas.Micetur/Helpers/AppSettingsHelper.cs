using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Ls_Proyecto.Microformas.Micetur.Helpers
{
    public class AppSettingsHelper
    {
        public static int AppId => Convert.ToInt16(GetAppSetting("AppId"));
        public static string MailAvisoIngemmet => GetAppSetting("MailAvisoIngemmet");
        public static string baseUrlApi => GetAppSetting("baseUrlApi");
        public static string DefaultStorage => GetAppSetting("DefaultStorage");

        /// <summary>
        /// Obtiene valor de la configuración del web.config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetAppSetting(string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return builder.GetSection($"AppSettings:{key}").Value;
        }

    }
}
