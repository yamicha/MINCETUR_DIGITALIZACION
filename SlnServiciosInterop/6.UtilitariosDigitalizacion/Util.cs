using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnServiciosDigitalizacion.Enums; 


namespace Utilitarios
{
    public class Util
    {
        public static Boolean isWhiteSpace(string valor)
        {
            if (!String.IsNullOrEmpty(valor))
            {
                if (String.IsNullOrEmpty(valor.Trim()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static Boolean IsNumeric(string valor)
        {
            if (!String.IsNullOrEmpty(valor))
            {
                foreach (char c in valor)
                {
                    if (c < '0' || c > '9')
                        return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double ConvertSizeFile(double len, int tipo) {
            if(tipo == (int)TypeSizeFile.KB)
            {
                len = Math.Ceiling(len /1024); 
            }else if (tipo == (int)TypeSizeFile.MB)
            {
                len = Math.Ceiling(len /1024/1024); 
            }
            else if (tipo == (int)TypeSizeFile.GB)
            {
                len = Math.Ceiling(len /1024/1024/1024);
            }
            return len; 
        }
    }
}
