using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion; 
using Utilitarios.Helpers;

namespace DaServiciosDigitalizacion.Archivo_Central.Administracion
{
    public class DaSeccion : daBase
    {
        public DaSeccion(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }
        public List<enSeccion> Seccion_Listar(enSeccion objenSeccion, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enSeccion> lista = new List<enSeccion>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackAdminConsulta + ".PRC_CDASECCION_LISTAR";
            cmd.Parameters.Add("X_DES_SECCION", validarNulo(objenSeccion.DES_LARGA_SECCION));
            cmd.Parameters.Add("X_FLG_ESTADO", validarNulo(objenSeccion.FLG_ESTADO));
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
                            enSeccion temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdSeccion = drReader.GetOrdinal("ID_SECCION");
                            int intDescCorta = drReader.GetOrdinal("DES_CORTA_SECCION");
                            int intDescLarga = drReader.GetOrdinal("DES_LARGA_SECCION");
                            int intFlgEstado = drReader.GetOrdinal("FLG_ESTADO");
                            int intUsuCreacion = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intUsuMoficacion = drReader.GetOrdinal("USU_MODIFICACION");
                            int intfecMoficacion = drReader.GetOrdinal("STR_FEC_MODIFICACION");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enSeccion();

                                if (!drReader.IsDBNull(intIdSeccion)) temp.ID_SECCION = int.Parse(arrResult[intIdSeccion].ToString());
                                if (!drReader.IsDBNull(intDescCorta)) temp.DES_CORTA_SECCION = arrResult[intDescCorta].ToString();
                                if (!drReader.IsDBNull(intDescLarga)) temp.DES_LARGA_SECCION = arrResult[intDescLarga].ToString();
                                if (!drReader.IsDBNull(intFlgEstado)) temp.FLG_ESTADO = arrResult[intFlgEstado].ToString();
                                if (!drReader.IsDBNull(intUsuCreacion)) temp.USU_CREACION = arrResult[intUsuCreacion].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intUsuMoficacion)) temp.USU_MODIFICACION = arrResult[intUsuMoficacion].ToString();
                                if (!drReader.IsDBNull(intfecMoficacion)) temp.STR_FEC_MODIFICACION = arrResult[intfecMoficacion].ToString();

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
                    lista = new List<enSeccion>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }

        public enSeccion Seccion_ListarUno(enSeccion objenSeccion, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            enSeccion temp = null;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackAdminConsulta + ".PRC_CDASECCION_LISTAR_UNO";
            cmd.Parameters.Add("X_ID_SECCION", validarNulo(objenSeccion.ID_SECCION));
            cmd.Parameters.Add("X_VALIDO", OracleDbType.Int32, System.Data.ParameterDirection.Output);
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
                        int PO_VALIDO = int.Parse(cmd.Parameters["X_VALIDO"].Value.ToString());
                        string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
                        if (PO_VALIDO == 0)
                            auditoria.Rechazar(PO_MENSAJE);
                        object[] arrResult = null;
                        if (drReader.HasRows)
                        {
                            //enSeccion temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdSeccion = drReader.GetOrdinal("ID_SECCION");
                            int intDescCorta = drReader.GetOrdinal("DES_CORTA_SECCION");
                            int intDescLarga = drReader.GetOrdinal("DES_LARGA_SECCION");
                            int intFlgEstado = drReader.GetOrdinal("FLG_ESTADO");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enSeccion();
                                if (!drReader.IsDBNull(intIdSeccion)) temp.ID_SECCION = int.Parse(arrResult[intIdSeccion].ToString());
                                if (!drReader.IsDBNull(intDescCorta)) temp.DES_CORTA_SECCION = arrResult[intDescCorta].ToString();
                                if (!drReader.IsDBNull(intDescLarga)) temp.DES_LARGA_SECCION = arrResult[intDescLarga].ToString();
                                if (!drReader.IsDBNull(intFlgEstado)) temp.FLG_ESTADO = arrResult[intDescLarga].ToString();
                            }
                            drReader.Close();
                        }
                    }
                    //--------------------------------
                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                    temp = new enSeccion();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return temp;
        }

        public void Seccion_Insertar(enSeccion entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PRC_CDASECCION_INSERTAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_DES_CORTA_SECCION", OracleDbType.Varchar2)).Value = entidad.DES_CORTA_SECCION;
                cmd.Parameters.Add(new OracleParameter("X_DES_LARGA_SECCION", OracleDbType.Varchar2)).Value = entidad.DES_LARGA_SECCION;
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
        public void Seccion_Actualizar(enSeccion entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            OracleConnection cn = null;
            using (cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PRC_CDASECCION_ACTUALIZAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_SECCION", OracleDbType.Int32)).Value = entidad.ID_SECCION;
                cmd.Parameters.Add(new OracleParameter("X_DES_CORTA_SECCION", OracleDbType.Varchar2)).Value = entidad.DES_CORTA_SECCION;
                cmd.Parameters.Add(new OracleParameter("X_DES_LARGA_SECCION", OracleDbType.Varchar2)).Value = entidad.DES_LARGA_SECCION;
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
        public void Seccion_Estado(enSeccion entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PRC_CDASECCION_ESTADO"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_SECCION", OracleDbType.Int32)).Value = entidad.ID_SECCION;
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
        public void Seccion_Eliminar(enSeccion entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PRC_CDASECCION_ELIMINAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_SECCION", OracleDbType.Int32)).Value = entidad.ID_SECCION;
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
