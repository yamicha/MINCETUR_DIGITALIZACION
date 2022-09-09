using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using CoServiciosMicroformas;
using EnServiciosMicroformas;
using EnServiciosMicroformas.ArchivoCentral; 

namespace DaServiciosMicroformas.Archivo_Central
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
            cmd.CommandText = "INSDBA.PCK_CDAADMINCONS.PRC_CDASECCION_LISTAR";
            cmd.Parameters.Add("X_DESC_SECCION", validarNulo(objenSeccion.DESC_CORTA_SECCION));
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
                            int intCodSeccion = drReader.GetOrdinal("COD_SECCION");
                            int intDescCorta = drReader.GetOrdinal("DESC_CORTA_SECCION");
                            int intDescLarga = drReader.GetOrdinal("DESC_LARGA_SECCION");

                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enSeccion();

                                if (!drReader.IsDBNull(intIdSeccion)) temp.ID_SECCION = int.Parse(arrResult[intIdSeccion].ToString());
                                if (!drReader.IsDBNull(intCodSeccion)) temp.COD_SECCION = arrResult[intCodSeccion].ToString();
                                if (!drReader.IsDBNull(intDescCorta)) temp.DESC_CORTA_SECCION = arrResult[intDescCorta].ToString();
                                if (!drReader.IsDBNull(intDescLarga)) temp.DESC_LARGA_SECCION =arrResult[intDescLarga].ToString();


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


    }
}
