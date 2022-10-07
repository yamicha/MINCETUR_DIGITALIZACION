using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Frotend.ArchivoCentral.Micetur.Helpers
{
    public class AppSettingsHelper
    {
        public static int AppId => Convert.ToInt16(GetAppSetting("IdSis"));
        public static string baseUrlApi => GetAppSetting("baseUrlApi");
        public static string RutaVisorLF => GetAppSetting("RutaVisorLF");
        public static string MinIdLaser => GetAppSetting("MinIdLaser");
        
        private static string GetAppSetting(string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return builder.GetSection($"AppSettings:{key}").Value;
        }
    }
}
