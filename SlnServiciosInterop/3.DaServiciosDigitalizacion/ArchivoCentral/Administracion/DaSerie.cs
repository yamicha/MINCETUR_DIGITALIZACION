using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion.Vistas;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Utilitarios.Helpers;

namespace DaServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class DaSerie : daBase
    {
        public DaSerie(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }

        public List<Vserie> Serie_Listar(Vserie objenSerie, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<Vserie> lista = new List<Vserie>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackAdminConsulta + ".PRC_CDASERIE_LISTAR";
            cmd.Parameters.Add("XIN_ID_SECCION", validarNulo(objenSerie.ID_SECCION));
            cmd.Parameters.Add("XIN_COD_SERIE", validarNulo(objenSerie.COD_SERIE));
            cmd.Parameters.Add("XIN_DES_SERIE", validarNulo(objenSerie.DES_SERIE));
            cmd.Parameters.Add("XIN_FLG_ESTADO", validarNulo(objenSerie.FLG_ESTADO));
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
                            Vserie temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdSerie = drReader.GetOrdinal("ID_SERIE");
                            int intDescCorta = drReader.GetOrdinal("DES_CORTA_SECCION");
                            int intCodSerie = drReader.GetOrdinal("COD_SERIE");
                            int intDesSerie = drReader.GetOrdinal("DES_SERIE");
                            int intUsuCreacion = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intUsuMoficacion = drReader.GetOrdinal("USU_MODIFICACION");
                            int intfecMoficacion = drReader.GetOrdinal("STR_FEC_MODIFICACION");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new Vserie();

                                if (!drReader.IsDBNull(intIdSerie)) temp.ID_SERIE = int.Parse(arrResult[intIdSerie].ToString());
                                if (!drReader.IsDBNull(intDescCorta)) temp.DES_CORTA_SECCION = arrResult[intDescCorta].ToString();
                                if (!drReader.IsDBNull(intCodSerie)) temp.COD_SERIE = arrResult[intCodSerie].ToString();
                                if (!drReader.IsDBNull(intDesSerie)) temp.DES_SERIE = arrResult[intDesSerie].ToString();
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
                    lista = new List<Vserie>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }

        public Vserie Serie_ListarUno(Vserie objenSeccion, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            Vserie temp = null;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackAdminConsulta + ".PRC_CDASERIE_LISTAR_UNO";
            cmd.Parameters.Add("XIN_ID_SERIE", validarNulo(objenSeccion.ID_SERIE));
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
                            arrResult = new object[drReader.FieldCount];
                            int intIdSerie = drReader.GetOrdinal("ID_SERIE");
                            int intDescCorta = drReader.GetOrdinal("DES_CORTA_SECCION");
                            int intCodSerie = drReader.GetOrdinal("COD_SERIE");
                            int intDesSerie = drReader.GetOrdinal("DES_SERIE");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new Vserie();
                                if (!drReader.IsDBNull(intIdSerie)) temp.ID_SERIE = int.Parse(arrResult[intIdSerie].ToString());
                                if (!drReader.IsDBNull(intDescCorta)) temp.DES_CORTA_SECCION = arrResult[intDescCorta].ToString();
                                if (!drReader.IsDBNull(intCodSerie)) temp.COD_SERIE = arrResult[intCodSerie].ToString();
                                if (!drReader.IsDBNull(intDesSerie)) temp.DES_SERIE = arrResult[intDesSerie].ToString();
                            }
                            drReader.Close();
                        }
                    }
                    //--------------------------------
                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                    temp = new Vserie();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return temp;
        }

        public void Serie_Insertar(enSerie entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PROC_CDASERIE_INSERTAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_SECCION", OracleDbType.Long)).Value = entidad.ID_SECCION;
                cmd.Parameters.Add(new OracleParameter("XIN_COD_SERIE", OracleDbType.Varchar2)).Value = entidad.COD_SERIE;
                cmd.Parameters.Add(new OracleParameter("XIN_DES_SERIE", OracleDbType.Varchar2)).Value = entidad.DES_SERIE;
                cmd.Parameters.Add(new OracleParameter("XIN_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.USU_CREACION;
                cmd.Parameters.Add(new OracleParameter("XIN_IP_CREACION", OracleDbType.Varchar2)).Value = entidad.IP_CREACION;
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
        public void Serie_Actualizar(enSerie entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            OracleConnection cn = null;
            using (cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PROC_CDASERIE_ACTUALIZAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_SERIE", OracleDbType.Long)).Value = entidad.ID_SERIE;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_SECCION", OracleDbType.Long)).Value = entidad.ID_SECCION;
                cmd.Parameters.Add(new OracleParameter("XIN_COD_SERIE", OracleDbType.Varchar2)).Value = entidad.COD_SERIE;
                cmd.Parameters.Add(new OracleParameter("XIN_DES_SERIE", OracleDbType.Varchar2)).Value = entidad.DES_SERIE;
                cmd.Parameters.Add(new OracleParameter("XIN_USU_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.USU_MODIFICACION;
                cmd.Parameters.Add(new OracleParameter("XIN_IP_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.IP_MODIFICACION;
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
        public void Serie_Estado(enSerie entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PROC_CDASERIE_ESTADO"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_SERIE", OracleDbType.Long)).Value = entidad.ID_SERIE;
                cmd.Parameters.Add(new OracleParameter("XIN_FLG_ESTADO", OracleDbType.Varchar2)).Value = entidad.FLG_ESTADO;
                cmd.Parameters.Add(new OracleParameter("XIN_USU_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.USU_MODIFICACION;
                cmd.Parameters.Add(new OracleParameter("XIN_IP_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.IP_MODIFICACION;
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
        public void Serie_Eliminar(enSerie entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackAdminMant, "PROC_CDASERIE_ELIMINAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_SERIE", OracleDbType.Long)).Value = entidad.ID_SERIE;
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

    }
}
