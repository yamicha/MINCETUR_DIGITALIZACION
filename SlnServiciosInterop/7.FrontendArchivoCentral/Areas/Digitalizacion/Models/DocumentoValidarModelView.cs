using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models
{
    public class DocumentoValidarModelView
    {
        public long ID_DOCUMENTO { get; set; }
        public long ID_DOCUMENTO_ASIGNADO { get; set; }
        public string NOM_DOCUMENTO { get; set; }
        public string DESC_FONDO { get; set; }
        public int ID_SECCION { get; set; }
        public string DESC_LARGA_SECCION { get; set; }
        public int ID_SERIE { get; set; }
        public string DESC_SERIE { get; set; }
        public string DESCRIPCION { get; set; }
        public long ANIO { get; set; }
        public long FOLIOS { get; set; }
        public long IMAGEN { get; set; }
        public string OBSERVACION { get; set; }
        public string CODIGO_IMAGEN { get; set; }
        public string VALIDAR_ID_CONFORME { get; set; }
        public List<SelectListItem> Lista_VALIDAR_ID_CONFORME { get; set; }
        public string VALIDAR_ID_TIPO_OBS { get; set; }
        public List<SelectListItem> Lista_VALIDAR_ID_TIPO_OBS { get; set; }
        public string VALIDAR_OBSERVACION { get; set; }
        public string VALIDAR_NOMBRE_DIGITALIZADOR { get; set; }
        public string VISOR_LF { get; set; }
        public long ID_LASER { get; set; }
    }
}
