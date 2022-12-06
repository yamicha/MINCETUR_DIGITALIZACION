using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models
{
    public class SerieModelView
    {
        public long ID_SERIE { get; set; }

        [Display(Name = "Sección:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Seleccione una sección")]
        public string ID_SECCION { get; set; }
        public List<SelectListItem> CBO_SECCION { get; set; }

        [Display(Name = "Código Serie:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese un código serie")]
        public string COD_SERIE { get; set; }

        [Display(Name = "Descripción:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese una descripción")]
        public string DES_SERIE { get; set; }

        public string ACCION { get; set; }
    }
}
