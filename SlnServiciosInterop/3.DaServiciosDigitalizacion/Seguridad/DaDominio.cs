using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using Utilitarios.Helpers;
using Utilitarios.Helpers.Authorization;
namespace DaServiciosDigitalizacion.Seguridad
{
    public class DaDominio : daBase
    {
        public DaDominio(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }
        public List<enDominio> Dominio_Listar(enDominio entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enDominio> lista = new List<enDominio>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackAdminConsulta + ".PRC_CDADOMINIO_LISTAR";
            cmd.Parameters.Add("X_FLG_ESTADO", validarNulo(entidad.FLG_ESTADO));
            cmd.Parameters.Add("X_CURSORS", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
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
                            enDominio temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdDominioPadre = drReader.GetOrdinal("ID_DOMINIO_PADRE");
                            int intIdDominio = drReader.GetOrdinal("ID_DOMINIO");
                            int strCodItem = drReader.GetOrdinal("COD_ITEM");
                            int strDescItem = drReader.GetOrdinal("DESC_ITEM");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDominio();
                                if (!drReader.IsDBNull(intIdDominioPadre)) temp.ID_DOMINIO_PADRE = long.Parse(arrResult[intIdDominioPadre].ToString());
                                if (!drReader.IsDBNull(intIdDominio)) temp.ID_DOMINIO = long.Parse(arrResult[intIdDominio].ToString());
                                if (!drReader.IsDBNull(strDescItem)) temp.DESC_ITEM = arrResult[strDescItem].ToString();
                                if (!drReader.IsDBNull(strCodItem)) temp.COD_ITEM = arrResult[strCodItem].ToString();
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
                    lista = new List<enDominio>();
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
