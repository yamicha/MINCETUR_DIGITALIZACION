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
            cmd.CommandText = string.Format("{0}.{1}", AppSettingsHelper.PackDigitalCons, "PROC_CDADOC_TEMP_PAGINACION");
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
                            enDocumentoTemporal temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdDocumento = drReader.GetOrdinal("ID_DOCUMENTO");
                            int intIdcontrolCarga= drReader.GetOrdinal("ID_CONTROL_CARGA");
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
                            int intObservacion = drReader.GetOrdinal("OBSERVACION");
                            int intUsuariocreacion = drReader.GetOrdinal("USU_CREACION");
                            int intFecCreacion = drReader.GetOrdinal("STR_FEC_CREACION");
                            int intUsuModific = drReader.GetOrdinal("USU_MODIFICACION");
                            int intFecModific = drReader.GetOrdinal("STR_FEC_MODIFICACION");

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
                                if (!drReader.IsDBNull(intDesSeccion)) temp.DES_LARGA_SECCION = arrResult[intDesSeccion].ToString();
                                if (!drReader.IsDBNull(intIdSerie)) temp.ID_SERIE = arrResult[intIdSerie].ToString();
                                if (!drReader.IsDBNull(intDesSerie)) temp.DES_SERIE = arrResult[intDesSerie].ToString();
                                if (!drReader.IsDBNull(intNomDocumento)) temp.NOM_DOCUMENTO = arrResult[intNomDocumento].ToString();
                                if (!drReader.IsDBNull(intAnio)) temp.ANIO = arrResult[intAnio].ToString();
                                if (!drReader.IsDBNull(intFolios)) temp.FOLIOS = arrResult[intFolios].ToString();
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


    }
}
