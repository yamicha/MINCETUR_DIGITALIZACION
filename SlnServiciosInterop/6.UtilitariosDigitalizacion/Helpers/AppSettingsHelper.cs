using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Utilitarios.Helpers
{
    public class AppSettingsHelper
    {
        public static int AppId => Convert.ToInt16(GetAppSetting("IdSis"));
        public static string Pack_AdminConsulta => GetAppSetting("Pack_AdminConsulta");
        public static string Pack_AdminMant => GetAppSetting("Pack_AdminMant");
        public static string PackCargaMant => GetAppSetting("PackCargaMant");
        public static string PackCargaCons => GetAppSetting("PackCargaConst");
        public static string MensajeLog => GetAppSetting("MensajeLog");

        public static string RutaTemporal => GetAppSetting("RutaTemporal");

        public static string RutaRepositorio => GetAppSetting("RutaRepositorio");

        private static string GetAppSetting(string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return builder.GetSection($"ConfigurationManager:AppSettings:{key}").Value;
        }
    }
}
