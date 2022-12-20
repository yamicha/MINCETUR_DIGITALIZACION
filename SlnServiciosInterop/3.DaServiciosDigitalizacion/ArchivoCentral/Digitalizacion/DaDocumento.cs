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
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;

namespace DaServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
    public class DaDocumento : daBase
    {
        public DaDocumento(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
        }
        public List<enDocumentoTemporal> DocumentoTemporal_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enDocumentoTemporal> lista = new List<enDocumentoTemporal>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PRC_CDADOC_TEMP_PAGINACION");
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
                            enDocumentoTemporal temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdDocumento = drReader.GetOrdinal("ID_DOCUMENTO");
                            int intIdcontrolCarga = drReader.GetOrdinal("ID_CONTROL_CARGA");
                            int intNroLinea = drReader.GetOrdinal("NRO_LINEA");
                            int intIdFondo = drReader.GetOrdinal("ID_FONDO");
                            int intDesFondo = drReader.GetOrdinal("DES_FONDO");
                            int intIdSeccion = drReader.GetOrdinal("ID_SECCION");
                            int intDesSeccion = drReader.GetOrdinal("DES_LARGA_SECCION");
                            int intIdSerie = drReader.GetOrdinal("ID_SERIE");
                            int intDesSerie = drReader.GetOrdinal("DES_SERIE");
                            int intNomDocumento = drReader.GetOrdinal("NOM_DOCUMENTO");
                            int intDescripcion = drReader.GetOrdinal("DESCRIPCION");
                            int intAnio = drReader.GetOrdinal("ANIO"); 
                            int intFolios = drReader.GetOrdinal("FOLIOS");
                            int intImagen = drReader.GetOrdinal("IMAGEN");
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intUsuariocreacion = drReader.GetOrdinal("STR_USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intUsuModific = drReader.GetOrdinal("USU_MODIFICACION");
                            int intFecModific = drReader.GetOrdinal("STR_FEC_MODIFICACION");
                            int intFlgRepetido = drReader.GetOrdinal("FLG_REPETIDO");
                            

                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumentoTemporal();
                                if (!drReader.IsDBNull(intIdDocumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDocumento].ToString());
                                if (!drReader.IsDBNull(intIdcontrolCarga)) temp.ID_CONTROL_CARGA = long.Parse(arrResult[intIdcontrolCarga].ToString());
                                if (!drReader.IsDBNull(intNroLinea)) temp.NRO_LINEA = arrResult[intNroLinea].ToString();
                                if (!drReader.IsDBNull(intIdFondo)) temp.ID_FONDO = arrResult[intIdFondo].ToString();
                                if (!drReader.IsDBNull(intDesFondo)) temp.DES_FONDO = arrResult[intDesFondo].ToString();
                                if (!drReader.IsDBNull(intIdSeccion)) temp.ID_SECCION = arrResult[intIdSeccion].ToString();
                                if (!drReader.IsDBNull(intFlgRepetido)) temp.FLG_REPETIDO = int.Parse(arrResult[intFlgRepetido].ToString());
                                if (!drReader.IsDBNull(intDesSeccion)) temp.DES_LARGA_SECCION = arrResult[intDesSeccion].ToString();
                                if (!drReader.IsDBNull(intIdSerie)) temp.ID_SERIE = arrResult[intIdSerie].ToString();
                                if (!drReader.IsDBNull(intDesSerie)) temp.DES_SERIE = arrResult[intDesSerie].ToString();
                                if (!drReader.IsDBNull(intDescripcion)) temp.DESCRIPCION = arrResult[intDescripcion].ToString();
                                if (!drReader.IsDBNull(intNomDocumento)) temp.NOM_DOCUMENTO = arrResult[intNomDocumento].ToString();
                                if (!drReader.IsDBNull(intAnio)) temp.ANIO = arrResult[intAnio].ToString();
                                if (!drReader.IsDBNull(intFolios)) temp.FOLIOS = arrResult[intFolios].ToString();
                                if (!drReader.IsDBNull(intImagen)) temp.IMAGEN = arrResult[intImagen].ToString();
                                if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
                                if (!drReader.IsDBNull(intUsuariocreacion)) temp.USU_CREACION = arrResult[intUsuariocreacion].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intUsuModific)) temp.USU_MODIFICACION = arrResult[intUsuModific].ToString();
                                if (!drReader.IsDBNull(intFecModific)) temp.STR_FEC_MODIFICACION = arrResult[intFecModific].ToString();
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
                    lista = new List<enDocumentoTemporal>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }

        public List<enDocumento> Documento_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enDocumento> lista = new List<enDocumento>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PRC_CDADOC_PAGINACION");
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
                            enDocumento temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdDocumento = drReader.GetOrdinal("ID_DOCUMENTO");
                            int intIdcontrolCarga = drReader.GetOrdinal("ID_CONTROL_CARGA");
                            int intIdestadoDoc = drReader.GetOrdinal("ID_ESTADO_DOCUMENTO");
                            int intDescEstado = drReader.GetOrdinal("DESCRIPCION_ESTADO");
                            int intIdDocAsignado = drReader.GetOrdinal("ID_DOCUMENTO_ASIGNADO");
                            int intIdUsuario = drReader.GetOrdinal("ID_USUARIO");
                            int intNomUsuario = drReader.GetOrdinal("NOMBRE_USUARIO");
                            int intIdLote = drReader.GetOrdinal("ID_LOTE");
                            int intIdFondo = drReader.GetOrdinal("ID_FONDO");
                            int intDesFondo = drReader.GetOrdinal("DES_FONDO");
                            int intIdSeccion = drReader.GetOrdinal("ID_SECCION");
                            int intDesSeccion = drReader.GetOrdinal("DES_LARGA_SECCION");
                            int intIdSerie = drReader.GetOrdinal("ID_SERIE");
                            int intDesSerie = drReader.GetOrdinal("DES_SERIE");
                            int intNomDocumento = drReader.GetOrdinal("NOM_DOCUMENTO");
                            int intDescripcion = drReader.GetOrdinal("DESCRIPCION");
                            int intAnio = drReader.GetOrdinal("ANIO");
                            int intFolios = drReader.GetOrdinal("FOLIOS");
                            int intImagen = drReader.GetOrdinal("IMAGEN");
                            int intIdlaser = drReader.GetOrdinal("ID_LASERFICHE");
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intUsuariocreacion = drReader.GetOrdinal("STR_USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intUsuModific = drReader.GetOrdinal("USU_MODIFICACION");
                            int intFecModific = drReader.GetOrdinal("STR_FEC_MODIFICACION");
                            int intNroReprocesados = drReader.GetOrdinal("NRO_REPROCESADOS");
                            int intNroLote = drReader.GetOrdinal("NRO_LOTE");

                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumento();

                                if (!drReader.IsDBNull(intIdDocumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDocumento].ToString());
                                if (!drReader.IsDBNull(intIdcontrolCarga)) temp.ID_CONTROL_CARGA = long.Parse(arrResult[intIdcontrolCarga].ToString());
                                if (!drReader.IsDBNull(intIdestadoDoc)) temp.ID_ESTADO_DOCUMENTO = long.Parse(arrResult[intIdestadoDoc].ToString());
                                if (!drReader.IsDBNull(intDescEstado)) temp.DESCRIPCION_ESTADO = arrResult[intDescEstado].ToString();
                                if (!drReader.IsDBNull(intIdDocAsignado)) temp.ID_DOCUMENTO_ASIGNADO = long.Parse(arrResult[intIdDocAsignado].ToString());
                                if (!drReader.IsDBNull(intIdUsuario)) temp.ID_USUARIO = long.Parse(arrResult[intIdUsuario].ToString());
                                if (!drReader.IsDBNull(intNomUsuario)) temp.NOMBRE_USUARIO = arrResult[intNomUsuario].ToString();
                                if (!drReader.IsDBNull(intIdLote)) temp.ID_LOTE = long.Parse(arrResult[intIdLote].ToString());
                                if (!drReader.IsDBNull(intIdFondo)) temp.ID_FONDO = long.Parse(arrResult[intIdFondo].ToString());
                                if (!drReader.IsDBNull(intDesFondo)) temp.DES_FONDO = arrResult[intDesFondo].ToString();
                                if (!drReader.IsDBNull(intIdSeccion)) temp.ID_SECCION = long.Parse(arrResult[intIdSeccion].ToString());
                                if (!drReader.IsDBNull(intDesSeccion)) temp.DES_LARGA_SECCION = arrResult[intDesSeccion].ToString();
                                if (!drReader.IsDBNull(intIdSerie)) temp.ID_SERIE = long.Parse(arrResult[intIdSerie].ToString());
                                if (!drReader.IsDBNull(intDesSerie)) temp.DES_SERIE = arrResult[intDesSerie].ToString();
                                if (!drReader.IsDBNull(intNomDocumento)) temp.NOM_DOCUMENTO = arrResult[intNomDocumento].ToString();
                                if (!drReader.IsDBNull(intDescripcion)) temp.DESCRIPCION = arrResult[intDescripcion].ToString();
                                if (!drReader.IsDBNull(intAnio)) temp.ANIO = long.Parse(arrResult[intAnio].ToString());
                                if (!drReader.IsDBNull(intFolios)) temp.FOLIOS = long.Parse(arrResult[intFolios].ToString());
                                if(!drReader.IsDBNull(intImagen)) temp.IMAGEN = long.Parse(arrResult[intImagen].ToString());
                                if (!drReader.IsDBNull(intNroReprocesados)) temp.NRO_REPROCESADOS = long.Parse(arrResult[intNroReprocesados].ToString());
                                if (!drReader.IsDBNull(intIdlaser)) temp.ID_LASERFICHE = long.Parse(arrResult[intIdlaser].ToString());
                                if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
                                if (!drReader.IsDBNull(intUsuariocreacion)) temp.USU_CREACION = arrResult[intUsuariocreacion].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intUsuModific)) temp.USU_MODIFICACION = arrResult[intUsuModific].ToString();
                                if (!drReader.IsDBNull(intFecModific)) temp.STR_FEC_MODIFICACION = arrResult[intFecModific].ToString();
                                if (!drReader.IsDBNull(intNroLote)) temp.NRO_LOTE = arrResult[intNroLote].ToString();
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
                    lista = new List<enDocumento>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }

        public List<enDocumento_Proceso> DocumentoProceso_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enDocumento_Proceso> lista = new List<enDocumento_Proceso>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PRC_CDADOCPROCESO_PAGINACION");
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
                            enDocumento_Proceso temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdDocProceso = drReader.GetOrdinal("ID_DOCUMENTO_PROCESO");
                            int intIdcontrolCarga = drReader.GetOrdinal("ID_DOCUMENTO_ASIGNADO");
                            int intIdDocumento = drReader.GetOrdinal("ID_DOCUMENTO");
                            int intIdestadoDoc = drReader.GetOrdinal("ID_ESTADO_DOCUMENTO");
                            int intDescEstado = drReader.GetOrdinal("DESCRIPCION_ESTADO"); 
                            int intNroLote = drReader.GetOrdinal("NRO_LOTE");
                            int intDesFondo = drReader.GetOrdinal("DES_FONDO");
                            int intDesSeccion = drReader.GetOrdinal("DES_LARGA_SECCION");
                            int intHoraInicio= drReader.GetOrdinal("HORA_INICIO");
                            int intHoraFin = drReader.GetOrdinal("HORA_FIN");
                            int intDesSerie = drReader.GetOrdinal("DES_SERIE");
                            int intNomDocumento = drReader.GetOrdinal("NOM_DOCUMENTO");     
                            int intIdlaser = drReader.GetOrdinal("ID_LASERFICHE");
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intIdUsuario = drReader.GetOrdinal("ID_USU_CREACION");
                            int intUsuariocreacion = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
 
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumento_Proceso();
                                if (!drReader.IsDBNull(intIdDocProceso)) temp.ID_DOCUMENTO_PROCESO = long.Parse(arrResult[intIdDocProceso].ToString());
                                if (!drReader.IsDBNull(intIdDocumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDocumento].ToString());
                                if (!drReader.IsDBNull(intIdestadoDoc)) temp.ID_ESTADO_DOCUMENTO = long.Parse(arrResult[intIdestadoDoc].ToString());
                                if (!drReader.IsDBNull(intDescEstado)) temp.DESCRIPCION_ESTADO = arrResult[intDescEstado].ToString();
                                if (!drReader.IsDBNull(intIdUsuario)) temp.ID_USU_CREACION = long.Parse(arrResult[intIdUsuario].ToString());
                                if (!drReader.IsDBNull(intNroLote)) temp.NRO_LOTE = arrResult[intNroLote].ToString();
                                if (!drReader.IsDBNull(intDesFondo)) temp.DES_FONDO = arrResult[intDesFondo].ToString();
                                if (!drReader.IsDBNull(intDesSeccion)) temp.DES_LARGA_SECCION = arrResult[intDesSeccion].ToString();
                                if (!drReader.IsDBNull(intDesSerie)) temp.DES_SERIE = arrResult[intDesSerie].ToString();
                                if (!drReader.IsDBNull(intNomDocumento)) temp.NOM_DOCUMENTO = arrResult[intNomDocumento].ToString();
                                if (!drReader.IsDBNull(intIdlaser)) temp.ID_LASERFICHE = long.Parse(arrResult[intIdlaser].ToString());
                                if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
                                if (!drReader.IsDBNull(intHoraInicio)) temp.HORA_INICIO = arrResult[intHoraInicio].ToString();
                                if (!drReader.IsDBNull(intHoraFin)) temp.HORA_FIN = arrResult[intHoraFin].ToString();
                                if (!drReader.IsDBNull(intUsuariocreacion)) temp.USU_CREACION = arrResult[intUsuariocreacion].ToString();
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

        public HashSet<enDocumento> Documento_Exportar(string @WHERE, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            HashSet<enDocumento> lista = new HashSet<enDocumento>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PRC_CDADOC_EXPORTAR");
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
                            enDocumento temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdDocumento = drReader.GetOrdinal("ID_DOCUMENTO");
                            int intIdcontrolCarga = drReader.GetOrdinal("ID_CONTROL_CARGA");
                            int intIdestadoDoc = drReader.GetOrdinal("ID_ESTADO_DOCUMENTO");
                            int intDescEstado = drReader.GetOrdinal("DESCRIPCION_ESTADO");
                            int intIdDocAsignado = drReader.GetOrdinal("ID_DOCUMENTO_ASIGNADO");
                            int intIdUsuario = drReader.GetOrdinal("ID_USUARIO");
                            int intNomUsuario = drReader.GetOrdinal("NOMBRE_USUARIO");
                            int intIdLote = drReader.GetOrdinal("ID_LOTE");
                            int intIdFondo = drReader.GetOrdinal("ID_FONDO");
                            int intDesFondo = drReader.GetOrdinal("DES_FONDO");
                            int intIdSeccion = drReader.GetOrdinal("ID_SECCION");
                            int intDesSeccion = drReader.GetOrdinal("DES_LARGA_SECCION");
                            int intIdSerie = drReader.GetOrdinal("ID_SERIE");
                            int intDesSerie = drReader.GetOrdinal("DES_SERIE");
                            int intNomDocumento = drReader.GetOrdinal("NOM_DOCUMENTO");
                            int intDescripcion = drReader.GetOrdinal("DESCRIPCION");
                            int intAnio = drReader.GetOrdinal("ANIO");
                            int intFolios = drReader.GetOrdinal("FOLIOS");
                            int intIdlaser = drReader.GetOrdinal("ID_LASERFICHE");
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intUsuariocreacion = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intUsuModific = drReader.GetOrdinal("USU_MODIFICACION");
                            int intFecModific = drReader.GetOrdinal("STR_FEC_MODIFICACION");
                            int intNroReprocesados = drReader.GetOrdinal("NRO_REPROCESADOS");


                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumento();

                                if (!drReader.IsDBNull(intIdDocumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDocumento].ToString());
                                if (!drReader.IsDBNull(intIdcontrolCarga)) temp.ID_CONTROL_CARGA = long.Parse(arrResult[intIdcontrolCarga].ToString());
                                if (!drReader.IsDBNull(intIdestadoDoc)) temp.ID_ESTADO_DOCUMENTO = long.Parse(arrResult[intIdestadoDoc].ToString());
                                if (!drReader.IsDBNull(intDescEstado)) temp.DESCRIPCION_ESTADO = arrResult[intDescEstado].ToString();
                                if (!drReader.IsDBNull(intIdDocAsignado)) temp.ID_DOCUMENTO_ASIGNADO = long.Parse(arrResult[intIdDocAsignado].ToString());
                                if (!drReader.IsDBNull(intIdUsuario)) temp.ID_USUARIO = long.Parse(arrResult[intIdUsuario].ToString());
                                if (!drReader.IsDBNull(intNomUsuario)) temp.NOMBRE_USUARIO = arrResult[intNomUsuario].ToString();
                                if (!drReader.IsDBNull(intIdLote)) temp.ID_LOTE = long.Parse(arrResult[intIdLote].ToString());
                                if (!drReader.IsDBNull(intIdFondo)) temp.ID_FONDO = long.Parse(arrResult[intIdFondo].ToString());
                                if (!drReader.IsDBNull(intDesFondo)) temp.DES_FONDO = arrResult[intDesFondo].ToString();
                                if (!drReader.IsDBNull(intIdSeccion)) temp.ID_SECCION = long.Parse(arrResult[intIdSeccion].ToString());
                                if (!drReader.IsDBNull(intDesSeccion)) temp.DES_LARGA_SECCION = arrResult[intDesSeccion].ToString();
                                if (!drReader.IsDBNull(intIdSerie)) temp.ID_SERIE = long.Parse(arrResult[intIdSerie].ToString());
                                if (!drReader.IsDBNull(intDesSerie)) temp.DES_SERIE = arrResult[intDesSerie].ToString();
                                if (!drReader.IsDBNull(intNomDocumento)) temp.NOM_DOCUMENTO = arrResult[intNomDocumento].ToString();
                                if (!drReader.IsDBNull(intDescripcion)) temp.DESCRIPCION = arrResult[intDescripcion].ToString();
                                if (!drReader.IsDBNull(intAnio)) temp.ANIO = long.Parse(arrResult[intAnio].ToString());
                                if (!drReader.IsDBNull(intFolios)) temp.FOLIOS = long.Parse(arrResult[intFolios].ToString());
                                if (!drReader.IsDBNull(intNroReprocesados)) temp.NRO_REPROCESADOS = long.Parse(arrResult[intNroReprocesados].ToString());
                                if (!drReader.IsDBNull(intIdlaser)) temp.ID_LASERFICHE = long.Parse(arrResult[intIdlaser].ToString());
                                if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
                                if (!drReader.IsDBNull(intUsuariocreacion)) temp.USU_CREACION = arrResult[intUsuariocreacion].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intUsuModific)) temp.USU_MODIFICACION = arrResult[intUsuModific].ToString();
                                if (!drReader.IsDBNull(intFecModific)) temp.STR_FEC_MODIFICACION = arrResult[intFecModific].ToString();
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
                    lista = new HashSet<enDocumento>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }

        public enDocumento Documento_ListarUno(enDocumento entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            enDocumento temp = null;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackDigitalCons + ".PRC_CDADOC_LISTARUNO";
            cmd.Parameters.Add("X_ID_DOCUMENTO", validarNulo(entidad.ID_DOCUMENTO));
            cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add("X_RESULTADO", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
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
                            int intIdDocumento = drReader.GetOrdinal("ID_DOCUMENTO");
                            int intIdcontrolCarga = drReader.GetOrdinal("ID_CONTROL_CARGA");
                            int intIdestadoDoc = drReader.GetOrdinal("ID_ESTADO_DOCUMENTO");
                            int intDescEstado = drReader.GetOrdinal("DESCRIPCION_ESTADO");
                            int intIdDocAsignado = drReader.GetOrdinal("ID_DOCUMENTO_ASIGNADO");
                            int intIdFondo = drReader.GetOrdinal("ID_FONDO");
                            int intDesFondo = drReader.GetOrdinal("DES_FONDO");
                            int intIdSeccion = drReader.GetOrdinal("ID_SECCION");
                            int intDesSeccion = drReader.GetOrdinal("DES_LARGA_SECCION");
                            int intIdSerie = drReader.GetOrdinal("ID_SERIE");
                            int intDesSerie = drReader.GetOrdinal("DES_SERIE");
                            int intNomDocumento = drReader.GetOrdinal("NOM_DOCUMENTO");
                            int intDescripcion = drReader.GetOrdinal("DESCRIPCION");
                            int intAnio = drReader.GetOrdinal("ANIO");
                            int intFolios = drReader.GetOrdinal("FOLIOS");
                            int intImagen = drReader.GetOrdinal("IMAGEN");
                            int intIdlaser = drReader.GetOrdinal("ID_LASERFICHE");
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intusuAsignado = drReader.GetOrdinal("NOMBRE_USUARIO");
                            
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumento();
                                if (!drReader.IsDBNull(intIdDocumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDocumento].ToString());
                                if (!drReader.IsDBNull(intIdcontrolCarga)) temp.ID_CONTROL_CARGA = long.Parse(arrResult[intIdcontrolCarga].ToString());
                                if (!drReader.IsDBNull(intIdestadoDoc)) temp.ID_ESTADO_DOCUMENTO = long.Parse(arrResult[intIdestadoDoc].ToString());
                                if (!drReader.IsDBNull(intIdDocAsignado)) temp.ID_DOCUMENTO_ASIGNADO = long.Parse(arrResult[intIdDocAsignado].ToString());
                                if (!drReader.IsDBNull(intDescEstado)) temp.DESCRIPCION_ESTADO = arrResult[intDescEstado].ToString();
                                if (!drReader.IsDBNull(intIdFondo)) temp.ID_FONDO = long.Parse(arrResult[intIdFondo].ToString());
                                if (!drReader.IsDBNull(intDesFondo)) temp.DES_FONDO = arrResult[intDesFondo].ToString();
                                if (!drReader.IsDBNull(intIdSeccion)) temp.ID_SECCION = long.Parse(arrResult[intIdSeccion].ToString());
                                if (!drReader.IsDBNull(intDesSeccion)) temp.DES_LARGA_SECCION = arrResult[intDesSeccion].ToString();
                                if (!drReader.IsDBNull(intIdSerie)) temp.ID_SERIE = long.Parse(arrResult[intIdSerie].ToString());
                                if (!drReader.IsDBNull(intDesSerie)) temp.DES_SERIE = arrResult[intDesSerie].ToString();
                                if (!drReader.IsDBNull(intNomDocumento)) temp.NOM_DOCUMENTO = arrResult[intNomDocumento].ToString();
                                if (!drReader.IsDBNull(intDescripcion)) temp.DESCRIPCION = arrResult[intDescripcion].ToString();
                                if (!drReader.IsDBNull(intAnio)) temp.ANIO = long.Parse(arrResult[intAnio].ToString());
                                if (!drReader.IsDBNull(intFolios)) temp.FOLIOS = long.Parse(arrResult[intFolios].ToString());
                                if (!drReader.IsDBNull(intImagen)) temp.IMAGEN = long.Parse(arrResult[intImagen].ToString());
                                if (!drReader.IsDBNull(intIdlaser)) temp.ID_LASERFICHE = long.Parse(arrResult[intIdlaser].ToString());
                                if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
                                if (!drReader.IsDBNull(intusuAsignado)) temp.NOMBRE_USUARIO = arrResult[intusuAsignado].ToString();
                            }
                            drReader.Close();
                        }
                    }
                    //--------------------------------
                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                    temp = new enDocumento();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return temp;
        }

        public List<enDocumento_Obs> DocumentoObservado_Listar(enDocumento_Obs entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enDocumento_Obs> Lista =new List<enDocumento_Obs>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackDigitalCons + ".PRC_CDADOCOBS_LISTARUNO";
            cmd.Parameters.Add("X_ID_DOCUMENTO", validarNulo(entidad.ID_DOCUMENTO));
            cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add("X_RESULTADO", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
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
                            int intIdDocumentoObs = drReader.GetOrdinal("ID_DOCUMENTO_OBS");
                            int intIdDocumento = drReader.GetOrdinal("ID_DOCUMENTO");
                            int intIdTipoObs = drReader.GetOrdinal("ID_TIPO_OBSERVACION");
                            int intDesctipoObs = drReader.GetOrdinal("DESC_TIPO_OBSERVACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intUsuCreacion = drReader.GetOrdinal("STR_USU_CREACION");
                            int intObservacion= drReader.GetOrdinal("OBSERVACION");
                            
                            enDocumento_Obs temp = null;
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumento_Obs();
                                if (!drReader.IsDBNull(intIdDocumentoObs)) temp.ID_DOCUMENTO_OBS = long.Parse(arrResult[intIdDocumentoObs].ToString());
                                if (!drReader.IsDBNull(intIdDocumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDocumento].ToString());
                                if (!drReader.IsDBNull(intIdTipoObs)) temp.ID_TIPO_OBSERVACION = long.Parse(arrResult[intIdTipoObs].ToString());
                                if (!drReader.IsDBNull(intDesctipoObs)) temp.DESC_TIPO_OBSERVACION = arrResult[intDesctipoObs].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intUsuCreacion)) temp.USU_CREACION = arrResult[intUsuCreacion].ToString();
                                if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
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
                    Lista = new List<enDocumento_Obs>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return Lista;
        }

        public void Documento_Grabar(enDocumento entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PRC_CDADOCUMENTO_GRABAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_CONTROL_CARGA", OracleDbType.Varchar2)).Value = entidad.ID_CONTROL_CARGA;
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

        public void Documento_AsignacionInsertar(enDocumento entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PRC_CDALOTES_INSERTAR"), cn);
                OracleTransaction transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_ID_AREA_PROCEDENCIA", OracleDbType.Int64)).Value = entidad.ID_AREA_PROCEDENCIA;
                cmd.Parameters.Add(new OracleParameter("X_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.USU_CREACION;
                cmd.Parameters.Add(new OracleParameter("X_IP_CREACION", OracleDbType.Varchar2)).Value = entidad.IP_CREACION;
                cmd.Parameters.Add(new OracleParameter("X_ID_LOTE", OracleDbType.Int64)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    dr = cmd.ExecuteReader();
                    string PO_ID_LOTE = cmd.Parameters["X_ID_LOTE"].Value.ToString();
                    string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
                    if (PO_VALIDO == "0")
                    {
                        auditoria.Rechazar(PO_MENSAJE);
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        if (entidad.ListaDocumento.Count() > 0)
                        {
                            foreach (enDocumento item in entidad.ListaDocumento)
                            {
                                cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PRC_CDADOCASIGNACION_INSERTAR"), cn);
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO", OracleDbType.Int64)).Value = item.ID_DOCUMENTO;
                                cmd.Parameters.Add(new OracleParameter("X_ID_LOTE", OracleDbType.Int64)).Value = PO_ID_LOTE;
                                cmd.Parameters.Add(new OracleParameter("X_ID_USUARIO", OracleDbType.Int64)).Value = item.ID_USUARIO;
                                cmd.Parameters.Add(new OracleParameter("X_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.USU_CREACION;
                                cmd.Parameters.Add(new OracleParameter("X_IP_CREACION", OracleDbType.Varchar2)).Value = entidad.IP_CREACION;
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
        public void Documento_AsignacionActualizar(enDocumento entidad, ref enAuditoria auditoria)
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
                    if (entidad.ListaDocumento.Count() > 0)
                    {

                        foreach (enDocumento item in entidad.ListaDocumento)
                        {
                            cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PRC_CDADOCASIGN_ACTUALIZAR"), cn);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO_ASIGNADO", OracleDbType.Int64)).Value = item.ID_DOCUMENTO_ASIGNADO;
                            cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO", OracleDbType.Int64)).Value = item.ID_DOCUMENTO;
                            cmd.Parameters.Add(new OracleParameter("X_ID_USUARIO", OracleDbType.Int64)).Value = item.ID_USUARIO;
                            cmd.Parameters.Add(new OracleParameter("X_USU_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.USU_MODIFICACION;
                            cmd.Parameters.Add(new OracleParameter("X_IP_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.IP_CREACION;
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
