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
            cmd.CommandText = AppSettingsHelper.PackDigitalCons + ".PRC_CDALOTES_LISTAR";
            cmd.Parameters.Add("X_ID_FLG_DEVOLUCION", validarNulo(entidad.FLG_DEVOLUCION));
            cmd.Parameters.Add("X_ID_FLG_MICROFORMA", validarNulo(entidad.FLG_MICROFORMA));
            cmd.Parameters.Add("X_FECHA_INICIO", validarNulo(entidad.FECHA_INICIO));
            cmd.Parameters.Add("X_FECHA_FIN", validarNulo(entidad.FECHA_FIN));
            cmd.Parameters.Add("X_CURSOR", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
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
                            int intDesAreaPro = drReader.GetOrdinal("AREA_PROCEDENCIA");
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
                                if (!drReader.IsDBNull(intDesAreaPro)) temp.AREA_PROCEDENCIA = arrResult[intDesAreaPro].ToString();
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

        public void Documento_Digitalizar(enDocumento_Asignado entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PRC_CDADOC_DIGITALIZAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO_ASIGNADO", OracleDbType.Int64)).Value = entidad.ID_DOCUMENTO_ASIGNADO;
                cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO", OracleDbType.Int64)).Value = entidad.ID_DOCUMENTO;
                cmd.Parameters.Add(new OracleParameter("X_ID_LASERFICHE", OracleDbType.Int64)).Value = entidad.ID_LASERFICHE;
                cmd.Parameters.Add(new OracleParameter("X_HORA_INICIO", OracleDbType.Varchar2)).Value = entidad.HORA_INICIO;
                cmd.Parameters.Add(new OracleParameter("X_HORA_FIN", OracleDbType.Varchar2)).Value = entidad.HORA_FIN;
                cmd.Parameters.Add(new OracleParameter("X_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.USU_CREACION;
                cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    dr = cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
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
        public void Documento_Reprocesar(enDocumento_Asignado entidad, ref enAuditoria auditoria)
        {   
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PRC_CDADOC_REPROCESAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO_ASIGNADO", OracleDbType.Int64)).Value = entidad.ID_DOCUMENTO_ASIGNADO;
                cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO", OracleDbType.Int64)).Value = entidad.ID_DOCUMENTO;
                cmd.Parameters.Add(new OracleParameter("X_ID_LASERFICHE", OracleDbType.Int64)).Value = entidad.ID_LASERFICHE;
                cmd.Parameters.Add(new OracleParameter("X_HORA_INICIO", OracleDbType.Varchar2)).Value = entidad.HORA_INICIO;
                cmd.Parameters.Add(new OracleParameter("X_HORA_FIN", OracleDbType.Varchar2)).Value = entidad.HORA_FIN;
                cmd.Parameters.Add(new OracleParameter("X_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.USU_CREACION;
                cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    dr = cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
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
            cmd.CommandText = AppSettingsHelper.PackDigitalCons + ".PRC_CDADOC_PROCESO_LISTAR";
            cmd.Parameters.Add("X_ID_DOCUMENTO", validarNulo(entidad.ID_DOCUMENTO));
            cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add("X_CURSOR", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                try
                {
                    cmd.Connection = cn;
                    using (OracleDataReader drReader = cmd.ExecuteReader())
                    {
                        string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
                        string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
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
        public void Documento_Digitalizado_Validar(DocumentoValidarModel entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PRC_CDADOCDIGITALIZADO_VALIDA"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO_ASIGNADO", OracleDbType.Int64)).Value = entidad.IdDocumentoAsignado;
                cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO", OracleDbType.Int64)).Value = entidad.IdDocumento;
                cmd.Parameters.Add(new OracleParameter("X_ID_FLG_CONFORME", OracleDbType.Int64)).Value = entidad.FlgConforme;
                cmd.Parameters.Add(new OracleParameter("X_ID_ESTADO_DOCUMENTO", OracleDbType.Varchar2)).Value = entidad.IdEstadoDocumento;
                cmd.Parameters.Add(new OracleParameter("X_ID_TIPO_OBSERVACION", OracleDbType.Varchar2)).Value = entidad.IdTipoObservacion;
                cmd.Parameters.Add(new OracleParameter("X_COMENTARIO", OracleDbType.Varchar2)).Value = entidad.Comentario;
                cmd.Parameters.Add(new OracleParameter("X_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.UsuCreacion;
                cmd.Parameters.Add(new OracleParameter("X_IP_CREACION", OracleDbType.Varchar2)).Value = entidad.IpCreacion;
                cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    dr = cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
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
        public void Documento_Fedatario_Validar(DocumentoValidarModel entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PRC_CDADOCFEDATARIO_VALIDA"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO_ASIGNADO", OracleDbType.Int64)).Value = entidad.IdDocumentoAsignado;
                cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO", OracleDbType.Int64)).Value = entidad.IdDocumento;
                cmd.Parameters.Add(new OracleParameter("X_ID_FLG_CONFORME", OracleDbType.Int64)).Value = entidad.FlgConforme;
                cmd.Parameters.Add(new OracleParameter("X_ID_ESTADO_DOCUMENTO", OracleDbType.Varchar2)).Value = entidad.IdEstadoDocumento;
                cmd.Parameters.Add(new OracleParameter("X_ID_TIPO_OBSERVACION", OracleDbType.Varchar2)).Value = entidad.IdTipoObservacion;
                cmd.Parameters.Add(new OracleParameter("X_COMENTARIO", OracleDbType.Varchar2)).Value = entidad.Comentario;
                cmd.Parameters.Add(new OracleParameter("X_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.UsuCreacion;
                cmd.Parameters.Add(new OracleParameter("X_IP_CREACION", OracleDbType.Varchar2)).Value = entidad.IpCreacion;
                cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    dr = cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
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
        public void Documento_LoteValidar(DevolucionModel entidad, ref enAuditoria auditoria)
        {   
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PRC_CDADOCLOTE_VALIDAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_LOTE", OracleDbType.Int64)).Value = entidad.IdLote;
                cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    dr = cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
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
        public void Documento_Devolver(DevolucionModel entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand();
                OracleTransaction transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);  
                cmd.Transaction = transaction;
                try
                {
                    if (entidad.ListaIdsLotes.Count() > 0)
                    {

                        foreach (DevolucionModel item  in entidad.ListaIdsLotes)
                        {
                            cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PRC_CDADOCDEVOLUCION_INSERTAR"), cn);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new OracleParameter("X_ID_LOTE", OracleDbType.Int64)).Value = item.IdLote;
                            cmd.Parameters.Add(new OracleParameter("X_ID_USUARIO", OracleDbType.Int64)).Value = entidad.IdUsuario;
                            cmd.Parameters.Add(new OracleParameter("X_ID_AREA", OracleDbType.Int64)).Value = entidad.IdArea;
                            cmd.Parameters.Add(new OracleParameter("X_COMENTARIO", OracleDbType.Varchar2, 200)).Value = entidad.Comentario;
                            cmd.Parameters.Add(new OracleParameter("X_FEC_DEVOLUCION", OracleDbType.Date)).Value = entidad.FecDevolucion;
                            cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                            cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                            dr = cmd.ExecuteReader();
                            string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
                            string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
                            if (PO_VALIDO == "0")
                            {
                                auditoria.Rechazar(PO_MENSAJE);
                                transaction.Rollback();
                            }
                        }
                        if (!auditoria.Rechazo)
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
