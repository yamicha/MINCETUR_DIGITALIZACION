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
        public List<enMicroforma> Microforma_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enMicroforma> lista = new List<enMicroforma>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PROC_CDAMICRO_PAGINACION");
            cmd.Parameters.Add("XIN_PAGINA", PAGINA);
            cmd.Parameters.Add("XIN_NROREGISTROS", FILAS);
            cmd.Parameters.Add("XIN_ORDEN_COLUMNA", ORDEN_COLUMNA);
            cmd.Parameters.Add("XIN_ORDEN", ORDEN);
            cmd.Parameters.Add("XIN_WHERE", @WHERE);
            cmd.Parameters.Add("XOUT_CUENTA", OracleDbType.Int32, System.Data.ParameterDirection.Output);
            cmd.Parameters.Add("XOUT_RESULTADO", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                try
                {
                    cmd.Connection = cn;
                    using (OracleDataReader drReader = cmd.ExecuteReader())
                    {
                        int CUENTA = int.Parse(cmd.Parameters["XOUT_CUENTA"].Value.ToString());
                        auditoria.Objeto = CUENTA;
                        object[] arrResult = null;
                        if (drReader.HasRows)
                        {
                            enMicroforma temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdMicro = drReader.GetOrdinal("ID_MICROFORMA");
                            int intTipoSoporte = drReader.GetOrdinal("ID_TIPO_SOPORTE");
                            int intNroVolumen = drReader.GetOrdinal("NRO_VOLUMEN");
                            int intDescSoporte = drReader.GetOrdinal("DESC_SOPORTE");
                            int intCodigoSoporte = drReader.GetOrdinal("CODIGO_SOPORTE");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intDesEstado = drReader.GetOrdinal("DESC_ESTADO");
                            int intIdEstado = drReader.GetOrdinal("ID_ESTADO_MICROFORMA");
                            int intFlgConforme = drReader.GetOrdinal("FLG_CONFORME");
                            int intNroRevision = drReader.GetOrdinal("NRO_REVISIONES");
                            
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enMicroforma();
                                if (!drReader.IsDBNull(intIdMicro)) temp.ID_MICROFORMA = long.Parse(arrResult[intIdMicro].ToString());
                                if (!drReader.IsDBNull(intTipoSoporte)) temp.ID_TIPO_SOPORTE = long.Parse(arrResult[intTipoSoporte].ToString());
                                if (!drReader.IsDBNull(intDescSoporte)) temp.DESC_SOPORTE = arrResult[intDescSoporte].ToString();
                                if (!drReader.IsDBNull(intCodigoSoporte)) temp.CODIGO_SOPORTE = arrResult[intCodigoSoporte].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intDesEstado)) temp.DESC_ESTADO = arrResult[intDesEstado].ToString();
                                if (!drReader.IsDBNull(intIdEstado)) temp.ID_ESTADO = long.Parse(arrResult[intIdEstado].ToString());
                                if (!drReader.IsDBNull(intFlgConforme)) temp.FLG_CONFORME = arrResult[intFlgConforme].ToString();
                                if (!drReader.IsDBNull(intNroVolumen)) temp.NRO_VOLUMEN = arrResult[intNroVolumen].ToString();
                                if (!drReader.IsDBNull(intNroRevision)) temp.NRO_REVISIONES = long.Parse(arrResult[intNroRevision].ToString());
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
        public List<enMicroforma> Microforma_Listar(enMicroforma entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enMicroforma> lista = new List<enMicroforma>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PROC_CDAMICRO_LISTAR");
            cmd.Parameters.Add(new OracleParameter("XIN_ID_ESTADO", OracleDbType.Int64)).Value = entidad.ID_ESTADO;
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
                            int intDesEstado = drReader.GetOrdinal("DESC_ESTADO");
                            int intIdEstado = drReader.GetOrdinal("ID_ESTADO_MICROFORMA");

                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enMicroforma();
                                if (!drReader.IsDBNull(intIdMicro)) temp.ID_MICROFORMA = long.Parse(arrResult[intIdMicro].ToString());
                                if (!drReader.IsDBNull(intTipoSoporte)) temp.ID_TIPO_SOPORTE = long.Parse(arrResult[intTipoSoporte].ToString());
                                if (!drReader.IsDBNull(intDescSoporte)) temp.DESC_SOPORTE = arrResult[intDescSoporte].ToString();
                                if (!drReader.IsDBNull(intCodigoSoporte)) temp.CODIGO_SOPORTE = arrResult[intCodigoSoporte].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intDesEstado)) temp.DESC_ESTADO = arrResult[intDesEstado].ToString();
                                if (!drReader.IsDBNull(intIdEstado)) temp.ID_ESTADO = long.Parse(arrResult[intIdEstado].ToString());
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
        public List<enMicroforma> Microforma_ListarControl(enMicroforma entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enMicroforma> lista = new List<enMicroforma>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PROC_CDAMICRO_LISTARCONTROL");
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
                            int intDesEstado = drReader.GetOrdinal("DESC_ESTADO");
                            int intIdEstado = drReader.GetOrdinal("ID_ESTADO_MICROFORMA");

                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enMicroforma();

                                if (!drReader.IsDBNull(intIdMicro)) temp.ID_MICROFORMA = long.Parse(arrResult[intIdMicro].ToString());
                                if (!drReader.IsDBNull(intTipoSoporte)) temp.ID_TIPO_SOPORTE = long.Parse(arrResult[intTipoSoporte].ToString());
                                if (!drReader.IsDBNull(intDescSoporte)) temp.DESC_SOPORTE = arrResult[intDescSoporte].ToString();
                                if (!drReader.IsDBNull(intCodigoSoporte)) temp.CODIGO_SOPORTE = arrResult[intCodigoSoporte].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intDesEstado)) temp.DESC_ESTADO = arrResult[intDesEstado].ToString();
                                if (!drReader.IsDBNull(intIdEstado)) temp.ID_ESTADO = long.Parse(arrResult[intIdEstado].ToString());
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
        public List<enMicroformaProceso> Microforma_ListarProcesos(enMicroformaProceso entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enMicroformaProceso> lista = new List<enMicroformaProceso>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PROC_CDAMIRCOPROCESO_LISTAR");
            cmd.Parameters.Add(new OracleParameter("XIN_ID_MICROFORMA", OracleDbType.Int64)).Value = entidad.ID_MICROFORMA;
            cmd.Parameters.Add(new OracleParameter("XINT_ID_MICROFORMA_ESTADO", OracleDbType.Int64)).Value = entidad.ID_ESTADO_MICROFORMA==0? null : entidad.ID_ESTADO_MICROFORMA;
            cmd.Parameters.Add(new OracleParameter("XOUT_VALIDO", OracleDbType.Int32)).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(new OracleParameter("XOUT_MENSAJE", OracleDbType.Varchar2, 200)).Direction = System.Data.ParameterDirection.Output;
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
                            enMicroformaProceso temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdMicroProecso = drReader.GetOrdinal("ID_MICROFORMA_PROCESO");
                            int intIdestado = drReader.GetOrdinal("ID_ESTADO_MICROFORMA");
                            int intDesEstado = drReader.GetOrdinal("DESC_ESTADO");
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intUsuCreacion = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("FEC_CREACION");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enMicroformaProceso();

                                if (!drReader.IsDBNull(intIdMicroProecso)) temp.ID_MICROFORMA_PROCESO = long.Parse(arrResult[intIdMicroProecso].ToString());
                                if (!drReader.IsDBNull(intIdestado)) temp.ID_ESTADO_MICROFORMA = long.Parse(arrResult[intIdestado].ToString());
                                if (!drReader.IsDBNull(intDesEstado)) temp.DESC_ESTADO = arrResult[intDesEstado].ToString();
                                if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
                                if (!drReader.IsDBNull(intUsuCreacion)) temp.USU_CREACION = arrResult[intUsuCreacion].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.FEC_CREACION = arrResult[intFecCreacion].ToString();

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
                    lista = new List<enMicroformaProceso>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return lista;
        }
        public enMicroforma Microforma_ListarUno(long ID_MICROFORMA, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            enMicroforma temp = null;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PROC_CDAMICRO_LISTARUNO");
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

                            arrResult = new object[drReader.FieldCount];
                            int intIdMicro = drReader.GetOrdinal("ID_MICROFORMA");
                            int intTipoSoporte = drReader.GetOrdinal("ID_TIPO_SOPORTE");
                            int intDescSoporte = drReader.GetOrdinal("DESC_SOPORTE");
                            int intCodigoSoporte = drReader.GetOrdinal("CODIGO_SOPORTE");
                            int intCodfedatario = drReader.GetOrdinal("CODIGO_FEDATARIO");
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intFecha = drReader.GetOrdinal("FECHA");
                            int intHora = drReader.GetOrdinal("HORA");
                            int intNroVolumen = drReader.GetOrdinal("NRO_VOLUMEN");
                            int intIdApertura = drReader.GetOrdinal("ID_DOC_APERTURA");
                            int intIdCierre = drReader.GetOrdinal("ID_DOC_CIERRE");
                            int intNroActa = drReader.GetOrdinal("NRO_ACTA");
                            int intNroCopias = drReader.GetOrdinal("NRO_COPIAS");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intIdConformidad = drReader.GetOrdinal("ID_DOC_CONFORMIDAD");

                            int intIdDocAlmacenamiento = drReader.GetOrdinal("ID_DOC_ALMACENAMIENTO");
                            int intTipoArchivo = drReader.GetOrdinal("TIPO_ARCHIVO");
                            int intMaDireccion = drReader.GetOrdinal("DIRECCION_MICROARCHIVO");
                            int intMaReponsble = drReader.GetOrdinal("RESPONSABLE_MICROARCHIVO");
                            int intMaFecCreacion = drReader.GetOrdinal("FEC_MICROARCHIVO");
                            int intHoraMicro = drReader.GetOrdinal("HORA_MICROARCHIVO");
                            int intMaObservacion = drReader.GetOrdinal("OBSERVACION_MICROACRCHIVO");

                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enMicroforma();

                                if (!drReader.IsDBNull(intIdMicro)) temp.ID_MICROFORMA = long.Parse(arrResult[intIdMicro].ToString());
                                if (!drReader.IsDBNull(intTipoSoporte)) temp.ID_TIPO_SOPORTE = long.Parse(arrResult[intTipoSoporte].ToString());
                                if (!drReader.IsDBNull(intDescSoporte)) temp.DESC_SOPORTE = arrResult[intDescSoporte].ToString();
                                if (!drReader.IsDBNull(intCodigoSoporte)) temp.CODIGO_SOPORTE = arrResult[intCodigoSoporte].ToString();
                                if (!drReader.IsDBNull(intCodfedatario)) temp.CODIGO_FEDATARIO = arrResult[intCodfedatario].ToString();
                                if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
                                if (!drReader.IsDBNull(intFecha)) temp.FECHA = arrResult[intFecha].ToString();
                                if (!drReader.IsDBNull(intHora)) temp.HORA = arrResult[intHora].ToString();
                                if (!drReader.IsDBNull(intNroVolumen)) temp.NRO_VOLUMEN = arrResult[intNroVolumen].ToString();
                                if (!drReader.IsDBNull(intIdApertura)) temp.ID_DOC_APERTURA = long.Parse(arrResult[intIdApertura].ToString());
                                if (!drReader.IsDBNull(intIdCierre)) temp.ID_DOC_CIERRE = long.Parse(arrResult[intIdCierre].ToString());
                                if (!drReader.IsDBNull(intNroActa)) temp.NRO_ACTA = arrResult[intNroActa].ToString();
                                if (!drReader.IsDBNull(intNroCopias)) temp.NRO_COPIAS = arrResult[intNroCopias].ToString();
                                if (!drReader.IsDBNull(intFecCreacion)) temp.STR_FEC_CREACION = arrResult[intFecCreacion].ToString();
                                if (!drReader.IsDBNull(intIdConformidad)) temp.ID_DOC_CONFORMIDAD = long.Parse(arrResult[intIdConformidad].ToString());

                                if (!drReader.IsDBNull(intIdDocAlmacenamiento)) temp.MicroArchivo.ID_DOC_ALMACENAMIENTO = long.Parse(arrResult[intIdDocAlmacenamiento].ToString());
                                if (!drReader.IsDBNull(intTipoArchivo)) temp.MicroArchivo.TIPO_ARCHIVO = long.Parse(arrResult[intTipoArchivo].ToString());
                                if (!drReader.IsDBNull(intMaDireccion)) temp.MicroArchivo.DIRECCION = arrResult[intMaDireccion].ToString();
                                if (!drReader.IsDBNull(intMaReponsble)) temp.MicroArchivo.RESPONSABLE = arrResult[intMaReponsble].ToString();
                                if (!drReader.IsDBNull(intMaFecCreacion)) temp.MicroArchivo.FECHA = arrResult[intMaFecCreacion].ToString();
                                if (!drReader.IsDBNull(intHoraMicro)) temp.MicroArchivo.HORA = arrResult[intHoraMicro].ToString();
                                if (!drReader.IsDBNull(intMaObservacion)) temp.MicroArchivo.OBSERVACION = arrResult[intMaObservacion].ToString();

                            }
                            drReader.Close();
                        }
                    }
                    //--------------------------------
                }
                catch (Exception ex)
                {
                    auditoria.Error(ex);
                    temp = new enMicroforma();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return temp;
        }

        public List<enMicroArchivo> MicroArchivo_Listar(long ID_MICROFORMA, int FlgEstado, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enMicroArchivo> Lista = new List<enMicroArchivo>(); 
                OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PROC_CDAMICROARCHIVO_LISTAR");
            cmd.Parameters.Add(new OracleParameter("XIN_ID_MICROFORMA", OracleDbType.Int64)).Value = ID_MICROFORMA;
            cmd.Parameters.Add(new OracleParameter("XINT_FLG_ESTADO", OracleDbType.Int64)).Value = FlgEstado;
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
                            enMicroArchivo temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdMicroA = drReader.GetOrdinal("ID_MICROARCHIVO");
                            int intIdDocConforma = drReader.GetOrdinal("ID_DOC_CONFORMIDAD");
                            int intTipoArchivo = drReader.GetOrdinal("TIPO_ARCHIVO");
                            int intMaDireccion = drReader.GetOrdinal("DIRECCION");
                            int intFecha = drReader.GetOrdinal("FECHA");
                            int intHora = drReader.GetOrdinal("HORA");
                            int intMaReponsble = drReader.GetOrdinal("RESPONSABLE");
                            int intMaFecCreacion = drReader.GetOrdinal("FEC_CREACION");
                            int intMaObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intStrTipoArchivo = drReader.GetOrdinal("STR_TIPO_ARCHIVO");
                            
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enMicroArchivo();
                                if (!drReader.IsDBNull(intIdMicroA)) temp.ID_MICROARCHIVO = long.Parse(arrResult[intIdMicroA].ToString());
                                if (!drReader.IsDBNull(intIdDocConforma)) temp.ID_DOC_ALMACENAMIENTO = long.Parse(arrResult[intIdDocConforma].ToString());
                                if (!drReader.IsDBNull(intTipoArchivo)) temp.TIPO_ARCHIVO = long.Parse(arrResult[intTipoArchivo].ToString());
                                if (!drReader.IsDBNull(intMaDireccion)) temp.DIRECCION = arrResult[intMaDireccion].ToString();
                                if (!drReader.IsDBNull(intFecha)) temp.FECHA = arrResult[intFecha].ToString();
                                if (!drReader.IsDBNull(intHora)) temp.HORA = arrResult[intHora].ToString();
                                if (!drReader.IsDBNull(intMaReponsble)) temp.RESPONSABLE = arrResult[intMaReponsble].ToString();
                                if (!drReader.IsDBNull(intMaFecCreacion)) temp.FEC_CREACION = arrResult[intMaFecCreacion].ToString();
                                if (!drReader.IsDBNull(intMaObservacion)) temp.OBSERVACION = arrResult[intMaObservacion].ToString();
                                if (!drReader.IsDBNull(intStrTipoArchivo)) temp.STR_TIPO_ARCHIVO = arrResult[intStrTipoArchivo].ToString();
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
                    Lista = new List<enMicroArchivo>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return Lista;
        }

        public List<enRevision> Revision_Listar(long ID_MICROFORMA, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enRevision> Lista = new List<enRevision>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PROC_CDAREVISION_LISTARUNO");
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

                            arrResult = new object[drReader.FieldCount];
                            int intIdRevision = drReader.GetOrdinal("ID_REVISION");
                            int intIdMicroforma = drReader.GetOrdinal("ID_MICROFORMA");
                            int intIdDoc = drReader.GetOrdinal("ID_DOC_REVISION");
                            int intResponsable = drReader.GetOrdinal("RESPONSABLE");
                            int intConforme = drReader.GetOrdinal("STR_FLG_CONFORME");
                            int intAccion = drReader.GetOrdinal("STR_FLG_ACCION");
                            int intTipoPrueba = drReader.GetOrdinal("TIPO_PRUEBA");
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intFecRevision = drReader.GetOrdinal("FEC_REVISION");
                            enRevision temp = null; 
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enRevision();
                                if (!drReader.IsDBNull(intIdRevision)) temp.ID_REVISION = long.Parse(arrResult[intIdRevision].ToString());
                                if (!drReader.IsDBNull(intIdMicroforma)) temp.ID_MICROFORMA = long.Parse(arrResult[intIdMicroforma].ToString());
                                if (!drReader.IsDBNull(intIdDoc)) temp.ID_DOC_REVISION = long.Parse(arrResult[intIdDoc].ToString());
                                if (!drReader.IsDBNull(intResponsable)) temp.RESPONSABLE = arrResult[intResponsable].ToString();
                                if (!drReader.IsDBNull(intConforme)) temp.STR_FLG_CONFORME = arrResult[intConforme].ToString();
                                if (!drReader.IsDBNull(intAccion)) temp.STR_FLG_ACCION = arrResult[intAccion].ToString();
                                if (!drReader.IsDBNull(intTipoPrueba)) temp.TIPO_PRUEBA = arrResult[intTipoPrueba].ToString();
                                if (!drReader.IsDBNull(intObservacion)) temp.OBSERVACION = arrResult[intObservacion].ToString();
                                if (!drReader.IsDBNull(intFecRevision)) temp.FEC_REVISION = arrResult[intFecRevision].ToString();
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
                    Lista = new List<enRevision>();
                }
                finally
                {
                    if (cn.State != System.Data.ConnectionState.Closed) cn.Close();
                    if (cn.State == System.Data.ConnectionState.Closed) cn.Dispose();
                }
            }
            return Lista;
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
        public void Microforma_Insertar(MicroModel entidad, ref enAuditoria auditoria)
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
                cmd.Parameters.Add(new OracleParameter("XIN_NRO_VOLUMEN", OracleDbType.Varchar2)).Value = entidad.NroVolumen;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_DOC_APERTURA", OracleDbType.Int64)).Value = entidad.IdDocApertura;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_ID_DOC_CIERRE", OracleDbType.Int64)).Value = entidad.IdDocCierre;
                cmd.Parameters.Add(new OracleParameter("XIN_OBSERVACION", OracleDbType.Varchar2)).Value = entidad.Observacion;
                cmd.Parameters.Add(new OracleParameter("XIN_FECHA", OracleDbType.Varchar2)).Value = entidad.Fecha;
                cmd.Parameters.Add(new OracleParameter("XIN_HORA", OracleDbType.Varchar2)).Value = entidad.Hora;
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
                            foreach (MicroModel item in entidad.ListaIdsLotes)
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
        public void Microforma_Evaluar(MicroEvaluarModel entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PROC_CDAMICROFORMA_EVALUAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_MICROFORMA", OracleDbType.Varchar2)).Value = entidad.IdMicroforma;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_ESTADO_MICROFORMA", OracleDbType.Varchar2)).Value = entidad.IdEstado;
                cmd.Parameters.Add(new OracleParameter("XIN_OBSERVACION", OracleDbType.Varchar2)).Value = entidad.Observacion;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_DOC_CONFORMIDAD", OracleDbType.Int64)).Value = entidad.IdDocConformidad;
                cmd.Parameters.Add(new OracleParameter("XIN_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.UsuCreacion;
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
        public void Microforma_Reprocesar(MicroModel entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PROC_CDAMICROFORMA_REPROCESO"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_MICROFORMA", OracleDbType.Int64)).Value = entidad.IdMicroforma;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_TIPO_SOPORTE", OracleDbType.Int64)).Value = entidad.IdSoporte;
                cmd.Parameters.Add(new OracleParameter("XIN_CODIGO_SOPORTE", OracleDbType.Varchar2)).Value = entidad.CodigoSoporte;
                cmd.Parameters.Add(new OracleParameter("XIN_NRO_ACTA", OracleDbType.Varchar2)).Value = entidad.NroActa;
                cmd.Parameters.Add(new OracleParameter("XIN_NRO_COPIAS", OracleDbType.Varchar2)).Value = entidad.NroCopias;
                cmd.Parameters.Add(new OracleParameter("XIN_CODIGO_FEDATARIO", OracleDbType.Varchar2)).Value = entidad.CodigoFedatario;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_DOC_APERTURA", OracleDbType.Int64)).Value = entidad.IdDocApertura;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_ID_DOC_CIERRE", OracleDbType.Int64)).Value = entidad.IdDocCierre;
                cmd.Parameters.Add(new OracleParameter("XIN_OBSERVACION", OracleDbType.Varchar2)).Value = entidad.Observacion;
                cmd.Parameters.Add(new OracleParameter("XIN_FECHA", OracleDbType.Varchar2)).Value = entidad.Fecha;
                cmd.Parameters.Add(new OracleParameter("XIN_HORA", OracleDbType.Varchar2)).Value = entidad.Hora;
                cmd.Parameters.Add(new OracleParameter("XIN_USU_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.UsuModificacion;
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

        public void Microforma_MicroArchivo(MicroArchivoModels entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PROC_CDAMICROARCHIVO_INSERTAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_MICROFORMA", OracleDbType.Int64)).Value = entidad.IdMicroforma;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_DOC_CONFORMIDAD", OracleDbType.Int64)).Value = entidad.IdDocAlmacenamiento;
                cmd.Parameters.Add(new OracleParameter("XIN_TIPO_ARCHIVO", OracleDbType.Int64)).Value = entidad.TipoArchivo;
                cmd.Parameters.Add(new OracleParameter("XIN_DIRECCION", OracleDbType.Varchar2)).Value = entidad.Direccion;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_USUARIO", OracleDbType.Varchar2)).Value = entidad.IdUsuario;
                cmd.Parameters.Add(new OracleParameter("XIN_FECHA", OracleDbType.Varchar2)).Value = entidad.Fecha;
                cmd.Parameters.Add(new OracleParameter("XIN_HORA", OracleDbType.Varchar2)).Value = entidad.Hora;
                cmd.Parameters.Add(new OracleParameter("XIN_OBSERVACION", OracleDbType.Varchar2)).Value = entidad.Observacion;
                cmd.Parameters.Add(new OracleParameter("XIN_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.Usucreacion;
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

        public void Microforma_MicroArchivoEstado(MicroArchivoModels entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PROC_CDAMICROARCHIVO_ESTADO"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_MICROFORMA", OracleDbType.Int64)).Value = entidad.IdMicroforma;
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

        public void Microforma_RevisionPeriodica(RevsionPeriodicaModel entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PROC_CDAMICROREVISION_INSERTAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_MICROFORMA", OracleDbType.Int64)).Value = entidad.IdMicroforma;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_ESTADO_MICROFORMA", OracleDbType.Int64)).Value = entidad.IdEstado;
                cmd.Parameters.Add(new OracleParameter("XIN_FLG_CONFORME", OracleDbType.Varchar2)).Value = entidad.FlgConforme;
                cmd.Parameters.Add(new OracleParameter("XIN_FLG_ACCION", OracleDbType.Varchar2)).Value = entidad.FlgAccion;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_USUARIO", OracleDbType.Int64)).Value = entidad.IdUsuario;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_DOC_REVISION", OracleDbType.Int64)).Value = entidad.IdDocRevision;
                cmd.Parameters.Add(new OracleParameter("XIN_TIPO_PRUEBA", OracleDbType.Varchar2)).Value = entidad.TipoPrueba;
                cmd.Parameters.Add(new OracleParameter("XIN_OBSERVACION", OracleDbType.Varchar2)).Value = entidad.Observacion;
                cmd.Parameters.Add(new OracleParameter("XIN_FEC_REVISION", OracleDbType.Varchar2)).Value = entidad.FecRevision;
                cmd.Parameters.Add(new OracleParameter("XIN_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.UsuCreacion;
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
        public void Microforma_Desarchivar(MicroArchivoModels entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PROC_CDAMICRO_DESARCHIVAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_MICROFORMA", OracleDbType.Int64)).Value = entidad.IdMicroforma;
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
        public void Microforma_RevisionReprocesar(MicroModel entidad, ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            using (OracleConnection cn = new OracleConnection(base.CadenaConexion))
            {
                cn.Open();
                OracleDataReader dr = null;
                OracleCommand cmd = new OracleCommand(string.Format("{0}.{1}", AppSettingsHelper.PackDigitalMant, "PROC_CDAREVISION_REPROCESAR"), cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_MICROFORMA", OracleDbType.Int64)).Value = entidad.IdMicroforma;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_TIPO_SOPORTE", OracleDbType.Int64)).Value = entidad.IdSoporte;
                cmd.Parameters.Add(new OracleParameter("XIN_CODIGO_SOPORTE", OracleDbType.Varchar2)).Value = entidad.CodigoSoporte;
                cmd.Parameters.Add(new OracleParameter("XIN_NRO_ACTA", OracleDbType.Varchar2)).Value = entidad.NroActa;
                cmd.Parameters.Add(new OracleParameter("XIN_NRO_COPIAS", OracleDbType.Varchar2)).Value = entidad.NroCopias;
                cmd.Parameters.Add(new OracleParameter("XIN_CODIGO_FEDATARIO", OracleDbType.Varchar2)).Value = entidad.CodigoFedatario;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_DOC_APERTURA", OracleDbType.Int64)).Value = entidad.IdDocApertura;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_DOC_CIERRE", OracleDbType.Int64)).Value = entidad.IdDocCierre;
                cmd.Parameters.Add(new OracleParameter("XIN_ID_DOC_CONFORMIDAD", OracleDbType.Int64)).Value = entidad.IdDocConformidad;
                cmd.Parameters.Add(new OracleParameter("XIN_OBSERVACION", OracleDbType.Varchar2)).Value = entidad.Observacion;
                cmd.Parameters.Add(new OracleParameter("XIN_FECHA", OracleDbType.Varchar2)).Value = entidad.Fecha;
                cmd.Parameters.Add(new OracleParameter("XIN_HORA", OracleDbType.Varchar2)).Value = entidad.Hora;
                cmd.Parameters.Add(new OracleParameter("XIN_USU_MODIFICACION", OracleDbType.Varchar2)).Value = entidad.UsuCreacion;

                cmd.Parameters.Add(new OracleParameter("XIN_ID_DOC_ALMACENAMIENTO", OracleDbType.Int64)).Value = entidad.MicroArchivo.IdDocAlmacenamiento;
                cmd.Parameters.Add(new OracleParameter("XIN_MA_TIPO_ARCHIVO", OracleDbType.Int64)).Value = entidad.MicroArchivo.TipoArchivo;
                cmd.Parameters.Add(new OracleParameter("XIN_MA_DIRECCION", OracleDbType.Varchar2)).Value = entidad.MicroArchivo.Direccion;
                cmd.Parameters.Add(new OracleParameter("XIN_MA_ID_USUARIO", OracleDbType.Varchar2)).Value = entidad.MicroArchivo.IdUsuario;
                cmd.Parameters.Add(new OracleParameter("XIN_MA_FECHA", OracleDbType.Varchar2)).Value = entidad.MicroArchivo.Fecha;
                cmd.Parameters.Add(new OracleParameter("XIN_MA_HORA", OracleDbType.Varchar2)).Value = entidad.MicroArchivo.Hora;
                cmd.Parameters.Add(new OracleParameter("XIN_MA_OBSERVACION", OracleDbType.Varchar2)).Value = entidad.MicroArchivo.Observacion;
                cmd.Parameters.Add(new OracleParameter("XIN_MA_USU_CREACION", OracleDbType.Varchar2)).Value = entidad.MicroArchivo.Usucreacion;
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
