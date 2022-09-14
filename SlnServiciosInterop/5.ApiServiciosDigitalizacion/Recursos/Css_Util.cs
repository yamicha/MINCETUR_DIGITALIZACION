using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServiciosDigitalizacion.Recursos
{
    public class Css_Util
    {
        public  DateTime fechaStringToDate(string fechaString) {
            DateTime Fecha = DateTime.Now; 
            if (!string.IsNullOrEmpty(fechaString))
            {
                string[] Fx = fechaString.Split('/'); 
                if(Fx.Length ==3)
                 Fecha = new DateTime(int.Parse(Fx[2]), int.Parse(Fx[1]), int.Parse(Fx[0]));
            }

            return Fecha; 
        }
    }
}
