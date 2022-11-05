using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Administracion;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using Utilitarios.Helpers;

namespace DaServiciosDigitalizacion.Ventanilla.Administracion
{
    public class DaSoporte : daBase
    {
        public DaSoporte(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }

        public List<enSoporte> Soporte_Listar(enSoporte objenSubSerie, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enSoporte> lista = new List<enSoporte>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackAdminConsulta + ".PRC_CDASOPORTE_LISTAR";
            cmd.Parameters.Add("X_DESC_SOPORTE", validarNulo(objenSubSerie.DESC_SOPORTE));
            cmd.Parameters.Add("X_FLG_ESTADO", validarNulo(objenSubSerie.FLG_ESTADO));
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
                            enSoporte temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdSoporte = drReader.GetOrdinal("ID_SOPORTE");
                            int intDesSoporte = drReader.GetOrdinal("DESC_SOPORTE");
                            int intFlgEstado = drReader.GetOrdinal("FLG_ESTADO");
                            int intUsuCreacion = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("FEC_CREACION");
                            int intUsuMoficacion = drReader.GetOrdinal("USU_MODIFICACION");
                            int intfecMoficacion = drReader.GetOrdinal("FEC_MODIFICACION");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enSoporte();

                                if (!drReader.IsDBNull(intIdSoporte)) temp.ID_SOPORTE = int.Parse(arrResult[intIdSoporte].ToString());
                                if (!drReader.IsDBNull(intDesSoporte)) temp.DESC_SOPORTE = arrResult[intDesSoporte].ToString();
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
                    lista = new List<enSoporte>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }

        public enSoporte Soporte_ListarUno(enSoporte objenSubSerie, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            enSoporte temp = null;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackAdminConsulta + ".PRC_CDASOPORTE_LISTAR_UNO";
            cmd.Parameters.Add("X_ID_SOPORTE", validarNulo(objenSubSerie.ID_SOPORTE));
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
                            arrResult = new object[drReader.FieldCount];
                            int intIdSoporte = drReader.GetOrdinal("ID_SOPORTE");
                            int intDesSoporte = drReader.GetOrdinal("DESC_SOPORTE");
                            //int intFlgEstado = drReader.GetOrdinal("FLG_ESTADO");
                            int intUsuCreacion = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("FEC_CREACION");
                            int intUsuMoficacion = drReader.GetOrdinal("USU_MODIFICACION");
                            int intfecMoficacion = drReader.GetOrdinal("FEC_MODIFICACION");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enSoporte();

                                if (!drReader.IsDBNull(intIdSoporte)) temp.ID_SOPORTE = int.Parse(arrResult[intIdSoporte].ToString());
                                if (!drReader.IsDBNull(intDesSoporte)) temp.DESC_SOPORTE = arrResult[intDesSoporte].ToString();
                                //if (!drReader.IsDBNull(intFlgEstado)) temp.FLG_ESTADO = arrResult[intFlgEstado].ToString();
                                if (!drReader.IsDBNull(intUsuCreacion)) temp.USU_CREACION = arrResult[intUsuCreacion].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intUsuMoficacion)) temp.USU_MODIFICACION = arrResult[intUsuMoficacion].ToString();
                                if (!drReader.IsDBNull(intfecMoficacion)) temp.FEC_MODIFICACION = arrResult[intfecMoficacion].ToString();
                            }
                            drReader.Close();
                        }
                    }
                    //--------------------------------
                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                    temp = new enSoporte();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return temp;
        }

        public void Soporte_Insertar(enSoporte entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PRC_CDASOPORTE_INSERTAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_DESC_SOPORTE", OracleDbType.Varchar2)).Value = entidad.DESC_SOPORTE;
                cmd.Parameters.Add(new OracleParameter("X_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.USU_CREACION;
                cmd.Parameters.Add(new OracleParameter("X_IP_CREACION", OracleDbType.Varchar2)).Value = entidad.IP_CREACION;
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
        public void Soporte_Actualizar(enSoporte entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            OracleConnection cn = null;
            using (cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PRC_CDASOPORTE_ACTUALIZAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_SOPORTE", OracleDbType.Long)).Value = entidad.ID_SOPORTE;
                cmd.Parameters.Add(new OracleParameter("X_DESC_SOPORTE", OracleDbType.Varchar2)).Value = entidad.DESC_SOPORTE;
                cmd.Parameters.Add(new OracleParameter("X_USU_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.USU_MODIFICACION;
                cmd.Parameters.Add(new OracleParameter("X_IP_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.IP_MODIFICACION;
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
        public void Soporte_Estado(enSoporte entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PRC_CDASOPORTE_ESTADO"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_SOPORTE", OracleDbType.Long)).Value = entidad.ID_SOPORTE;
                cmd.Parameters.Add(new OracleParameter("X_FLG_ESTADO", OracleDbType.Varchar2)).Value = entidad.FLG_ESTADO;
                cmd.Parameters.Add(new OracleParameter("X_USU_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.USU_MODIFICACION;
                cmd.Parameters.Add(new OracleParameter("X_IP_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.IP_MODIFICACION;
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
        public void Soporte_Eliminar(enSoporte entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PRC_CDASOPORTE_ELIMINAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_SOPORTE", OracleDbType.Long)).Value = entidad.ID_SOPORTE;
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

    }
}
