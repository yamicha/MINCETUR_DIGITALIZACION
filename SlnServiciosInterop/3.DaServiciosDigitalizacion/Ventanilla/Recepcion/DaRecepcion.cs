using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Consulta;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using Utilitarios.Helpers;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;
using System.Data;
using EnServiciosDigitalizacion.Models.Ventanilla;
using System.Linq;

namespace DaServiciosDigitalizacion.Ventanilla.Recepcion
{
    public class DaRecepcion: daBase
    {
        public DaRecepcion(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }
        public List<enDocumentoVen> Documento_Ventanilla_Pen(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enDocumentoVen> lista = new List<enDocumentoVen>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDocVentanilla, "PRC_CDVDOCVENT_PEND");
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
                            //int int_ID_DOC = drReader.GetOrdinal("ID_DOC");
                            int int_NUM_DOC = drReader.GetOrdinal("NUM_DOC");
                            int int_NUM_FOLIOS = drReader.GetOrdinal("NUM_FOLIOS");
                            int int_USU_CREA = drReader.GetOrdinal("USU_CREA");
                            int int_COD_LOG = drReader.GetOrdinal("COD_LOG");
                            int int_ID_TUPA = drReader.GetOrdinal("ID_TUPA");
                            int int_DES_CLASIF = drReader.GetOrdinal("DES_CLASIF");
                            int int_FEC_EXPE = drReader.GetOrdinal("FEC_EXPE");
                            int int_CANT_DOC = drReader.GetOrdinal("CANT_DOC");
                            
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
                                //if (!drReader.IsDBNull(int_ID_DOC)) temp.ID_DOC = long.Parse(arrResult[int_ID_DOC].ToString());
                                if (!drReader.IsDBNull(int_NUM_DOC)) temp.NUM_DOC = (arrResult[int_NUM_DOC].ToString());
                                if (!drReader.IsDBNull(int_NUM_FOLIOS)) temp.NUM_FOLIOS = long.Parse(arrResult[int_NUM_FOLIOS].ToString());
                                if (!drReader.IsDBNull(int_USU_CREA)) temp.USU_CREA = long.Parse(arrResult[int_USU_CREA].ToString());
                                if (!drReader.IsDBNull(int_COD_LOG)) temp.COD_LOG = (arrResult[int_COD_LOG].ToString());
                                if (!drReader.IsDBNull(int_ID_TUPA)) temp.ID_TUPA = long.Parse(arrResult[int_ID_TUPA].ToString());
                                if (!drReader.IsDBNull(int_DES_CLASIF)) temp.DES_CLASIF = (arrResult[int_DES_CLASIF].ToString());
                                if (!drReader.IsDBNull(int_CANT_DOC)) temp.CANT_DOC = long.Parse(arrResult[int_CANT_DOC].ToString());
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
        public List<enDocumentoVen> Documento_Ventanilla_GetOne(enDocumentoVen endtidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enDocumentoVen> lista = new List<enDocumentoVen>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDocVentanilla, "PRC_CDVDOCVENT_GETONE");
            cmd.Parameters.Add("X_ID_EXPE", endtidad.ID_EXPE);
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
                            int int_CANT_DOC = drReader.GetOrdinal("CANT_DOC");
                            int int_NUM_SIZE_DOC = drReader.GetOrdinal("NUM_SIZE_DOC");
                            
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
                                if (!drReader.IsDBNull(int_CANT_DOC)) temp.CANT_DOC = long.Parse(arrResult[int_CANT_DOC].ToString());
                                if (!drReader.IsDBNull(int_NUM_SIZE_DOC)) temp.NUM_SIZE_DOC = long.Parse(arrResult[int_NUM_SIZE_DOC].ToString());

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
        public List<enAdjuntos> Expediente_DocumentoGetOne(long ID_EXPE, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enAdjuntos> lista = new List<enAdjuntos>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDocVentanilla, "PRC_CDVDOCEXPEDIENTE_GETONE");
            cmd.Parameters.Add("X_ID_EXPE", ID_EXPE);
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
                            enAdjuntos temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int int_ID_DOC = drReader.GetOrdinal("ID_DOC");
                            int int_ID_EXPE = drReader.GetOrdinal("ID_EXPE");
                            int int_ID_DOC_CMS = drReader.GetOrdinal("ID_DOC_CMS");
                            int int_DES_NOMABR = drReader.GetOrdinal("DES_NOM_ABR");
                            int int_SIZE = drReader.GetOrdinal("NUM_SIZE_ARCHIVO");
                            int int_DES_OBS = drReader.GetOrdinal("DES_OBS");
   
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enAdjuntos();

                                if (!drReader.IsDBNull(int_ID_DOC)) temp.ID_DOC = long.Parse(arrResult[int_ID_DOC].ToString());
                                if (!drReader.IsDBNull(int_ID_EXPE)) temp.ID_EXPE = long.Parse(arrResult[int_ID_EXPE].ToString());
                                if (!drReader.IsDBNull(int_ID_DOC_CMS)) temp.ID_DOC_CMS = long.Parse(arrResult[int_ID_DOC_CMS].ToString());
                                if (!drReader.IsDBNull(int_DES_NOMABR)) temp.DES_NOM_ABR = arrResult[int_DES_NOMABR].ToString();
                                if (!drReader.IsDBNull(int_SIZE)) temp.NUM_SIZE_ARCHIVO = long.Parse(arrResult[int_SIZE].ToString());
                                if (!drReader.IsDBNull(int_DES_OBS)) temp.DES_OBS = arrResult[int_DES_OBS].ToString();
                                if (!drReader.IsDBNull(int_DES_NOMABR)) temp.EXTENSION = System.IO.Path.GetExtension(arrResult[int_DES_NOMABR].ToString());
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
                    lista = new List<enAdjuntos>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }

        public void Expediente_Insertar(ExpedienteModels entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackManVentanilla, "PRC_CDVDOCUMENTO_INSERTAR"), cn);
                OracleTransaction transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_EXPE", OracleDbType.Int64)).Value = entidad.IdExpediente;
                cmd.Parameters.Add(new OracleParameter("X_USU_CREACION", OracleDbType.Int64)).Value = entidad.UsuCrea;
                cmd.Parameters.Add(new OracleParameter("X_IP_CREACION", OracleDbType.Varchar2)).Value = entidad.IpCrea;
                cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    dr = cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
                    if (PO_VALIDO == "0")
                    {
                        auditoria.Rechazar(PO_MENSAJE);
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        if (entidad.ListaAdjuntos.Count() > 0)
                        {
                            foreach (var item in entidad.ListaAdjuntos)
                            {
                                cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackManVentanilla, "PRC_CDVDOCUMENTOADJ_INSERTAR"), cn);
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.Add(new OracleParameter("X_ID_EXPE", OracleDbType.Int64)).Value = entidad.IdExpediente;
                                cmd.Parameters.Add(new OracleParameter("X_DES_NOM", OracleDbType.Varchar2)).Value = item.NombreArchivo;
                                cmd.Parameters.Add(new OracleParameter("X_EXT", OracleDbType.Varchar2)).Value = item.Extension;
                                cmd.Parameters.Add(new OracleParameter("X_NUM_SIZE_ARCHIVO", OracleDbType.Int64)).Value = item.PesoArchivo;
                                cmd.Parameters.Add(new OracleParameter("X_ID_DOC_CMS", OracleDbType.Int64)).Value = item.IdArchivo;
                                cmd.Parameters.Add(new OracleParameter("X_FLG_LINK", OracleDbType.Varchar2)).Value = item.FlgLink;
                                cmd.Parameters.Add(new OracleParameter("X_FLG_TIPO", OracleDbType.Varchar2)).Value = item.FlgTipo;
                                cmd.Parameters.Add(new OracleParameter("X_ID_DOC", OracleDbType.Int64)).Value = item.IdDocumento;
                                cmd.Parameters.Add(new OracleParameter("X_USU_CREACION", OracleDbType.Int64)).Value = entidad.UsuCrea;
                                cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                                cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                                dr = cmd.ExecuteReader();
                                string PO_VALIDO2 = cmd.Parameters["X_VALIDO"].Value.ToString();
                                if (PO_VALIDO2 == "0")
                                {
                                    auditoria.Rechazar(PO_MENSAJE);
                                    transaction.Rollback();
                                }
                            }
                        }
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    auditoria.Error(ex);
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
        }


    }
}
