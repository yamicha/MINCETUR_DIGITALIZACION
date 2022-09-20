using System;
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

namespace DaServiciosDigitalizacion.Archivo_Central.Carga
{
    public class DaCarga : daBase
    {
        public DaCarga(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }
        public void Registrar_Carga(string COD_TABLA_TEMPORAL, DataTable dt, string[] col, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            try
            {
                using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
                {
                    cn.Open();
                    using (var bulkCopy = new OracleBulkCopy(cn, OracleBulkCopyOptions.Default)) //
                    {
                        bulkCopy.DestinationTableName = COD_TABLA_TEMPORAL;
                        // set the destination table name  
                        foreach (string ff in col)
                        {
                            if (ff != null)
                            {
                                OracleBulkCopyColumnMapping mapMumber = new OracleBulkCopyColumnMapping(ff, ff);
                                bulkCopy.ColumnMappings.Add(mapMumber);
                            }
                        }
                        bulkCopy.BulkCopyTimeout = 1200;
                        bulkCopy.WriteToServer(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
            }
        }
        public enTabla Carga_TablaListarUno(enTabla objtabla, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            enTabla temp = null;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackCargaCons, "PRC_CDAFORMATO_LISTAR");
            cmd.Parameters.Add("XIN_ID_TABLA", validarNulo(objtabla.ID_TABLA));
            cmd.Parameters.Add("XOUT_CURSOR", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
            cmd.Parameters.Add(new OracleParameter("XOUT_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(new OracleParameter("XOUT_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                try
                {
                    cmd.Connection = cn;
                    using (OracleDataReader drReader = cmd.ExecuteReader())
                    {
                        int PO_VALIDO = int.Parse(cmd.Parameters["XOUT_VALIDO"].Value.ToString());
                        string PO_MENSAJE = cmd.Parameters["XOUT_MENSAJE"].Value.ToString();
                        if (PO_VALIDO == 0)
                            auditoria.Rechazar(PO_MENSAJE);
                        object[] arrResult = null;
                        if (drReader.HasRows)
                        {
                            //enSeccion temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdtabla = drReader.GetOrdinal("ID_TABLA");
                            int intDesTabla = drReader.GetOrdinal("DES_TABLA");
                            int intCodTablaTemporal = drReader.GetOrdinal("COD_TABLA_TEMPORAL");
                            int intCodTablaOficial = drReader.GetOrdinal("COD_TABLA_OFICIAL");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enTabla();
                                if (!drReader.IsDBNull(intIdtabla)) temp.ID_TABLA = int.Parse(arrResult[intIdtabla].ToString());
                                if (!drReader.IsDBNull(intDesTabla)) temp.DESCRIPCION_TABLA = arrResult[intDesTabla].ToString();
                                if (!drReader.IsDBNull(intCodTablaTemporal)) temp.COD_TABLA_TEMPORAL = arrResult[intCodTablaTemporal].ToString();
                                if (!drReader.IsDBNull(intCodTablaOficial)) temp.COD_TABLA_OFICIAL = arrResult[intCodTablaOficial].ToString();
                            }
                            drReader.Close();
                        }
                    }
                    //--------------------------------
                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                    temp = new enTabla();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return temp;
        }
        public void Carga_ControlCargaInsertar(enControlCarga entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackCargaMant, "PROC_CDACONTROLCARGA_INSERTAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_TABLA", OracleDbType.Int32)).Value = entidad.ID_TABLA;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_USUARIO", OracleDbType.Int32)).Value = entidad.ID_USUARIO;
                cmd.Parameters.Add(new OracleParameter("XIN_NRO_REGISTROS", OracleDbType.Int32)).Value = entidad.NRO_REGISTROS;
                cmd.Parameters.Add(new OracleParameter("XIN_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.USU_CREACION;
                cmd.Parameters.Add(new OracleParameter("XIN_IP_CREACION", OracleDbType.Varchar2)).Value = entidad.IP_MODIFICACION;
                cmd.Parameters.Add(new OracleParameter("XOUT_ID_CONTROL_CARGA", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("XOUT_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("XOUT_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    dr = cmd.ExecuteReader();
                    string PO_ID_CONTROL_CARGA = cmd.Parameters["XOUT_ID_CONTROL_CARGA"].Value.ToString();
                    string PO_VALIDO = cmd.Parameters["XOUT_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["XOUT_MENSAJE"].Value.ToString();
                    if (PO_VALIDO == "0")
                        auditoria.Rechazar(PO_MENSAJE);
                    else
                        auditoria.Objeto = PO_ID_CONTROL_CARGA;
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
        public List<enCampo> Carga_CamposListar(enCampo objcampo, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enCampo> lista = new List<enCampo>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText =string.Format("{0}.{1}", AppSettingsHelper.PackCargaCons, "PRC_CDACAMPO_LISTAR");
            cmd.Parameters.Add("XIN_ID_TABLA", validarNulo(objcampo.ID_TABLA));
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
                            enCampo temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdCampo = drReader.GetOrdinal("ID_CAMPO");
                            int intIdTabla = drReader.GetOrdinal("ID_TABLA");
                            int intCodCampo = drReader.GetOrdinal("COD_CAMPO");
                            int intDesCampo = drReader.GetOrdinal("DES_CAMPO");
                            int intNroCampo = drReader.GetOrdinal("NRO_CAMPO");
                            int intTipoDato = drReader.GetOrdinal("TIPO_DATO");
                            int intTipo = drReader.GetOrdinal("TIPO");
                            int intLogintud = drReader.GetOrdinal("LONGITUD");
                            int intDatoEjemplo = drReader.GetOrdinal("DATO_EJEMPLO");
                            int intObligatorio = drReader.GetOrdinal("OBLIGATORIO");
                            int intTransOfic = drReader.GetOrdinal("TRANSF_OFIC");
                            int intTransOrig = drReader.GetOrdinal("TRANSF_ORIG");
                            int intTransValid = drReader.GetOrdinal("TRANSF_VALID");
                            int intFlgcalsific = drReader.GetOrdinal("FLG_CLASIFICACION");
                            int intAutoincrement = drReader.GetOrdinal("FLG_AUTOINCREMENT");
                            int intQueryCampo = drReader.GetOrdinal("QUERY_CAMPO");
                            int intTipoCampo = drReader.GetOrdinal("TIPO_CAMPO");
                            int intFlgValidaPk = drReader.GetOrdinal("FLG_VALIDA_PK");

                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enCampo();

                                if (!drReader.IsDBNull(intIdCampo)) temp.ID_CAMPO = int.Parse(arrResult[intIdCampo].ToString());
                                if (!drReader.IsDBNull(intIdTabla)) temp.ID_TABLA = int.Parse(arrResult[intIdTabla].ToString());
                                if (!drReader.IsDBNull(intCodCampo)) temp.COD_CAMPO = arrResult[intCodCampo].ToString();
                                if (!drReader.IsDBNull(intDesCampo)) temp.DES_CAMPO = arrResult[intDesCampo].ToString();
                                if (!drReader.IsDBNull(intNroCampo)) temp.NRO_CAMPO = int.Parse(arrResult[intNroCampo].ToString());
                                if (!drReader.IsDBNull(intTipoDato)) temp.TIPO_DATO = arrResult[intTipoDato].ToString();
                                if (!drReader.IsDBNull(intTipo)) temp.TIPO = arrResult[intTipo].ToString();
                                if (!drReader.IsDBNull(intLogintud)) temp.LONGITUD = int.Parse(arrResult[intLogintud].ToString());
                                if (!drReader.IsDBNull(intDatoEjemplo)) temp.DATO_EJEMPLO = arrResult[intDatoEjemplo].ToString();
                                if (!drReader.IsDBNull(intObligatorio)) temp.OBLIGATORIO = arrResult[intObligatorio].ToString();
                                if (!drReader.IsDBNull(intTransOfic)) temp.TRANSF_OFIC = arrResult[intTransOfic].ToString();
                                if (!drReader.IsDBNull(intTransOrig)) temp.TRANSF_ORIG = arrResult[intTransOrig].ToString();
                                if (!drReader.IsDBNull(intTransValid)) temp.TRANSF_VALID = arrResult[intTransValid].ToString();
                                if (!drReader.IsDBNull(intFlgcalsific)) temp.FLG_CLASIFICACION = arrResult[intFlgcalsific].ToString();
                                if (!drReader.IsDBNull(intAutoincrement)) temp.FLG_AUTOINCREMENT = arrResult[intAutoincrement].ToString();
                                if (!drReader.IsDBNull(intQueryCampo)) temp.QUERY_CAMPO = arrResult[intQueryCampo].ToString();
                                if (!drReader.IsDBNull(intTipoCampo)) temp.TIPO_CAMPO = arrResult[intTipoCampo].ToString();
                                if (!drReader.IsDBNull(intFlgValidaPk)) temp.FLG_VALIDA_PK = arrResult[intFlgValidaPk].ToString();
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
                    lista = new List<enCampo>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }
        public void Ejecutar_Query(string _Query, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand(_Query, cn);
                try
                {
                    string InId = cmd.ExecuteScalar().ToString();
                    if (!string.IsNullOrEmpty(InId))
                    {
                        long ID_DOCUMENTO = 0;
                        long.TryParse(InId, out ID_DOCUMENTO);
                        auditoria.Objeto = ID_DOCUMENTO;
                    }
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

        public void Carga_Validar(long ID_CONTROL_CARGA, long ID_TABLA, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackCargaMant, "PROC_CDACARGA_VALIDAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_CONTROL_CARGA", OracleDbType.Int32)).Value = ID_CONTROL_CARGA;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_TABLA", OracleDbType.Int32)).Value = ID_TABLA;
                try
                {
                    cmd.ExecuteNonQuery();
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

        public enControlCarga Carga_ControlCargaListarUno(long ID_CONTROLCARGA, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            enControlCarga temp = null;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackCargaCons, "PRC_CDACONTROLCARGA_LISTAR");
            cmd.Parameters.Add("XIN_ID_CONTROL_CARGA", ID_CONTROLCARGA);
            cmd.Parameters.Add("XOUT_CURSOR", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
            cmd.Parameters.Add(new OracleParameter("XOUT_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(new OracleParameter("XOUT_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                try
                {
                    cmd.Connection = cn;
                    using (OracleDataReader drReader = cmd.ExecuteReader())
                    {
                        int PO_VALIDO = int.Parse(cmd.Parameters["XOUT_VALIDO"].Value.ToString());
                        string PO_MENSAJE = cmd.Parameters["XOUT_MENSAJE"].Value.ToString();
                        if (PO_VALIDO == 0)
                            auditoria.Rechazar(PO_MENSAJE);
                        object[] arrResult = null;
                        if (drReader.HasRows)
                        {
                            //enSeccion temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdControlCarga = drReader.GetOrdinal("ID_CONTROL_CARGA");
                            int intIdtabla = drReader.GetOrdinal("ID_TABLA");
                            int intIusuario = drReader.GetOrdinal("ID_USUARIO");
                            int intNroRegistro = drReader.GetOrdinal("NRO_REGISTROS");
                            int intFlgCarga = drReader.GetOrdinal("FLG_CARGA");
                            int intStrFlgCarga = drReader.GetOrdinal("STR_FLG_CARGA");
                            int intUsuCreacion = drReader.GetOrdinal("USU_CREACION");
                            int intStrCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intUsuModificion = drReader.GetOrdinal("USU_MODIFICACION");
                            int intStrFecModificacion = drReader.GetOrdinal("STR_FEC_MODIFICACION");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enControlCarga();
                                if (!drReader.IsDBNull(intIdControlCarga)) temp.ID_CONTROL_CARGA = int.Parse(arrResult[intIdControlCarga].ToString());
                                if (!drReader.IsDBNull(intIdtabla)) temp.ID_TABLA = int.Parse(arrResult[intIdtabla].ToString());
                                if (!drReader.IsDBNull(intIusuario)) temp.ID_USUARIO = int.Parse(arrResult[intIusuario].ToString());
                                if (!drReader.IsDBNull(intNroRegistro)) temp.NRO_REGISTROS = int.Parse(arrResult[intNroRegistro].ToString());
                                if (!drReader.IsDBNull(intFlgCarga)) temp.STR_FLG_CARGA = arrResult[intFlgCarga].ToString();
                                if (!drReader.IsDBNull(intUsuCreacion)) temp.USU_CREACION = arrResult[intUsuCreacion].ToString();
                                if (!drReader.IsDBNull(intStrCreacion)) temp.STR_FEC_CREACION = arrResult[intStrCreacion].ToString();
                                if (!drReader.IsDBNull(intUsuModificion)) temp.USU_MODIFICACION = arrResult[intUsuModificion].ToString();
                                if (!drReader.IsDBNull(intStrFecModificacion)) temp.STR_FEC_MODIFICACION = arrResult[intStrFecModificacion].ToString();
                            }
                            drReader.Close();
                        }
                    }
                    //--------------------------------
                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                    temp = new enControlCarga();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return temp;
        }

        public List<enErrorCarga> Carga_ErrorCargaListar(long ID_CONTROLCARGA, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enErrorCarga> Lista = new List<enErrorCarga>(); 
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackCargaCons, "PRC_CDAERRORCARGA_LISTAR");
            cmd.Parameters.Add("XIN_ID_CONTROL_CARGA", ID_CONTROLCARGA);
            cmd.Parameters.Add("XOUT_CURSOR", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
            cmd.Parameters.Add(new OracleParameter("XOUT_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(new OracleParameter("XOUT_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                try
                {
                    cmd.Connection = cn;
                    using (OracleDataReader drReader = cmd.ExecuteReader())
                    {
                        int PO_VALIDO = int.Parse(cmd.Parameters["XOUT_VALIDO"].Value.ToString());
                        string PO_MENSAJE = cmd.Parameters["XOUT_MENSAJE"].Value.ToString();
                        if (PO_VALIDO == 0)
                            auditoria.Rechazar(PO_MENSAJE);
                        object[] arrResult = null;
                        if (drReader.HasRows)
                        {
                            enErrorCarga temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdControlCarga = drReader.GetOrdinal("ID_CONTROL_CARGA");
                            int intNrolinea = drReader.GetOrdinal("NRO_LINEA");
                            int intDesError = drReader.GetOrdinal("DES_ERROR");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enErrorCarga();
                                if (!drReader.IsDBNull(intIdControlCarga)) temp.ID_CONTROL_CARGA = int.Parse(arrResult[intIdControlCarga].ToString());
                                if (!drReader.IsDBNull(intNrolinea)) temp.NRO_LINEA = int.Parse(arrResult[intNrolinea].ToString());
                                if (!drReader.IsDBNull(intDesError)) temp.DES_ERROR = arrResult[intDesError].ToString();
                                Lista.Add(temp); 
                            }
                            drReader.Close();
                        }
                    }
                    //--------------------------------
                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                    Lista = new List<enErrorCarga>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return Lista;
        }
    }
}
