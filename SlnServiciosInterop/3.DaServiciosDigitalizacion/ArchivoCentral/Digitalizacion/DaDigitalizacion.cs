﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Carga;
using EnServiciosDigitalizacion.ArchivoCentral.Carga.Vistas;
using Utilitarios.Helpers;
using System.Data;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;

namespace DaServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
   public class DaDigitalizacion : daBase
    {
        public DaDigitalizacion(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
        }
        public List<enLote> Lote_Listar(enLote entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enLote> lista = new List<enLote>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackDigitalCons + ".PROC_CDALOTES_LISTAR";
            cmd.Parameters.Add("XIN_ID_LOTE", validarNulo(entidad.ID_LOTE));
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
                            enLote temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdLote = drReader.GetOrdinal("ID_LOTE");
                            int intNroLote = drReader.GetOrdinal("NRO_LOTE");
                            int intUsuCrea = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enLote();

                                if (!drReader.IsDBNull(intIdLote)) temp.ID_LOTE = int.Parse(arrResult[intIdLote].ToString());
                                if (!drReader.IsDBNull(intNroLote)) temp.NRO_LOTE = arrResult[intNroLote].ToString();
                                if (!drReader.IsDBNull(intUsuCrea)) temp.USU_CREACION = arrResult[intUsuCrea].ToString();
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

        public void Documento_Digitalizar(enDocumento_Asignado entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PROC_CDADOCDIGITAL_INSERTAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_DOCUMENTO_ASIGNADO", OracleDbType.Int64)).Value = entidad.ID_DOCUMENTO_ASIGNADO;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_DOCUMENTO", OracleDbType.Int64)).Value = entidad.ID_DOCUMENTO;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_LASERFICHE", OracleDbType.Int64)).Value = entidad.ID_LASERFICHE;
                cmd.Parameters.Add(new OracleParameter("XIN_HORA_INICIO", OracleDbType.Varchar2)).Value = entidad.HORA_INICIO;
                cmd.Parameters.Add(new OracleParameter("XIN_HORA_FIN", OracleDbType.Varchar2)).Value = entidad.HORA_FIN;
                cmd.Parameters.Add(new OracleParameter("XIN_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.USU_CREACION;
                cmd.Parameters.Add(new OracleParameter("XOUT_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("XOUT_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    dr = cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["XOUT_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["XOUT_MENSAJE"].Value.ToString();
                    if (PO_VALIDO == "0")
                        auditoria.Rechazar(PO_MENSAJE);
                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
        }

        public List<enDocumento_Proceso> Documento_Proceso_Listar(enDocumento_Proceso entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enDocumento_Proceso> lista = new List<enDocumento_Proceso>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackDigitalCons + ".PROC_CDADOC_PROCESO_LISTAR";
            cmd.Parameters.Add("XIN_ID_DOCUMENTO", validarNulo(entidad.ID_DOCUMENTO));
            cmd.Parameters.Add(new OracleParameter("XOUT_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(new OracleParameter("XOUT_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add("XOUT_CURSOR", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                try
                {
                    cmd.Connection = cn;
                    using (OracleDataReader drReader = cmd.ExecuteReader())
                    {
                        string PO_VALIDO = cmd.Parameters["XOUT_VALIDO"].Value.ToString();
                        string PO_MENSAJE = cmd.Parameters["XOUT_MENSAJE"].Value.ToString();
                        if (PO_VALIDO == "0")
                            auditoria.Rechazar(PO_MENSAJE);

                        object[] arrResult = null;
                        if (drReader.HasRows)
                        {
                            enDocumento_Proceso temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdDocProceso = drReader.GetOrdinal("ID_DOCUMENTO_PROCESO");
                            int intIdDocAsignado = drReader.GetOrdinal("ID_DOCUMENTO_ASIGNADO");
                            int intIdDOcumento = drReader.GetOrdinal("ID_DOCUMENTO");
                            int intIdEstadoDoc = drReader.GetOrdinal("ID_ESTADO_DOCUMENTO");
                            int intDescripEstado = drReader.GetOrdinal("DESCRIPCION_ESTADO");
                            int intHoraInicio = drReader.GetOrdinal("HORA_INICIO");
                            int intHoraFin = drReader.GetOrdinal("HORA_FIN");
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intUsucrea = drReader.GetOrdinal("USU_CREACION");
                            
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumento_Proceso();

                                if (!drReader.IsDBNull(intIdDocProceso)) temp.ID_DOCUMENTO_PROCESO = long.Parse(arrResult[intIdDocProceso].ToString());
                                if (!drReader.IsDBNull(intIdDocAsignado)) temp.ID_DOCUMENTO_ASIGNADO = long.Parse(arrResult[intIdDocAsignado].ToString());
                                if (!drReader.IsDBNull(intIdDOcumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDOcumento].ToString());
                                if (!drReader.IsDBNull(intDescripEstado)) temp.DESCRIPCION_ESTADO = arrResult[intDescripEstado].ToString();
                                if (!drReader.IsDBNull(intHoraInicio)) temp.HORA_INICIO = arrResult[intHoraInicio].ToString();
                                if (!drReader.IsDBNull(intHoraFin)) temp.HORA_FIN = arrResult[intHoraFin].ToString();
                                if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intUsucrea)) temp.USU_CREACION = arrResult[intUsucrea].ToString();
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
                    lista = new List<enDocumento_Proceso>();
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