using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion.Models;
using Oracle.ManagedDataAccess.Client;
using Utilitarios.Helpers;


namespace DaServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
    public class DaMicroforma : daBase
    {
        public DaMicroforma(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
        }
        public List<enMicroforma> Microforma_Listar(enMicroforma entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enMicroforma> lista = new List<enMicroforma>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PROC_CDAMICRO_LISTAR");
            cmd.Parameters.Add("XOUT_RESULTADO", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
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
                            enMicroforma temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdMicro = drReader.GetOrdinal("ID_MICROFORMA");
                            int intTipoSoporte = drReader.GetOrdinal("ID_TIPO_SOPORTE");
                            int intDescSoporte = drReader.GetOrdinal("DESC_SOPORTE");
                            int intCodigoSoporte = drReader.GetOrdinal("CODIGO_SOPORTE");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enMicroforma();

                                if (!drReader.IsDBNull(intIdMicro)) temp.ID_MICROFORMA = long.Parse(arrResult[intIdMicro].ToString());
                                if (!drReader.IsDBNull(intTipoSoporte)) temp.ID_TIPO_SOPORTE = long.Parse(arrResult[intTipoSoporte].ToString());
                                if (!drReader.IsDBNull(intDescSoporte)) temp.DESC_SOPORTE = arrResult[intDescSoporte].ToString();
                                if (!drReader.IsDBNull(intCodigoSoporte)) temp.CODIGO_SOPORTE = arrResult[intCodigoSoporte].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();

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
                    lista = new List<enMicroforma>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }

        public List<enLote> Microforma_LotesListar(long ID_MICROFORMA, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enLote> lista = new List<enLote>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PROC_CDAMICRO_LOTESLISTAR");
            cmd.Parameters.Add(new OracleParameter("XIN_ID_MICROFORMA", OracleDbType.Int64)).Value = ID_MICROFORMA; 
            cmd.Parameters.Add("XOUT_RESULTADO", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
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
                            enLote temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdLote = drReader.GetOrdinal("ID_LOTE");
                            int intNroLote = drReader.GetOrdinal("NRO_LOTE");
                            int intUsuCrea = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intObsDevolucion = drReader.GetOrdinal("OBS_DEVOLUCION");
                            int intDesArea = drReader.GetOrdinal("DES_AREA");
                            int intFecDevolucion = drReader.GetOrdinal("STR_FEC_DEVOLUCION");
                            int intResponsableDevo = drReader.GetOrdinal("USU_DEVOLUCION");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enLote();

                                if (!drReader.IsDBNull(intIdLote)) temp.ID_LOTE = int.Parse(arrResult[intIdLote].ToString());
                                if (!drReader.IsDBNull(intNroLote)) temp.NRO_LOTE = arrResult[intNroLote].ToString();
                                if (!drReader.IsDBNull(intUsuCrea)) temp.USU_CREACION = arrResult[intUsuCrea].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intObsDevolucion)) temp.OBS_DEVOLUCION = arrResult[intObsDevolucion].ToString();
                                if (!drReader.IsDBNull(intDesArea)) temp.DES_AREA = arrResult[intDesArea].ToString();
                                if (!drReader.IsDBNull(intFecDevolucion)) temp.STR_FEC_DEVOLUCION = arrResult[intFecDevolucion].ToString();
                                if (!drReader.IsDBNull(intResponsableDevo)) temp.USU_DEVOLUCION = arrResult[intResponsableDevo].ToString();

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
                    lista = new List<enLote>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }
        public void Microforma_Insertar(MicroformaModel entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PROC_CDAMICROFORMA_INSERTAR"), cn);
                OracleTransaction transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_TIPO_SOPORTE", OracleDbType.Int64)).Value = entidad.IdSoporte;
                cmd.Parameters.Add(new OracleParameter("XIN_CODIGO_SOPORTE", OracleDbType.Varchar2)).Value = entidad.CodigoSoporte;
                cmd.Parameters.Add(new OracleParameter("XIN_NRO_ACTA", OracleDbType.Varchar2)).Value = entidad.NroActa;
                cmd.Parameters.Add(new OracleParameter("XIN_NRO_COPIAS", OracleDbType.Varchar2)).Value = entidad.NroCopias;
                cmd.Parameters.Add(new OracleParameter("XIN_CODIGO_FEDATARIO", OracleDbType.Varchar2)).Value = entidad.CodigoFedatario;
                cmd.Parameters.Add(new OracleParameter("XIN_OBSERVACION", OracleDbType.Varchar2)).Value = entidad.Observacion;
                cmd.Parameters.Add(new OracleParameter("XIN_FECHA", OracleDbType.Varchar2)).Value = entidad.Observacion;
                cmd.Parameters.Add(new OracleParameter("XIN_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.UsuCreacion;
                cmd.Parameters.Add(new OracleParameter("XOUT_ID_MICROFORMA", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("XOUT_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("XOUT_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    dr = cmd.ExecuteReader();
                    string PO_ID_MICROFORMA = cmd.Parameters["XOUT_ID_MICROFORMA"].Value.ToString();
                    string PO_VALIDO = cmd.Parameters["XOUT_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["XOUT_MENSAJE"].Value.ToString();
                    if (PO_VALIDO == "0")
                    {
                        auditoria.Rechazar(PO_MENSAJE);
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        if (entidad.ListaIdsLotes.Count() > 0)
                        {
                            foreach (MicroformaModel item in entidad.ListaIdsLotes)
                            {
                                cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PROC_CDADOCLOTE_MICROFORMA"), cn);
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.Add(new OracleParameter("XIN_ID_LOTE", OracleDbType.Int64)).Value = item.IdLote;
                                cmd.Parameters.Add(new OracleParameter("XIN_ID_MICROFORMA", OracleDbType.Int64)).Value = PO_ID_MICROFORMA;
                                cmd.Parameters.Add(new OracleParameter("XOUT_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                                cmd.Parameters.Add(new OracleParameter("XOUT_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                                dr = cmd.ExecuteReader();
                                string PO_VALIDO2 = cmd.Parameters["XOUT_VALIDO"].Value.ToString();
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
