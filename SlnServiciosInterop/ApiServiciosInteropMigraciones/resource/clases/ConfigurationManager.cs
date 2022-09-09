using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServiciosMicroformas.resource.clases
{
    public class ConfigurationManager
    {
        public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
        public AppSettings AppSettings { get; set; } = new AppSettings();
    }

    public class AppSettings
    {
        public int IdSis { get; set; } = -1;
        public string ServerCnx { get; set; } = "local";
        public string UserCnx { get; set; }
        public string PassCnx { get; set; }
        public string TipoDocumentoDefecto { get; set; }

        public string ManejoErrores { get; set; }
    }

    public class ConnectionStrings
    {
        public string MyDatabase { get; set; }
        public string Tns_Admin { get; set; }
    }
}
