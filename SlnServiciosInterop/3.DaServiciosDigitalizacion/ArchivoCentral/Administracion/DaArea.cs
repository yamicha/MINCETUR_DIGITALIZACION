using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using Utilitarios.Helpers;

namespace DaServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class DaArea : daBase
    {
        public DaArea(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }

        public List<enArea> Area_Listar(enArea objenSubSerie, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enArea> lista = new List<enArea>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackAdminConsulta + ".PRC_CDAAREA_LISTAR";
            cmd.Parameters.Add("XIN_DES_AREA", validarNulo(objenSubSerie.DES_AREA));
            cmd.Parameters.Add("XIN_FLG_ESTADO", validarNulo(objenSubSerie.FLG_ESTADO));
            cmd.Parameters.Add("XOUT_CURSOR", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                try
                {
                    cmd.Connection = cn;
                    using (OracleDataReader drReader = cmd.ExecuteReader())
                    {
                        object[] arrResult = null;
                        if (drReader.HasRows)
                        {
                            enArea temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdFondo = drReader.GetOrdinal("ID_AREA");
                            int intDesFondo = drReader.GetOrdinal("DES_AREA");
                            int intFlgEstado = drReader.GetOrdinal("FLG_ESTADO");
                            int intUsuCreacion = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("FEC_CREACION");
                            int intUsuMoficacion = drReader.GetOrdinal("USU_MODIFICACION");
                            int intfecMoficacion = drReader.GetOrdinal("FEC_MODIFICACION");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enArea();

                                if (!drReader.IsDBNull(intIdFondo)) temp.ID_AREA = int.Parse(arrResult[intIdFondo].ToString());
                                if (!drReader.IsDBNull(intDesFondo)) temp.DES_AREA = arrResult[intDesFondo].ToString();
                                if (!drReader.IsDBNull(intFlgEstado)) temp.FLG_ESTADO = arrResult[intFlgEstado].ToString();
                                if (!drReader.IsDBNull(intUsuCreacion)) temp.USU_CREACION = arrResult[intUsuCreacion].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intUsuMoficacion)) temp.USU_MODIFICACION = arrResult[intUsuMoficacion].ToString();
                                if (!drReader.IsDBNull(intfecMoficacion)) temp.FEC_MODIFICACION = arrResult[intfecMoficacion].ToString();

                                lista.Add(temp);
                            }
                            drReader.Close();
                        }
                    }
                    //--------------------------------
                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                    lista = new List<enArea>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }

    }
}
