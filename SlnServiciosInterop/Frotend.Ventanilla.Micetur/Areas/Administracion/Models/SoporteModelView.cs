using System.ComponentModel.DataAnnotations;

namespace Frotend.Ventanilla.Micetur.Areas.Administracion.Models
{
    public class SoporteModelView
    {
        public long ID_SOPORTE { get; set; }

        [Display(Name = "Descripción:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese descripción")]
        public string DESC_SOPORTE { get; set; }


        public string ACCION { get; set; }
    }
}
