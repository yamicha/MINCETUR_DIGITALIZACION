using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models
{
    public class MicroformaGrabaModelView
    {
        public long MICROFORMA_ID_LOTE { get; set; }

        [Required(ErrorMessage = "[Fecha] Obligatorio")]
        public string MICROFORMA_FECHA { get; set; }

        [Required(ErrorMessage = "[Hora] * ")]
        [RegularExpression(@"^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$", ErrorMessage = "Formato inválido (HH:MM:SS)")]
        public string MICROFORMA_HORA { get; set; }


        [Required(ErrorMessage = "[Código] Obligatorio")]
        public string MICROFORMA_CODIGO_SOPORTE { get; set; }

        [Required(ErrorMessage = "[Soporte] Obligatorio")]
        public long MICROFORMA_ID_TIPO_SOPORTE { get; set; }
        public List<SelectListItem> Lista_MICROFORMA_ID_TIPO_SOPORTE = new List<SelectListItem>(); 

        [Required(ErrorMessage = "[N° Acta] Obligatorio")]
        public string MICROFORMA_ACTA { get; set; }

        [Required(ErrorMessage = "[N° Copia] Obligatorio")]
        public string MICROFORMA_COPIAS { get; set; }

        [Required(ErrorMessage = "[Fedatario] Obligatorio")]
        public string MICROFORMA_CODIGO_FEDATARIO { get; set; }
        public string MICROFORMA_OBSERVACION { get; set; }
        public string MICROFORMA_USU_CREACION { get; set; }
        public string MICROFORMA_STR_FEC_CREACION { get; set; }
        public string MICROFORMA_IP_CREACION { get; set; }
    }
}
