using System.ComponentModel.DataAnnotations;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models
{
    public class FondoModelView
    {
        public long ID_FONDO { get; set; }

        [Display(Name = "Descripción:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese descripción")]
        public string DESC_FONDO { get; set; }


        public string ACCION { get; set; }
    }
}
