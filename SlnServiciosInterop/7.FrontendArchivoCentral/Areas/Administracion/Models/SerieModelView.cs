using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models
{
    public class SerieModelView
    {
        public long ID_SERIE { get; set; }

        [Display(Name = "Sección:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Seleccione un sección")]
        public string ID_SECCION { get; set; }
        List<SelectListItem> CBO_SECCION { get; set; }

        [Display(Name = "Código Serie:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese código serie")]
        public string COD_SERIE { get; set; }

        [Display(Name = "Descripción:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese descripción")]
        public string DES_SERIE { get; set; }

        public string ACCION { get; set; }
    }
}
