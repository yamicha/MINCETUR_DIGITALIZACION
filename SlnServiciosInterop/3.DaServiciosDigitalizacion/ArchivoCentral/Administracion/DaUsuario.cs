using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using Utilitarios.Helpers;
namespace DaServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class DaUsuario : daBase
    {
        public DaUsuario(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }

        public List<enUsuario> Usuario_Listar( ref enAuditoria auditoria)
        {
            auditoria.Limpiar();
            List<enUsuario> lista = new List<enUsuario>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = AppSettingsHelper.PackAdminConsulta + ".PRC_CDAUSUARIO_LISTAR";
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
                            enUsuario temp = null;
                            arrResult = new object[drReader.FieldCount];
                            int intIdUsuario = drReader.GetOrdinal("ID_USUARIO");
                            int intNombre = drReader.GetOrdinal("NOMBRE_USUARIO");
                            while (drReader.Read())
                            {
                                drReader.GetValues(arrResult);
                                temp = new enUsuario();

                                if (!drReader.IsDBNull(intIdUsuario)) temp.ID_USUARIO = int.Parse(arrResult[intIdUsuario].ToString());
                                if (!drReader.IsDBNull(intNombre)) temp.NOMBRE_USUARIO = arrResult[intNombre].ToString();

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
                    lista = new List<enUsuario>();
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
