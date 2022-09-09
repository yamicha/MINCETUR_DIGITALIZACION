using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnServiciosMicroformas
{
    public class enResultadoEnListaUsuSisPin : CoServiciosMicroformas.coResultado
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
