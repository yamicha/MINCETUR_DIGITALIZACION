using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
