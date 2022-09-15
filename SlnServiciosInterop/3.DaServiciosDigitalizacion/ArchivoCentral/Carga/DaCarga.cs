using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Carga; 
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
                    using (var bulkCopy = new OracleBulkCopy(cn, OracleBulkCopyOptions.Default)) //OracleBulkCopyOptions.Default  //UseInternalTransaction
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
                        //  SqlBulkCopyOptions.KeepNulls
                        //bulkCopy.BulkCopyOptions = OracleBulkCopyOptions.UseInternalTransaction;
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
            cmd.CommandText = AppSettingsHelper.PackCargaCons + ".PRC_CDAFORMATO_LISTAR";
            cmd.Parameters.Add("XIN_ID_TABLA", validarNulo(objtabla.ID_TABLA));
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
        public void Carga_CamposListar(enControlCarga entidad, ref enAuditoria auditoria)
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

        public List<enCampo> Seccion_Listar(enCampo objcampo, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enCampo> lista = new List<enCampo>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.Pack_AdminConsulta + ".PRC_CDACAMPO_LISTAR";
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

                                //if (!drReader.IsDBNull(intIdSeccion)) temp.ID_SECCION = int.Parse(arrResult[intIdSeccion].ToString());
                                //if (!drReader.IsDBNull(intDescCorta)) temp.DES_CORTA_SECCION = arrResult[intDescCorta].ToString();
                                //if (!drReader.IsDBNull(intDescLarga)) temp.DES_LARGA_SECCION = arrResult[intDescLarga].ToString();
                                //if (!drReader.IsDBNull(intFlgEstado)) temp.FLG_ESTADO = arrResult[intFlgEstado].ToString();
                                //if (!drReader.IsDBNull(intUsuCreacion)) temp.USU_CREACION = arrResult[intUsuCreacion].ToString();
                                //if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                //if (!drReader.IsDBNull(intUsuMoficacion)) temp.USU_MODIFICACION = arrResult[intUsuMoficacion].ToString();
                                //if (!drReader.IsDBNull(intfecMoficacion)) temp.STR_FEC_MODIFICACION = arrResult[intfecMoficacion].ToString();

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

    }
}
