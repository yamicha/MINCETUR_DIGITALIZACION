using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  EnServiciosMicroformas

{
    public class enUsuSisRolEntEstorg : CoServiciosMicroformas.coHBase
    {
        public int ID_USU { get; set; }

        public int ID_SIS { get; set; }
        public int ID_ENT { get; set; }
        public int FLG_EST { get; set; }
        public string PIN { get; set; }
        public string OPR { get; set; }
    }
}
