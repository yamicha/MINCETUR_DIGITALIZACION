using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models
{
    public class RecibirModelView
    {
        public long ID_EXPE { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Adjunto] es obligatorio")]
        public string NOMBRE_ARCHIVO { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(ErrorMessage = "[Peso] es obligatorio")]
        public int PESO_ARCHIVO { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Extensión] es obligatorio")]
        public string EXTENSION { get; set; }

        public long ID_DIGITALIZADOR { get; set; }
        public long ID_DIGITALIZADOR2 { get; set; }
        public List<SelectListItem> ListaPersonal = new List<SelectListItem>();

        public long ID_DOC { get; set; }


    }

}
