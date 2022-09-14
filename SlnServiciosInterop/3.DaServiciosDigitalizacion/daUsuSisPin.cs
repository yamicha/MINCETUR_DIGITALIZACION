using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
 
namespace DaServiciosDigitalizacion
{
    public class daUsuSisPin : daBase
    {
        public daUsuSisPin(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }

        public enResultadoEnListaUsuSisPin listar(enUsuSisPin objEnUsuSisPin)
        {
            List<enUsuSisPin> lstEnUsuSisPin = new List<enUsuSisPin>();
            enResultadoEnListaUsuSisPin objEnResultadoListaUsuSisPin = new enResultadoEnListaUsuSisPin(); 
            //{
            //    ID_TIPO = 2, DES_ERROR = "Error:: Data Access Object",
            //    lstEnUsuSisPin = new List<enUsuSisPin>()
           //};

            //OracleCommand cmd = new OracleCommand();
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = "SGADBA.PKG_SGACONSULTA.PRC_VALIDA_USUSISPIN";
            //cmd.Parameters.Add("X_ID_USUSIS", validarNulo(objEnUsuSisPin.ID_USUSIS));
            //cmd.Parameters.Add("X_ID_USUSISPIN", validarNulo(objEnUsuSisPin.ID_USUSISPIN));
            //cmd.Parameters.Add("X_DES_PIN", validarNulo(objEnUsuSisPin.DES_PIN));
            //cmd.Parameters.Add("X_ID_USU", validarNulo(objEnUsuSisPin.ID_USU));
            //cmd.Parameters.Add("X_ID_SIS", validarNulo(objEnUsuSisPin.ID_SIS));
            //cmd.Parameters.Add("X_DATO", validarNulo(objEnUsuSisPin.DATO));
            //cmd.Parameters.Add("X_OPR", validarNulo(objEnUsuSisPin.OPR));
            //cmd.Parameters.Add("X_CURSORS", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);

            //using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            //{
            //    cn.Open();

            //    try
            //    {
            //        cmd.Connection = cn;

            //        using (OracleDataReader drReader = cmd.ExecuteReader())
            //        {
            //            object[] arrResult = null;
            //            if (drReader.HasRows)
            //            {
            //                enUsuSisPin temp = null;
            //                arrResult = new object[drReader.FieldCount];
            //                int intColIdUsuSis= drReader.GetOrdinal("ID_USUSIS");
            //                int intColIdUsuSisPin = drReader.GetOrdinal("ID_USUSISPIN");
            //                int intColFecIni = drReader.GetOrdinal("FEC_INI");
            //                int intColFecFin = drReader.GetOrdinal("FEC_FIN");
            //                int intColFlgEst = drReader.GetOrdinal("FLG_EST");
            //                int intColUsuCrea = drReader.GetOrdinal("USU_CREA");
            //                int intColFecCrea = drReader.GetOrdinal("FEC_CREA");
            //                int intColIpCrea = drReader.GetOrdinal("IP_CREA");
            //                int intColUsuModi = drReader.GetOrdinal("USU_MODI");
            //                int intColFecModi = drReader.GetOrdinal("FEC_MODI");
            //                int intColIpModi = drReader.GetOrdinal("IP_MODI");;

            //                while (drReader.Read())
            //                {
            //                    drReader.GetValues(arrResult);
            //                    temp = new enUsuSisPin();

            //                    if (!drReader.IsDBNull(intColIdUsuSis)) temp.ID_USUSIS = int.Parse(arrResult[intColIdUsuSis].ToString());
            //                    if (!drReader.IsDBNull(intColIdUsuSisPin)) temp.ID_USUSISPIN = int.Parse(arrResult[intColIdUsuSisPin].ToString());
            //                    if (!drReader.IsDBNull(intColFecIni)) temp.FEC_INI = DateTime.Parse(arrResult[intColFecIni].ToString());
            //                    if (!drReader.IsDBNull(intColFecFin)) temp.FEC_FIN = DateTime.Parse(arrResult[intColFecFin].ToString());
            //                    if (!drReader.IsDBNull(intColFlgEst)) temp.FLG_ESTADO = arrResult[intColFlgEst].ToString();
            //                    if (!drReader.IsDBNull(intColUsuCrea)) temp.USU_CREA = int.Parse(arrResult[intColUsuCrea].ToString());
            //                    if (!drReader.IsDBNull(intColFecCrea)) temp.FEC_CREA = DateTime.Parse(arrResult[intColFecCrea].ToString());
            //                    if (!drReader.IsDBNull(intColIpCrea)) temp.IP_CREA = arrResult[intColIpCrea].ToString();
            //                    if (!drReader.IsDBNull(intColUsuModi)) temp.USU_MODI = int.Parse(arrResult[intColUsuModi].ToString());
            //                    if (!drReader.IsDBNull(intColFecModi)) temp.FEC_MODI = DateTime.Parse(arrResult[intColFecModi].ToString());
            //                    if (!drReader.IsDBNull(intColIpModi)) temp.IP_MODI = arrResult[intColIpModi].ToString();

            //                    objEnResultadoListaUsuSisPin.lstEnUsuSisPin.Add(temp);
            //                }

            //                objEnResultadoListaUsuSisPin = new enResultadoEnListaUsuSisPin()
            //                {
            //                    ID_TIPO = 0,
            //                    ID_ERROR = objEnResultadoListaUsuSisPin.lstEnUsuSisPin.Count().ToString(),
            //                    DES_ERROR = "Válido"
            //                };

            //                drReader.Close();
            //            }
            //        }
            //        //--------------------------------
            //    }
            //    catch (Exception ex)
            //    {
            //        objEnResultadoListaUsuSisPin = new enResultadoEnListaUsuSisPin()
            //        {
            //            ID_TIPO = 1,
            //            DES_ERROR = ex.ToString()
            //        };
            //    }
            //    finally
            //    {
            //        if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
            //        if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
            //    }
            //}

            return objEnResultadoListaUsuSisPin;
        }
    }
}
