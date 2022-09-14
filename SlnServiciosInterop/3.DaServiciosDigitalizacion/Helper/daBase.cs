using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosDigitalizacion;

namespace DaServiciosDigitalizacion
{
    public class daBase : daConexion
    {        
        protected daBase(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
          //Constructor
        }

        #region Métodos Públicos
        public object validarNulo(object Obj, string objPropiedadHija = "")
        {
            try
            {

                if (!string.IsNullOrEmpty(objPropiedadHija))
                {
                }
                if ((Obj) is string)
                {
                    return (string.IsNullOrEmpty(Obj.ToString()) ? DBNull.Value : Obj);
                }
                else if ((Obj) is System.DateTime)
                {

                    return (DateTime.Equals(Obj, DateTime.MinValue) ? DBNull.Value : Obj);
                }
                else if ((Obj) is int | (Obj) is Int64 | (Obj) is Int16 | (Obj) is uint)
                {
                    if (Obj.Equals(-1) || Obj.Equals(0))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return Obj;
                    }
                }
                else if ((Obj) is double | (Obj) is decimal)
                {
                    if (Obj.Equals(-1) || Obj.Equals(0))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return Obj;
                    }
                }
                else
                {
                    if ((Obj == null))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        dynamic objPropiedad = Obj.GetType().GetProperty(objPropiedadHija).GetValue(Obj, null);
                        return validarNulo(objPropiedad);
                    }
                }
            }
            catch
            {
                return DBNull.Value;
            }
        }
        #endregion
    }
}

