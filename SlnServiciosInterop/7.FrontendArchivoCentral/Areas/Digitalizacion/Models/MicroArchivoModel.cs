using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models
{
    public class MicroArchivoModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Tipo Micro Archivo] es obligatorio")]
        public string MA_TIPO_ARCHIVO { get; set; }
        public List<SelectListItem> Lista_TipoMicroArchivo = new List<SelectListItem>();


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Responsable] es obligatorio")]
        public string MA_RESPONSABLE { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Dirección] es obligatorio")]
        public string MA_DIRECCION { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Observación] es obligatorio")]
        public string MA_OBSERVACION { get; set; }

        public long ID_MICROFORMA { get; set; }
        


    }
}
