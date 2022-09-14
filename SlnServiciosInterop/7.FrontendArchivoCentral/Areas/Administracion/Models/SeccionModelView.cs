using System.ComponentModel.DataAnnotations;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models
{
    public class SeccionModelView
    {
        public long ID_SECCION { get; set; }

        [Display(Name = "Código Sección:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese código sección")]
        public string COD_SECCION { get; set; }

        [Display(Name = "Descripción corta:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese descripcion corta")]
        public string DESC_CORTA_SECCION { get; set; }

        [Display(Name = "Descripción larga:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese descripcion larga")]
        public string DESC_LARGA_SECCION { get; set; }
        public string ACCION { get; set; }
    }
}
