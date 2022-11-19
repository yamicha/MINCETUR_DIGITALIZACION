using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models
{
    public class DevolverModelView
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Area] es obligatorio")]
        public long ID_AREA { get; set; }
        public List<SelectListItem> ListaArea = new List<SelectListItem>();
        public int ID_USUARIO { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Responsable] es obligatorio")]
        public string NOMBRE_USUARIO { get; set; }
        public long ID_CONTROL_CARGA { get; set; }

        [DataType(DataType.Text)]
        public string OBSERVACION { get; set; }
    }
}
