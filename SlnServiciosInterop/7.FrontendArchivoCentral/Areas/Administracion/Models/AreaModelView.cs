using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models
{
    public class AreaModelView
    {
        public long ID_AREA { get; set; }

        [Display(Name = "Descripción:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese descripción")]
        public string DESC_AREA { get; set; }

        [Display(Name = "Sigla:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Ingrese sigla")]
        public string SIGLA { get; set; }

        public string ACCION { get; set; }

    }
}
