using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Utilitarios.Helpers;

namespace ApiServiciosMicroformas.Recursos
{
   public class Css_Ruta
    {
        public static string Ruta_Temporal()
        {
            string ruta = AppSettingsHelper.RutaTemporal;
            if (ruta == "")
                ruta = AppDomain.CurrentDomain.BaseDirectory + @"Recursos\Temporales\";

            return ruta;
        }

        public static string Ruta_Repositorio()
        {
            string ruta = AppSettingsHelper.RutaRepositorio;
            if (ruta == "")
                ruta = AppDomain.CurrentDomain.BaseDirectory + "Recursos/Repositorio/";

            return ruta;
        }

    }
}
