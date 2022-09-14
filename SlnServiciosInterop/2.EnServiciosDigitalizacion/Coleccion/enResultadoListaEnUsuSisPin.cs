using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnServiciosDigitalizacion
{
    public class enResultadoEnListaUsuSisPin : CoServiciosDigitalizacion.coResultado
    {
        //public List<enUsuSisPin> lstEnUsuSisPin { 
        //    get {
        //        return lstEnUsuSisPin ?? new List<enUsuSisPin>();
        //    }
        //    set
        //    {
        //        lstEnUsuSisPin = value;
        //    }
        //}}
        public List<enUsuSisPin> lstEnUsuSisPin { get; set; } = new List<enUsuSisPin>();
    }
}
