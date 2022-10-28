using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using Utilitarios.Helpers;
using Utilitarios.Helpers.Authorization;

namespace DaServiciosDigitalizacion.Seguridad
{
    public class DaModulos : daBase
    {
        public DaModulos(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }
        public List<enModulos> Modulos_Listar(enModulos entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enModulos> lista = new List<enModulos>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackSeguridad + ".PRC_SGATRAER_OPCIONES";
            cmd.Parameters.Add("X_ID_USU", validarNulo(entidad.ID_USU));
            cmd.Parameters.Add("X_ID_SIS", validarNulo(entidad.ID_SIS));
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
                            enModulos temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdOpcion = drReader.GetOrdinal("ID_OPCION");
                            int intDesOpcion = drReader.GetOrdinal("DES_OPCION");
                            int intDesUrl = drReader.GetOrdinal("DES_URL");
                            int intDesUlImagen = drReader.GetOrdinal("DES_URLIMAGEN");
                            int intNumNivel = drReader.GetOrdinal("NUM_NIVEL");
                            int intNumOrden = drReader.GetOrdinal("NUM_ORDEN");
                            int intUrlLabel = drReader.GetOrdinal("DES_URLLABEL");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enModulos();

                                if (!drReader.IsDBNull(intIdOpcion)) temp.ID_OPCION = arrResult[intIdOpcion].ToString();
                                if (!drReader.IsDBNull(intDesOpcion)) temp.DES_OPCION = arrResult[intDesOpcion].ToString();
                                if (!drReader.IsDBNull(intDesUrl)) temp.DES_URL = arrResult[intDesUrl].ToString();
                                if (!drReader.IsDBNull(intDesUlImagen)) temp.DES_URLIMAGEN = arrResult[intDesUlImagen].ToString();
                                if (!drReader.IsDBNull(intNumNivel)) temp.NUM_NIVEL = int.Parse(arrResult[intNumNivel].ToString());
                                if (!drReader.IsDBNull(intNumOrden)) temp.NUM_ORDEN = int.Parse(arrResult[intNumOrden].ToString());
                                if (!drReader.IsDBNull(intUrlLabel)) temp.DES_URLLABEL = arrResult[intUrlLabel].ToString();

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
                    lista = new List<enModulos>();
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
