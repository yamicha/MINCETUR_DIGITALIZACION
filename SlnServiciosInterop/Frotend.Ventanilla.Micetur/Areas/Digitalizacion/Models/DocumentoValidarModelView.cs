using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models
{
    public class DocumentoValidarModelView
    {
        public long ID_DOCUMENTO { get; set; }
        public long ID_DOCUMENTO_ASIGNADO { get; set; }
        public string VALIDAR_ID_CONFORME { get; set; }
        public List<SelectListItem> Lista_VALIDAR_ID_CONFORME { get; set; }
        public string VALIDAR_ID_TIPO_OBS { get; set; }
        public List<SelectListItem> Lista_VALIDAR_ID_TIPO_OBS { get; set; }
        public string VALIDAR_OBSERVACION { get; set; }
        public string VALIDAR_NOMBRE_DIGITALIZADOR { get; set; }
        public string DES_TIP_DOC { get; set; }
        public string DES_ASUNTO { get; set; }
        public string DES_OBS { get; set; }
        public string NUM_DOC { get; set; }
        public long NUM_FOLIOS { get; set; }
        public string DES_CLASIF { get; set; }
        public string DES_PERSONA { get; set; }
        public string EXP_OBSERVACION { get; set; }
    }
}
