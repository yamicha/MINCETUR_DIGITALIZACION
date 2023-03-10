using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using Utilitarios.Helpers;
using System.Data;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;

namespace DaServiciosDigitalizacion.Ventanilla.Digitalizacion
{
    public class DaDocumento : daBase
    {
        public DaDocumento(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
        }

        public List<enDocumento> Documento_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enDocumento> lista = new List<enDocumento>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDocVentanilla, "PRC_CDVDOC_PAGINACION");
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
                            int intIdestadoDoc = drReader.GetOrdinal("ID_ESTADO_DOCUMENTO");
                            int intDescEstado = drReader.GetOrdinal("DESCRIPCION_ESTADO");
                            int intIdDocAsignado = drReader.GetOrdinal("ID_DOCUMENTO_ASIGNADO");
                            int intIdUsuario = drReader.GetOrdinal("ID_USUARIO");
                            int intNomUsuario = drReader.GetOrdinal("NOMBRE_USUARIO");
                            int intIdLote = drReader.GetOrdinal("ID_LOTE");
                            int intNroLote = drReader.GetOrdinal("NRO_LOTE");
                            int intNroRepro = drReader.GetOrdinal("NRO_REPROCESADOS");
                            int intPesoAdj = drReader.GetOrdinal("PESO_ADJ");
                            int intUsuariocreacion = drReader.GetOrdinal("STR_USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intUsuModific = drReader.GetOrdinal("USU_MODIFICACION");
                            int intFecModific = drReader.GetOrdinal("STR_FEC_MODIFICACION");
                            int intDestipoDoc = drReader.GetOrdinal("DES_TIP_DOC");
                            int intDesAsunto = drReader.GetOrdinal("DES_ASUNTO");
                            int intdesObs = drReader.GetOrdinal("DES_OBS");
                            int intNumfolio = drReader.GetOrdinal("NUM_FOLIOS");
                            int intNumdoc = drReader.GetOrdinal("NUM_DOC");
                            int intDesClasif = drReader.GetOrdinal("DES_CLASIF");
                            int intDescPersona = drReader.GetOrdinal("DES_PERSONA");
                            int intFecExpiente = drReader.GetOrdinal("STR_FEC_EXPEDIENTE");
                            
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumento();
                                if (!drReader.IsDBNull(intIdDocumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDocumento].ToString());
                                if (!drReader.IsDBNull(intIdestadoDoc)) temp.ID_ESTADO_DOCUMENTO = long.Parse(arrResult[intIdestadoDoc].ToString());
                                if (!drReader.IsDBNull(intDescEstado)) temp.DESCRIPCION_ESTADO = arrResult[intDescEstado].ToString();
                                if (!drReader.IsDBNull(intIdDocAsignado)) temp.ID_DOCUMENTO_ASIGNADO = long.Parse(arrResult[intIdDocAsignado].ToString());
                                if (!drReader.IsDBNull(intNroRepro)) temp.NRO_REPROCESADOS = long.Parse(arrResult[intNroRepro].ToString());
                                if (!drReader.IsDBNull(intIdUsuario)) temp.ID_USUARIO = long.Parse(arrResult[intIdUsuario].ToString());
                                if (!drReader.IsDBNull(intNomUsuario)) temp.NOMBRE_USUARIO = arrResult[intNomUsuario].ToString();
                                if (!drReader.IsDBNull(intIdLote)) temp.ID_LOTE = long.Parse(arrResult[intIdLote].ToString());
                                if (!drReader.IsDBNull(intNroLote)) temp.NRO_LOTE = arrResult[intNroLote].ToString();
                                if (!drReader.IsDBNull(intPesoAdj)) temp.PESO_ADJ = long.Parse(arrResult[intPesoAdj].ToString());
                                if (!drReader.IsDBNull(intUsuariocreacion)) temp.USU_CREACION = arrResult[intUsuariocreacion].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intUsuModific)) temp.USU_MODIFICACION = arrResult[intUsuModific].ToString();
                                if (!drReader.IsDBNull(intFecModific)) temp.STR_FEC_MODIFICACION = arrResult[intFecModific].ToString();
                                if (!drReader.IsDBNull(intDestipoDoc)) temp.DES_TIP_DOC = arrResult[intDestipoDoc].ToString();
                                if (!drReader.IsDBNull(intDesAsunto)) temp.DES_ASUNTO = arrResult[intDesAsunto].ToString();
                                if (!drReader.IsDBNull(intdesObs)) temp.DES_OBS = arrResult[intdesObs].ToString();
                                if (!drReader.IsDBNull(intNumfolio)) temp.NUM_FOLIOS = long.Parse(arrResult[intNumfolio].ToString());
                                if (!drReader.IsDBNull(intNumdoc)) temp.NUM_DOC = arrResult[intNumdoc].ToString();
                                if (!drReader.IsDBNull(intDesClasif)) temp.DES_CLASIF = arrResult[intDesClasif].ToString();
                                if (!drReader.IsDBNull(intDescPersona)) temp.DES_PERSONA = arrResult[intDescPersona].ToString();
                                if (!drReader.IsDBNull(intFecExpiente)) temp.STR_FEC_EXPEDIENTE = arrResult[intFecExpiente].ToString();
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
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDocVentanilla, "PRC_CDVDOCPROCESO_PAGINACION");
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
                            int intIdDocumento = drReader.GetOrdinal("ID_DOCUMENTO");
                            int intIdestadoDoc = drReader.GetOrdinal("ID_ESTADO_DOCUMENTO");
                            int intDescEstado = drReader.GetOrdinal("DESCRIPCION_ESTADO");
                            int intNroLote = drReader.GetOrdinal("NRO_LOTE");
                            int intDescClasif = drReader.GetOrdinal("DES_CLASIF");
                            int intDesTipoDoc = drReader.GetOrdinal("DES_TIP_DOC");
                            int intAsunto = drReader.GetOrdinal("DES_ASUNTO");
                            int intHoraInicio = drReader.GetOrdinal("HORA_INICIO");
                            int intHoraFin = drReader.GetOrdinal("HORA_FIN");
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intNomUsuario = drReader.GetOrdinal("NOMBRE_USUARIO");
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
                                if (!drReader.IsDBNull(intDescClasif)) temp.DES_CLASIF = arrResult[intDescClasif].ToString();
                                if (!drReader.IsDBNull(intDesTipoDoc)) temp.DES_TIP_DOC = arrResult[intDesTipoDoc].ToString();
                                if (!drReader.IsDBNull(intAsunto)) temp.DES_ASUNTO = arrResult[intAsunto].ToString();
                                if (!drReader.IsDBNull(intHoraInicio)) temp.HORA_INICIO = arrResult[intHoraInicio].ToString();
                                if (!drReader.IsDBNull(intHoraFin)) temp.HORA_FIN = arrResult[intHoraFin].ToString();
                                if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
                                if (!drReader.IsDBNull(intHoraInicio)) temp.HORA_INICIO = arrResult[intHoraInicio].ToString();
                                if (!drReader.IsDBNull(intHoraFin)) temp.HORA_FIN = arrResult[intHoraFin].ToString();
                                if (!drReader.IsDBNull(intNomUsuario)) temp.NOMBRE_USUARIO = arrResult[intNomUsuario].ToString();
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
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDocVentanilla, "PRC_CDVDOC_EXPORTAR");
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
                            int intIdestadoDoc = drReader.GetOrdinal("ID_ESTADO_DOCUMENTO");
                            int intDescEstado = drReader.GetOrdinal("DESCRIPCION_ESTADO");
                            int intIdDocAsignado = drReader.GetOrdinal("ID_DOCUMENTO_ASIGNADO");
                            int intIdUsuario = drReader.GetOrdinal("ID_USUARIO");
                            int intNomUsuario = drReader.GetOrdinal("NOMBRE_USUARIO");
                            int intIdLote = drReader.GetOrdinal("ID_LOTE");
                            int intNroRepro = drReader.GetOrdinal("NRO_REPROCESADOS");
                            int intPesoAdj = drReader.GetOrdinal("PESO_ADJ");
                            int intUsuariocreacion = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intUsuModific = drReader.GetOrdinal("USU_MODIFICACION");
                            int intFecModific = drReader.GetOrdinal("STR_FEC_MODIFICACION");
                            int intDestipoDoc = drReader.GetOrdinal("DES_TIP_DOC");
                            int intDesAsunto = drReader.GetOrdinal("DES_ASUNTO");
                            int intdesObs = drReader.GetOrdinal("DES_OBS");
                            int intNumfolio = drReader.GetOrdinal("NUM_FOLIOS");
                            int intNumdoc = drReader.GetOrdinal("NUM_DOC");
                            int intDesClasif = drReader.GetOrdinal("DES_CLASIF");
                            int intDescPersona = drReader.GetOrdinal("DES_PERSONA");

                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumento();
                                if (!drReader.IsDBNull(intIdDocumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDocumento].ToString());
                                if (!drReader.IsDBNull(intIdestadoDoc)) temp.ID_ESTADO_DOCUMENTO = long.Parse(arrResult[intIdestadoDoc].ToString());
                                if (!drReader.IsDBNull(intDescEstado)) temp.DESCRIPCION_ESTADO = arrResult[intDescEstado].ToString();
                                if (!drReader.IsDBNull(intIdDocAsignado)) temp.ID_DOCUMENTO_ASIGNADO = long.Parse(arrResult[intIdDocAsignado].ToString());
                                if (!drReader.IsDBNull(intNroRepro)) temp.NRO_REPROCESADOS = long.Parse(arrResult[intNroRepro].ToString());
                                if (!drReader.IsDBNull(intIdUsuario)) temp.ID_USUARIO = long.Parse(arrResult[intIdUsuario].ToString());
                                if (!drReader.IsDBNull(intNomUsuario)) temp.NOMBRE_USUARIO = arrResult[intNomUsuario].ToString();
                                if (!drReader.IsDBNull(intIdLote)) temp.ID_LOTE = long.Parse(arrResult[intIdLote].ToString());
                                if (!drReader.IsDBNull(intPesoAdj)) temp.PESO_ADJ = long.Parse(arrResult[intPesoAdj].ToString());
                                if (!drReader.IsDBNull(intUsuariocreacion)) temp.USU_CREACION = arrResult[intUsuariocreacion].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intUsuModific)) temp.USU_MODIFICACION = arrResult[intUsuModific].ToString();
                                if (!drReader.IsDBNull(intFecModific)) temp.STR_FEC_MODIFICACION = arrResult[intFecModific].ToString();
                                if (!drReader.IsDBNull(intDestipoDoc)) temp.DES_TIP_DOC = arrResult[intDestipoDoc].ToString();
                                if (!drReader.IsDBNull(intDesAsunto)) temp.DES_ASUNTO = arrResult[intDesAsunto].ToString();
                                if (!drReader.IsDBNull(intdesObs)) temp.DES_OBS = arrResult[intdesObs].ToString();
                                if (!drReader.IsDBNull(intNumfolio)) temp.NUM_FOLIOS = long.Parse(arrResult[intNumfolio].ToString());
                                if (!drReader.IsDBNull(intNumdoc)) temp.NUM_DOC = arrResult[intNumdoc].ToString();
                                if (!drReader.IsDBNull(intDesClasif)) temp.DES_CLASIF = arrResult[intDesClasif].ToString();
                                if (!drReader.IsDBNull(intDescPersona)) temp.DES_PERSONA = arrResult[intDescPersona].ToString();
                                lista.Add(temp);
                            }
                            drReader.Close();
                        }
                    }
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

        //public enDocumento Documento_ListarUno(enDocumento entidad, ref enAuditoria auditoria)
        //{
        //    auditoria.Limpiar();
        //    enDocumento temp = null;
        //    OracleCommand cmd = new OracleCommand();
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.CommandText = AppSettingsHelper.PackDigitalCons + ".PRC_CDVDOC_LISTARUNO";
        //    cmd.Parameters.Add("X_ID_DOCUMENTO", validarNulo(entidad.ID_DOCUMENTO));
        //    cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
        //    cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
        //    cmd.Parameters.Add("X_RESULTADO", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
        //    using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
        //    {
        //        cn.Open();
        //        try
        //        {
        //            cmd.Connection = cn;
        //            using (OracleDataReader drReader = cmd.ExecuteReader())
        //            {
        //                string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
        //                string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
        //                if (PO_VALIDO == "0")
        //                    auditoria.Rechazar(PO_MENSAJE);

        //                object[] arrResult = null;
        //                if (drReader.HasRows)
        //                {
        //                    arrResult = new object[drReader.FieldCount];
        //                    int intIdDocumento = drReader.GetOrdinal("ID_DOCUMENTO");
        //                    int intIdcontrolCarga = drReader.GetOrdinal("ID_CONTROL_CARGA");
        //                    int intIdestadoDoc = drReader.GetOrdinal("ID_ESTADO_DOCUMENTO");
        //                    int intDescEstado = drReader.GetOrdinal("DESCRIPCION_ESTADO");
        //                    int intIdDocAsignado = drReader.GetOrdinal("ID_DOCUMENTO_ASIGNADO");
        //                    int intIdFondo = drReader.GetOrdinal("ID_FONDO");
        //                    int intDesFondo = drReader.GetOrdinal("DES_FONDO");
        //                    int intIdSeccion = drReader.GetOrdinal("ID_SECCION");
        //                    int intDesSeccion = drReader.GetOrdinal("DES_LARGA_SECCION");
        //                    int intIdSerie = drReader.GetOrdinal("ID_SERIE");
        //                    int intDesSerie = drReader.GetOrdinal("DES_SERIE");
        //                    int intNomDocumento = drReader.GetOrdinal("NOM_DOCUMENTO");
        //                    int intDescripcion = drReader.GetOrdinal("DESCRIPCION");
        //                    int intAnio = drReader.GetOrdinal("ANIO");
        //                    int intFolios = drReader.GetOrdinal("FOLIOS");
        //                    int intIdlaser = drReader.GetOrdinal("ID_LASERFICHE");
        //                    int intObservacion = drReader.GetOrdinal("OBSERVACION");
        //                    int intusuAsignado = drReader.GetOrdinal("NOMBRE_USUARIO");

        //                    while (drReader.Read())
        //                    {
        //                        drReader.GetValues(arrResult);
        //                        temp = new enDocumento();
        //                        if (!drReader.IsDBNull(intIdDocumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDocumento].ToString());
        //                        if (!drReader.IsDBNull(intIdcontrolCarga)) temp.ID_CONTROL_CARGA = long.Parse(arrResult[intIdcontrolCarga].ToString());
        //                        if (!drReader.IsDBNull(intIdestadoDoc)) temp.ID_ESTADO_DOCUMENTO = long.Parse(arrResult[intIdestadoDoc].ToString());
        //                        if (!drReader.IsDBNull(intIdDocAsignado)) temp.ID_DOCUMENTO_ASIGNADO = long.Parse(arrResult[intIdDocAsignado].ToString());
        //                        if (!drReader.IsDBNull(intDescEstado)) temp.DESCRIPCION_ESTADO = arrResult[intDescEstado].ToString();
        //                        if (!drReader.IsDBNull(intIdFondo)) temp.ID_FONDO = long.Parse(arrResult[intIdFondo].ToString());
        //                        if (!drReader.IsDBNull(intDesFondo)) temp.DES_FONDO = arrResult[intDesFondo].ToString();
        //                        if (!drReader.IsDBNull(intIdSeccion)) temp.ID_SECCION = long.Parse(arrResult[intIdSeccion].ToString());
        //                        if (!drReader.IsDBNull(intDesSeccion)) temp.DES_LARGA_SECCION = arrResult[intDesSeccion].ToString();
        //                        if (!drReader.IsDBNull(intIdSerie)) temp.ID_SERIE = long.Parse(arrResult[intIdSerie].ToString());
        //                        if (!drReader.IsDBNull(intDesSerie)) temp.DES_SERIE = arrResult[intDesSerie].ToString();
        //                        if (!drReader.IsDBNull(intNomDocumento)) temp.NOM_DOCUMENTO = arrResult[intNomDocumento].ToString();
        //                        if (!drReader.IsDBNull(intDescripcion)) temp.DESCRIPCION = arrResult[intDescripcion].ToString();
        //                        if (!drReader.IsDBNull(intAnio)) temp.ANIO = long.Parse(arrResult[intAnio].ToString());
        //                        if (!drReader.IsDBNull(intFolios)) temp.FOLIOS = long.Parse(arrResult[intFolios].ToString());
        //                        if (!drReader.IsDBNull(intIdlaser)) temp.ID_LASERFICHE = long.Parse(arrResult[intIdlaser].ToString());
        //                        if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
        //                        if (!drReader.IsDBNull(intusuAsignado)) temp.NOMBRE_USUARIO = arrResult[intusuAsignado].ToString();
        //                    }
        //                    drReader.Close();
        //                }
        //            }
        //            //--------------------------------
        //        }
        //        catch (Exception ex)
        //        {
        //            auditoria.Error(ex);
        //            temp = new enDocumento();
        //        }
        //        finally
        //        {
        //            if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
        //            if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
        //        }
        //    }
        //    return temp;
        //}

        //public List<enDocumento_Obs> DocumentoObservado_Listar(enDocumento_Obs entidad, ref enAuditoria auditoria)
        //{
        //    auditoria.Limpiar();
        //    List<enDocumento_Obs> Lista =new List<enDocumento_Obs>();
        //    OracleCommand cmd = new OracleCommand();
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.CommandText = AppSettingsHelper.PackDigitalCons + ".PRC_CDVDOCOBS_LISTARUNO";
        //    cmd.Parameters.Add("X_ID_DOCUMENTO", validarNulo(entidad.ID_DOCUMENTO));
        //    cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
        //    cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
        //    cmd.Parameters.Add("X_RESULTADO", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
        //    using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
        //    {
        //        cn.Open();
        //        try
        //        {
        //            cmd.Connection = cn;
        //            using (OracleDataReader drReader = cmd.ExecuteReader())
        //            {
        //                string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
        //                string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
        //                if (PO_VALIDO == "0")
        //                    auditoria.Rechazar(PO_MENSAJE);

        //                object[] arrResult = null;
        //                if (drReader.HasRows)
        //                {
        //                    arrResult = new object[drReader.FieldCount];
        //                    int intIdDocumentoObs = drReader.GetOrdinal("ID_DOCUMENTO_OBS");
        //                    int intIdDocumento = drReader.GetOrdinal("ID_DOCUMENTO");
        //                    int intIdTipoObs = drReader.GetOrdinal("ID_TIPO_OBSERVACION");
        //                    int intDesctipoObs = drReader.GetOrdinal("DESC_TIPO_OBSERVACION");
        //                    int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
        //                    int intUsuCreacion = drReader.GetOrdinal("USU_CREACION");
        //                    int intObservacion= drReader.GetOrdinal("OBSERVACION");

        //                    enDocumento_Obs temp = null;
        //                    while (drReader.Read())
        //                    {
        //                        drReader.GetValues(arrResult);
        //                        temp = new enDocumento_Obs();
        //                        if (!drReader.IsDBNull(intIdDocumentoObs)) temp.ID_DOCUMENTO_OBS = long.Parse(arrResult[intIdDocumentoObs].ToString());
        //                        if (!drReader.IsDBNull(intIdDocumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDocumento].ToString());
        //                        if (!drReader.IsDBNull(intIdTipoObs)) temp.ID_TIPO_OBSERVACION = long.Parse(arrResult[intIdTipoObs].ToString());
        //                        if (!drReader.IsDBNull(intDesctipoObs)) temp.DESC_TIPO_OBSERVACION = arrResult[intDesctipoObs].ToString();
        //                        if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
        //                        if (!drReader.IsDBNull(intUsuCreacion)) temp.USU_CREACION = arrResult[intUsuCreacion].ToString();
        //                        if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
        //                        Lista.Add(temp); 
        //                    }
        //                    drReader.Close();
        //                }
        //            }
        //            //--------------------------------
        //        }
        //        catch (Exception ex)
        //        {
        //            auditoria.Error(ex);
        //            Lista = new List<enDocumento_Obs>();
        //        }
        //        finally
        //        {
        //            if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
        //            if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
        //        }
        //    }
        //    return Lista;
        //}
        public void Documento_AsignacionInsertar(enDocumento entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackManVentanilla, "PRC_CDVLOTES_INSERTAR"), cn);
                OracleTransaction transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("X_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.USU_CREACION;
                cmd.Parameters.Add(new OracleParameter("X_FLG_DIGITALIZAR", OracleDbType.Varchar2)).Value = entidad.FLG_DIGITALIZAR;
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
                                cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackManVentanilla, "PRC_CDVDOCASIGNACION_INSERTAR"), cn);
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.Add(new OracleParameter("X_ID_DOCUMENTO", OracleDbType.Int64)).Value = item.ID_DOCUMENTO;
                                cmd.Parameters.Add(new OracleParameter("X_FLG_DIGITALIZAR", OracleDbType.Varchar2)).Value = entidad.FLG_DIGITALIZAR;
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
                            cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackManVentanilla, "PRC_CDVDOCASIGN_ACTUALIZAR"), cn);
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
        public enDocumento Documento_ListarUno(enDocumento entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            enDocumento temp = null;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackDocVentanilla + ".PRC_CDVDOC_LISTARUNO";
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
                            int intIdestadoDoc = drReader.GetOrdinal("ID_ESTADO_DOCUMENTO");
                            int intDescEstado = drReader.GetOrdinal("DESCRIPCION_ESTADO");
                            int intIdDocAsignado = drReader.GetOrdinal("ID_DOCUMENTO_ASIGNADO");
                            int intIdUsuario = drReader.GetOrdinal("ID_USUARIO");
                            int intNomUsuario = drReader.GetOrdinal("NOMBRE_USUARIO");
                            int intDestipoDoc = drReader.GetOrdinal("DES_TIP_DOC");
                            int intDesAsunto = drReader.GetOrdinal("DES_ASUNTO");
                            int intdesObs = drReader.GetOrdinal("DES_OBS");
                            int intNumfolio = drReader.GetOrdinal("NUM_FOLIOS");
                            int intNumdoc = drReader.GetOrdinal("NUM_DOC");
                            int intDesClasif = drReader.GetOrdinal("DES_CLASIF");
                            int intDescPersona = drReader.GetOrdinal("DES_PERSONA");
                            int intExpObservacion = drReader.GetOrdinal("DES_EXP_OBSERVACION");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enDocumento();
                                if (!drReader.IsDBNull(intIdDocumento)) temp.ID_DOCUMENTO = long.Parse(arrResult[intIdDocumento].ToString());
                                if (!drReader.IsDBNull(intIdestadoDoc)) temp.ID_ESTADO_DOCUMENTO = long.Parse(arrResult[intIdestadoDoc].ToString());
                                if (!drReader.IsDBNull(intDescEstado)) temp.DESCRIPCION_ESTADO = arrResult[intDescEstado].ToString();
                                if (!drReader.IsDBNull(intIdDocAsignado)) temp.ID_DOCUMENTO_ASIGNADO = long.Parse(arrResult[intIdDocAsignado].ToString());
                                if (!drReader.IsDBNull(intIdUsuario)) temp.ID_USUARIO = long.Parse(arrResult[intIdUsuario].ToString());
                                if (!drReader.IsDBNull(intNomUsuario)) temp.NOMBRE_USUARIO = arrResult[intNomUsuario].ToString();
                                if (!drReader.IsDBNull(intDestipoDoc)) temp.DES_TIP_DOC = arrResult[intDestipoDoc].ToString();
                                if (!drReader.IsDBNull(intDesAsunto)) temp.DES_ASUNTO = arrResult[intDesAsunto].ToString();
                                if (!drReader.IsDBNull(intdesObs)) temp.DES_OBS = arrResult[intdesObs].ToString();
                                if (!drReader.IsDBNull(intNumfolio)) temp.NUM_FOLIOS = long.Parse(arrResult[intNumfolio].ToString());
                                if (!drReader.IsDBNull(intNumdoc)) temp.NUM_DOC = arrResult[intNumdoc].ToString();
                                if (!drReader.IsDBNull(intDesClasif)) temp.DES_CLASIF = arrResult[intDesClasif].ToString();
                                if (!drReader.IsDBNull(intDescPersona)) temp.DES_PERSONA = arrResult[intDescPersona].ToString();
                                if (!drReader.IsDBNull(intExpObservacion)) temp.EXP_OBSERVACION = arrResult[intExpObservacion].ToString();
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
        public List<enAdjuntos> DocumentoAdjuntos_Listar(enAdjuntos entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enAdjuntos> Lista = new List<enAdjuntos>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackDocVentanilla + ".PRC_CDVDOCADJUNTOS_LISTAR";
            cmd.Parameters.Add("X_ID_EXPE", validarNulo(entidad.ID_EXPE));
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
                            arrResult = new object[drReader.FieldCount];
                            int intIdDoc = drReader.GetOrdinal("ID_DOC_ADJ");
                            int intDesNom = drReader.GetOrdinal("DES_NOM");
                            int intExtension = drReader.GetOrdinal("EXT");
                            int intNumsize = drReader.GetOrdinal("NUM_SIZE_ARCHIVO");
                            int intIdLaser = drReader.GetOrdinal("ID_DOC_CMS");
                            int intFlgLink = drReader.GetOrdinal("FLG_LINK");
                            enAdjuntos temp = null;
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enAdjuntos();
                                if (!drReader.IsDBNull(intIdDoc)) temp.ID_DOC_ADJ = long.Parse(arrResult[intIdDoc].ToString());
                                if (!drReader.IsDBNull(intDesNom)) temp.DES_NOM_ABR = arrResult[intDesNom].ToString();
                                if (!drReader.IsDBNull(intExtension)) temp.EXTENSION = arrResult[intExtension].ToString();
                                if (!drReader.IsDBNull(intNumsize)) temp.NUM_SIZE_ARCHIVO = long.Parse(arrResult[intNumsize].ToString());
                                if (!drReader.IsDBNull(intIdLaser)) temp.ID_DOC_CMS = long.Parse(arrResult[intIdLaser].ToString());
                                if (!drReader.IsDBNull(intFlgLink)) temp.FLG_LINK = int.Parse(arrResult[intFlgLink].ToString());
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
                    Lista = new List<enAdjuntos>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return Lista;
        }
        public void DocumentoAdjuntos_Eliminar(enAdjuntos entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                try
                {
                    cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackManVentanilla, "PRC_CDVDOCUMENTOADJ_ELIMINAR"), cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("X_ID_DOC_ADJ", OracleDbType.Int64)).Value = entidad.ID_DOC_ADJ;
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
        public void DocumentoAdjuntos_Actualizar(enAdjuntos entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                try
                {
                    cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackManVentanilla, "PRC_CDVDOCUMENTOADJ_ACTUALIZAR"), cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("X_ID_DOC_ADJ", OracleDbType.Int64)).Value = entidad.ID_DOC_ADJ;
                    cmd.Parameters.Add(new OracleParameter("X_EXT", OracleDbType.Varchar2)).Value = entidad.EXTENSION;
                    cmd.Parameters.Add(new OracleParameter("X_NUM_SIZE_ARCHIVO", OracleDbType.Int64)).Value = entidad.NUM_SIZE_ARCHIVO;
                    cmd.Parameters.Add(new OracleParameter("X_USU_MODI", OracleDbType.Int64)).Value = entidad.USU_MODIFICACION;
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
        public void DocumentoAdjuntos_Insertar(enAdjuntos entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand();
                try
                {
                    cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackManVentanilla, "PRC_CDVDOCUMENTOADJ_INSERTAR"), cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("X_ID_EXPE", OracleDbType.Int64)).Value = entidad.ID_EXPEDIENTE;
                    cmd.Parameters.Add(new OracleParameter("X_DES_NOM", OracleDbType.Varchar2)).Value = entidad.DES_NOM_ABR;
                    cmd.Parameters.Add(new OracleParameter("X_EXT", OracleDbType.Varchar2)).Value = entidad.EXTENSION;
                    cmd.Parameters.Add(new OracleParameter("X_NUM_SIZE_ARCHIVO", OracleDbType.Int64)).Value = entidad.NUM_SIZE_ARCHIVO;
                    cmd.Parameters.Add(new OracleParameter("X_ID_DOC_CMS", OracleDbType.Int64)).Value = entidad.ID_DOC_CMS;
                    cmd.Parameters.Add(new OracleParameter("X_FLG_LINK", OracleDbType.Varchar2)).Value = entidad.FLG_LINK;
                    cmd.Parameters.Add(new OracleParameter("X_FLG_TIPO", OracleDbType.Varchar2)).Value = entidad.FLG_TIPO;
                    cmd.Parameters.Add(new OracleParameter("X_ID_DOC", OracleDbType.Int64)).Value = 0; 
                    cmd.Parameters.Add(new OracleParameter("X_USU_CREACION", OracleDbType.Int64)).Value = entidad.USU_CREACION;
                    cmd.Parameters.Add(new OracleParameter("X_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(new OracleParameter("X_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
                    dr = cmd.ExecuteReader();
                    string PO_VALIDO = cmd.Parameters["X_VALIDO"].Value.ToString();
                    string PO_MENSAJE = cmd.Parameters["X_MENSAJE"].Value.ToString();
                    if (PO_VALIDO == "0")
                    {
                        auditoria.Rechazar(PO_MENSAJE);
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
        public List<enDocumento_Obs> DocumentoObservado_Listar(enDocumento_Obs entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enDocumento_Obs> Lista = new List<enDocumento_Obs>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackDocVentanilla + ".PRC_CDVDOCOBS_LISTARUNO";
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
                            int intUsuCreacion = drReader.GetOrdinal("USU_CREACION");
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");

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

    }
}
