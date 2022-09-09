using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ApiServiciosMicroformas.Recursos
{
   public class Css_Ruta
    {
        public static string Ruta_Temporal()
        {
            string ruta = ConfigurationManager.AppSettings["Servidor_Temporal"].ToString();
            if (ruta == "")
                ruta = AppDomain.CurrentDomain.BaseDirectory + @"Recursos\Temporales\";

            return ruta;
        }

        public static string Ruta_Repositorio()
        {
            string ruta = ConfigurationManager.AppSettings["Servidor_Repositorio"].ToString();
            if (ruta == "")
                ruta = AppDomain.CurrentDomain.BaseDirectory + "Recursos/Repositorio/";

            return ruta;
        }

    }
}
