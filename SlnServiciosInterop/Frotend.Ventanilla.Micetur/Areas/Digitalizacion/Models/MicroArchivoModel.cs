using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models
{
    public class MicroArchivoModel
    {
        public long ID_MICROFORMA { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Tipo Micro Archivo] es obligatorio")]
        public long MA_TIPO_ARCHIVO { get; set; }
        public List<SelectListItem> Lista_TipoMicroArchivo = new List<SelectListItem>();


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Responsable] es obligatorio")]
        public string MA_RESPONSABLE { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Dirección] es obligatorio")]
        public string MA_DIRECCION { get; set; }

        [DataType(DataType.Text)]
        public string MA_OBSERVACION { get; set; }

    

        [DataType(DataType.Text)]
        [RegularExpression(@"^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$", ErrorMessage = "Formato inválido (HH:MM:SS)")]
        [Required(ErrorMessage = "[Hora] es obligatorio")]
        public string MA_HORA { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Fecha] es obligatorio")]
        public string MA_FECHA { get; set; }
        public long MA_ID_DOC_ALMACENAMIENTO { get; set; }

        
        public string Accion { get; set; }

    }
}
