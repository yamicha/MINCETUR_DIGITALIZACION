using System.IO;
using Utilitarios.Helpers;

namespace Utilitarios.Recursos
{
    public class Rutas
    {
        public static string Ruta_Temporal()
        {
            string ruta = AppSettingsHelper.RutaTemporal;
            if (ruta == "")
                ruta = Directory.GetCurrentDirectory() + @"\Recursos\Temporales\";

            return ruta;
        }

        public static string Ruta_Repositorio()
        {
            string ruta = AppSettingsHelper.RutaRepositorio;
            if (ruta == "")
                ruta = Directory.GetCurrentDirectory() + @"\Recursos\Repositorio\";

            return ruta;
        }

    }
}
