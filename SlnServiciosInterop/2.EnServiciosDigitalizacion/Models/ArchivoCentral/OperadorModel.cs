using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models.ArchivoCentral
{
    public class OperadorModel
    {
        public long IdUsuario { get; set; }
        public string FlgEstado { get; set; }
        public string NombreUsuario { get; set; }
        public string UsuCreacion { get; set; }
        public string UsuModificacion { get; set; }
    }
}
