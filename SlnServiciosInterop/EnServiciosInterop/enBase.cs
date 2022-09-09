using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnServiciosMicroformas
{
    public class enBase : CoServiciosMicroformas.coHBase
    {
        protected enBase() { }
        public int FLG_EST { get; set; }
        public int ID_USU { get; set; }
        public int ID_SIS { get; set; }
        public string DATO { get; set; }
        public string OPR { get; set; }
    }
}
