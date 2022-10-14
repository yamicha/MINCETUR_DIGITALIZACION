using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frotend.ArchivoCentral.Micetur.Areas.Digitalizacion.Models
{
    public class RevisionPeriodicaModel
    {
        public long ID_MICROFORMA { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "[Estado de Conformidad] es obligatorio")]
        public string FLG_CONFORME { get; set; }
        public List<SelectListItem> Lista_Conforme = new List<SelectListItem>();

        [Required(ErrorMessage = "[Accion] es obligatorio")]
        public string FLG_ACCION { get; set; }
        public List<SelectListItem> Lista_Accion = new List<SelectListItem>();

        [Required(ErrorMessage = "[Tipo Prueba] es obligatorio")]
        public string TIPO_PRUEBA { get; set; }
        public List<SelectListItem> Lista_TipoPrueba = new List<SelectListItem>();


        [Required(ErrorMessage = "[Responsable] es obligatorio")]
        public string ID_USUARIO { get; set; }
        public List<SelectListItem> Lista_Usuarios = new List<SelectListItem>();


        [Required(ErrorMessage = "[Observación] es obligatorio")]
        public string OBSERVACION { get; set; }

        public string Accion { get; set; }

    }
}
