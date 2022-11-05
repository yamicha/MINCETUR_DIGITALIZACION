using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.Ventanilla.Micetur.Areas.Digitalizacion.Models
{
    public class RecepcionModelView
    {
        [Display(Name = "Operador:")]
        public long ID_DIGITALIZADOR { get; set; }
        public long ID_DIGITALIZADOR2 { get; set; }
        public long ID_CONTROL_CARGA_DEFAULT { get; set; }
        public long ID_TABLA_DEFAULT { get; set; }
        public List<SelectListItem> ListaPersonal = new List<SelectListItem>(); 

        public long ID_TABLA { get; set; }
        public List<SelectListItem> Lista_ID_TABLA = new List<SelectListItem>(); 

        public long ID_CONTROL_CARGA { get; set; }
        public List<SelectListItem> Lista_ID_CONTROL_CARGA = new List<SelectListItem>(); 

        public string VISOR_LF { get; set; }
        public long ID_LASER { get; set; }
    }
}
