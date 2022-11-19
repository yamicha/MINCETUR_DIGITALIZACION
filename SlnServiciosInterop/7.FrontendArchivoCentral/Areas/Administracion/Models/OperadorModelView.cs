using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.ArchivoCentral.Micetur.Areas.Administracion.Models
{
    public class OperadorModelView
    {
        public long ID_OPERADOR { get; set; }

        [Display(Name = "Operador:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "(*) Operador Ingrese descripción")]
        public string OPERADOR { get; set; }
        public List<SelectListItem> ListaUsuarios = new List<SelectListItem>(); 

        public string ACCION { get; set; }
    }
}
