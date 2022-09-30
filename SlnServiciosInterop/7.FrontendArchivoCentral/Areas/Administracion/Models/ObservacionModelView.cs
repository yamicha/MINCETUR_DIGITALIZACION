using System.ComponentModel.DataAnnotations;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models
{
    public class ObservacionModelView
    {
        public long ID_OBSERVACION { get; set; }

        [Display(Name = "Descripción:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese descripción")]
        public string DESC_OBSERVACION { get; set; }


        public string ACCION { get; set; }
    }
}
