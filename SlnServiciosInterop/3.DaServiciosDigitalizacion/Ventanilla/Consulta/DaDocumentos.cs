using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Consulta;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using Utilitarios.Helpers;

namespace DaServiciosDigitalizacion.Ventanilla.Consulta
{
    public class DaDocumentos: daBase
    {
        public DaDocumentos(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }
        public List<enDocumentoVen> Documento_Ventanilla(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enDocumentoVen> lista = new List<enDocumentoVen>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDocVentanilla, "PRC_CDVDOCVENT_PAGINACION");
            cmd.Parameters.Add("X_PAGINA", PAGINA);
            cmd.Parameters.Add("X_NROREGISTROS", FILAS);
            cmd.Parameters.Add("X_ORDEN_COLUMNA", ORDEN_COLUMNA);
            cmd.Parameters.Add("X_ORDEN", ORDEN);
            cmd.Parameters.Add("X_WHERE", @WHERE);
            cmd.Parameters.Add("X_CUENTA", OracleDbType.Int32, System.Data.ParameterDirection.Output);
            cmd.Parameters.Add("X_RESULTADO", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                try
                {
                    cmd.Connection = cn;
                    using (OracleDataReader drReader = cmd.ExecuteReader())
                    {
                        int CUENTA = int.Parse(cmd.Parameters["X_CUENTA"].Value.ToString());
                        auditoria.Objeto = CUENTA;
                        object[] arrResult = null;
                        if (drReader.HasRows)
                        {
                            enDocumentoVen temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int int_ID_EXPE = drReader.GetOrdinal("ID_EXPE");
                            int int_FEC_EXPE_STR = drReader.GetOrdinal("FEC_EXPE");
                            int int_ID_PERSONA = drReader.GetOrdinal("ID_PERSONA");
                            int int_DES_PERSONA = drReader.GetOrdinal("DES_PERSONA");
                            int int_ID_SUB = drReader.GetOrdinal("ID_SUB");
                            int int_ID_SUBOFI = drReader.GetOrdinal("ID_SUBOFI");
                            int int_ABR_SUBOFI = drReader.GetOrdinal("ABR_SUBOFI");
                            int int_DES_SUBOFI = drReader.GetOrdinal("DES_SUBOFI");
                            int int_ID_TIP_DOC = drReader.GetOrdinal("ID_TIP_DOC");
                            int int_DES_TIP_DOC = drReader.GetOrdinal("DES_TIP_DOC");
                            int int_DES_ASUNTO = drReader.GetOrdinal("DES_ASUNTO");
                            int int_DES_OBS = drReader.GetOrdinal("DES_OBS");
                            int int_ID_DOC = drReader.GetOrdinal("ID_DOC");
                            int int_NUM_DOC = drReader.GetOrdinal("NUM_DOC");
                            int int_NUM_FOLIOS = drReader.GetOrdinal("NUM_FOLIOS");
                            int int_USU_CREA = drReader.GetOrdinal("USU_CREA");
                            int int_COD_LOG = drReader.GetOrdinal("COD_LOG");
                            int int_ID_TUPA = drReader.GetOrdinal("ID_TUPA");
                            int int_DES_CLASIF = drReader.GetOrdinal("DES_CLASIF");
                            int int_FEC_EXPE = drReader.GetOrdinal("FEC_EXPE");
                           int int_DESCRIPCION_ESTADO = drReader.GetOrdinal("DESCRIPCION_ESTADO");
                            //int int_NRO_LOTE = drReader.GetOrdinal("NRO_LOTE");

                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumentoVen();

                                if (!drReader.IsDBNull(int_ID_EXPE)) temp.ID_EXPE = long.Parse(arrResult[int_ID_EXPE].ToString());
                                if (!drReader.IsDBNull(int_FEC_EXPE_STR)) temp.FEC_EXPE_STR= arrResult[int_FEC_EXPE_STR].ToString();
                                if (!drReader.IsDBNull(int_ID_PERSONA)) temp.ID_PERSONA = long.Parse(arrResult[int_ID_PERSONA].ToString());
                                if (!drReader.IsDBNull(int_DES_PERSONA)) temp.DES_PERSONA = arrResult[int_DES_PERSONA].ToString();
                                if (!drReader.IsDBNull(int_ID_SUB)) temp.ID_SUB = long.Parse(arrResult[int_ID_SUB].ToString());
                                if (!drReader.IsDBNull(int_ID_SUBOFI)) temp.ID_SUBOFI = long.Parse(arrResult[int_ID_SUBOFI].ToString());
                                if (!drReader.IsDBNull(int_ABR_SUBOFI)) temp.ABR_SUBOFI = (arrResult[int_ABR_SUBOFI].ToString());
                                if (!drReader.IsDBNull(int_DES_SUBOFI)) temp.DES_SUBOFI = (arrResult[int_DES_SUBOFI].ToString());
                                if (!drReader.IsDBNull(int_ID_TIP_DOC)) temp.ID_TIP_DOC = long.Parse(arrResult[int_ID_TIP_DOC].ToString());
                                if (!drReader.IsDBNull(int_DES_TIP_DOC)) temp.DES_TIP_DOC = (arrResult[int_DES_TIP_DOC].ToString());
                                if (!drReader.IsDBNull(int_DES_ASUNTO)) temp.DES_ASUNTO = (arrResult[int_DES_ASUNTO].ToString());
                                if (!drReader.IsDBNull(int_DES_OBS)) temp.DES_OBS = (arrResult[int_DES_OBS].ToString());
                                if (!drReader.IsDBNull(int_ID_DOC)) temp.ID_DOC = long.Parse(arrResult[int_ID_DOC].ToString());
                                if (!drReader.IsDBNull(int_NUM_DOC)) temp.NUM_DOC = (arrResult[int_NUM_DOC].ToString());
                                if (!drReader.IsDBNull(int_NUM_FOLIOS)) temp.NUM_FOLIOS = long.Parse(arrResult[int_NUM_FOLIOS].ToString());
                                if (!drReader.IsDBNull(int_USU_CREA)) temp.USU_CREA = long.Parse(arrResult[int_USU_CREA].ToString());
                                if (!drReader.IsDBNull(int_COD_LOG)) temp.COD_LOG = (arrResult[int_COD_LOG].ToString());
                                if (!drReader.IsDBNull(int_ID_TUPA)) temp.ID_TUPA = long.Parse(arrResult[int_ID_TUPA].ToString());
                                if (!drReader.IsDBNull(int_DES_CLASIF)) temp.DES_CLASIF = (arrResult[int_DES_CLASIF].ToString());
                               if (!drReader.IsDBNull(int_DESCRIPCION_ESTADO)) temp.DESCRIPCION_ESTADO = arrResult[int_DESCRIPCION_ESTADO].ToString();
                                //if (!drReader.IsDBNull(int_NRO_LOTE)) temp.NRO_LOTE = long.Parse(arrResult[int_NRO_LOTE].ToString());
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
                    lista = new List<enDocumentoVen>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }

        public HashSet<enDocumentoVen> Documento_Exportar(string @WHERE, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            HashSet<enDocumentoVen> lista = new HashSet<enDocumentoVen>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDocVentanilla, "PRC_CDVDOCVENT_EXPORTAR");
            cmd.Parameters.Add("X_WHERE", @WHERE);
            cmd.Parameters.Add("X_RESULTADO", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
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
                            enDocumentoVen temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int int_ID_EXPE = drReader.GetOrdinal("ID_EXPE");
                            int int_FEC_EXPE_STR = drReader.GetOrdinal("FEC_EXPE");
                            int int_ID_PERSONA = drReader.GetOrdinal("ID_PERSONA");
                            int int_DES_PERSONA = drReader.GetOrdinal("DES_PERSONA");
                            int int_ID_SUB = drReader.GetOrdinal("ID_SUB");
                            int int_ID_SUBOFI = drReader.GetOrdinal("ID_SUBOFI");
                            int int_ABR_SUBOFI = drReader.GetOrdinal("ABR_SUBOFI");
                            int int_DES_SUBOFI = drReader.GetOrdinal("DES_SUBOFI");
                            int int_ID_TIP_DOC = drReader.GetOrdinal("ID_TIP_DOC");
                            int int_DES_TIP_DOC = drReader.GetOrdinal("DES_TIP_DOC");
                            int int_DES_ASUNTO = drReader.GetOrdinal("DES_ASUNTO");
                            int int_DES_OBS = drReader.GetOrdinal("DES_OBS");
                            int int_ID_DOC = drReader.GetOrdinal("ID_DOC");
                            int int_NUM_DOC = drReader.GetOrdinal("NUM_DOC");
                            int int_NUM_FOLIOS = drReader.GetOrdinal("NUM_FOLIOS");
                            int int_USU_CREA = drReader.GetOrdinal("USU_CREA");
                            int int_COD_LOG = drReader.GetOrdinal("COD_LOG");
                            int int_ID_TUPA = drReader.GetOrdinal("ID_TUPA");
                            int int_DES_CLASIF = drReader.GetOrdinal("DES_CLASIF");
                            int int_FEC_EXPE = drReader.GetOrdinal("FEC_EXPE");
                            int int_DESCRIPCION_ESTADO = drReader.GetOrdinal("DESCRIPCION_ESTADO");
                            //int int_NRO_LOTE = drReader.GetOrdinal("NRO_LOTE");

                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumentoVen();
                                if (!drReader.IsDBNull(int_ID_EXPE)) temp.ID_EXPE = long.Parse(arrResult[int_ID_EXPE].ToString());
                                if (!drReader.IsDBNull(int_FEC_EXPE_STR)) temp.FEC_EXPE_STR = arrResult[int_FEC_EXPE_STR].ToString();
                                if (!drReader.IsDBNull(int_ID_PERSONA)) temp.ID_PERSONA = long.Parse(arrResult[int_ID_PERSONA].ToString());
                                if (!drReader.IsDBNull(int_DES_PERSONA)) temp.DES_PERSONA = arrResult[int_DES_PERSONA].ToString();
                                if (!drReader.IsDBNull(int_ID_SUB)) temp.ID_SUB = long.Parse(arrResult[int_ID_SUB].ToString());
                                if (!drReader.IsDBNull(int_ID_SUBOFI)) temp.ID_SUBOFI = long.Parse(arrResult[int_ID_SUBOFI].ToString());
                                if (!drReader.IsDBNull(int_ABR_SUBOFI)) temp.ABR_SUBOFI = (arrResult[int_ABR_SUBOFI].ToString());
                                if (!drReader.IsDBNull(int_DES_SUBOFI)) temp.DES_SUBOFI = (arrResult[int_DES_SUBOFI].ToString());
                                if (!drReader.IsDBNull(int_ID_TIP_DOC)) temp.ID_TIP_DOC = long.Parse(arrResult[int_ID_TIP_DOC].ToString());
                                if (!drReader.IsDBNull(int_DES_TIP_DOC)) temp.DES_TIP_DOC = (arrResult[int_DES_TIP_DOC].ToString());
                                if (!drReader.IsDBNull(int_DES_ASUNTO)) temp.DES_ASUNTO = (arrResult[int_DES_ASUNTO].ToString());
                                if (!drReader.IsDBNull(int_DES_OBS)) temp.DES_OBS = (arrResult[int_DES_OBS].ToString());
                                if (!drReader.IsDBNull(int_ID_DOC)) temp.ID_DOC = long.Parse(arrResult[int_ID_DOC].ToString());
                                if (!drReader.IsDBNull(int_NUM_DOC)) temp.NUM_DOC = (arrResult[int_NUM_DOC].ToString());
                                if (!drReader.IsDBNull(int_NUM_FOLIOS)) temp.NUM_FOLIOS = long.Parse(arrResult[int_NUM_FOLIOS].ToString());
                                if (!drReader.IsDBNull(int_USU_CREA)) temp.USU_CREA = long.Parse(arrResult[int_USU_CREA].ToString());
                                if (!drReader.IsDBNull(int_COD_LOG)) temp.COD_LOG = (arrResult[int_COD_LOG].ToString());
                                if (!drReader.IsDBNull(int_ID_TUPA)) temp.ID_TUPA = long.Parse(arrResult[int_ID_TUPA].ToString());
                                if (!drReader.IsDBNull(int_DES_CLASIF)) temp.DES_CLASIF = (arrResult[int_DES_CLASIF].ToString());
                                if (!drReader.IsDBNull(int_DESCRIPCION_ESTADO)) temp.DESCRIPCION_ESTADO = arrResult[int_DESCRIPCION_ESTADO].ToString();
                                //if (!drReader.IsDBNull(int_NRO_LOTE)) temp.NRO_LOTE = long.Parse(arrResult[int_NRO_LOTE].ToString());
                                lista.Add(temp);
                            }
                            drReader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                    lista = new HashSet<enDocumentoVen>();
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
