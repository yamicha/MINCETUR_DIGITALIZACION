using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using CoServiciosMicroformas;

namespace DaServiciosMicroformas
{
    public class daUDml : daBase
    {
        public daUDml(coConexionDb objCoConexion) : base(objCoConexion) { }
        public coResultado ejecutarDml(OracleParameter[] cmdParameters, string strCommandText)
        {
            coResultado objCoResultadoDB = new coResultado();
            using (OracleConnection cnn = new OracleConnection(base.CadenaConexion))
            {
                try
                {
                    cnn.Open();
                    using (OracleTransaction trx = cnn.BeginTransaction())
                    {
                        OracleCommand cmd = new OracleCommand();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = strCommandText;
                        cmd.Connection = cnn;
                        cmd.Parameters.AddRange(cmdParameters);
                        cmd.Transaction = trx;

                        using (OracleDataReader drReader = cmd.ExecuteReader())
                        {
                            if (drReader.Read())
                            {
                                if (!drReader.IsDBNull(drReader.GetOrdinal("ID_TIPO"))) objCoResultadoDB.ID_TIPO = int.Parse(drReader["ID_TIPO"].ToString());
                                if (!drReader.IsDBNull(drReader.GetOrdinal("ID_ERROR"))) objCoResultadoDB.ID_ERROR = drReader["ID_ERROR"].ToString();
                                if (!drReader.IsDBNull(drReader.GetOrdinal("DES_ERROR"))) objCoResultadoDB.DES_ERROR = drReader["DES_ERROR"].ToString();
                                for (int i = 0; i < drReader.FieldCount; i++)
                                {
                                    if (drReader.GetName(i).Equals("VALOR", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        if (!drReader.IsDBNull(drReader.GetOrdinal("VALOR"))) objCoResultadoDB.VALOR = drReader["VALOR"].ToString();
                                    }
                                    else if (drReader.GetName(i).Equals("VALOR1", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        if (!drReader.IsDBNull(drReader.GetOrdinal("VALOR1"))) objCoResultadoDB.VALOR1 = drReader["VALOR1"].ToString();
                                    }
                                    else if (drReader.GetName(i).Equals("VALOR2", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        if (!drReader.IsDBNull(drReader.GetOrdinal("VALOR2"))) objCoResultadoDB.VALOR2 = drReader["VALOR2"].ToString();
                                    }
                                }
                            }
                        }
                        if (objCoResultadoDB.ID_TIPO == 0)
                        {
                            trx.Commit();
                        }
                        else
                        {
                            trx.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    objCoResultadoDB.ID_TIPO = 1;
                    objCoResultadoDB.ID_ERROR = "";
                    objCoResultadoDB.DES_ERROR = ex.Message;
                }
                finally
                {
                    if (cnn.State != System.Data.ConnectionState.Closed)
                    {
                        cnn.Close();
                    }
                    if (cnn.State == System.Data.ConnectionState.Closed)
                    {
                        cnn.Dispose();
                    }
                }
            }
            return objCoResultadoDB;
        }
    }
}
