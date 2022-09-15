using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnServiciosDigitalizacion.Base
{
    public class MultiSheets
    {
        public MultiSheets() {
            COLUMNS = new List<Columnas>();
        }
        public List<Columnas> COLUMNS { get; set; }
        public DataTable dt { get; set; }
        public bool ONLYCOLUMN { get; set; }
        public Titulo TITLE { get; set; }
        public string NAME_SHEET { get; set; }
        public UInt32 ORDEN_INDEX { get; set; }

    }

}
