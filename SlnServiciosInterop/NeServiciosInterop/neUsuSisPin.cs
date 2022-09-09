using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosMicroformas;
using EnServiciosMicroformas;
using DaServiciosMicroformas;

namespace NeServiciosMicroformas
{
    public class neUsuSisPin : neBase
    {
        daUsuSisPin _objDaUsuSisPin = null;
        public neUsuSisPin(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDaUsuSisPin = new daUsuSisPin(objCoConexionDb);
        }

        public enResultadoEnListaUsuSisPin listar(enUsuSisPin objEnUsuSisPin)
        {
            if (objEnUsuSisPin == null) objEnUsuSisPin = new enUsuSisPin();
            if (string.IsNullOrEmpty(objEnUsuSisPin.OPR)) objEnUsuSisPin.OPR = "1";
            return this._objDaUsuSisPin.listar(objEnUsuSisPin);
        }
    }
}
