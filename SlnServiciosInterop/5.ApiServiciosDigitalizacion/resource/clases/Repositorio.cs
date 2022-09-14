using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoServiciosDigitalizacion;
using NeServiciosDigitalizacion;


namespace ApiServiciosDigitalizacion.resource.clases
{
    public class Repositorio
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;

        public Repositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
        }

        public Models.ResultadoMigraModel consultarDocumento(Models.DatosMigraModel mdlDatosMigra)
        {
            if (mdlDatosMigra == null) mdlDatosMigra = new Models.DatosMigraModel() { SolicitudModel = new Models.SolicitudModel(), CredencialModel = new Models.CredencialModel() };
            Models.ResultadoMigraModel mdlResultadoMigra = new Models.ResultadoMigraModel()
            {
                ResultadoErrorModel = new Models.ResultadoErrorModel { IdTipo = 2, DesError = "Error en el servicio" },
                RespuestaDocumentoModel = new Models.RespuestaDocumentoModel { NumRespuesta = "-1"}
            };
            int intIdPersona = -1;
            int.TryParse(mdlDatosMigra.CredencialModel.Usuario, out intIdPersona);
            System.Text.StringBuilder sbAuditoria = new System.Text.StringBuilder();
            sbAuditoria.Append("api/Migraciones/consultarDocumento ");
            sbAuditoria.Append(System.Text.Json.JsonSerializer.Serialize(mdlDatosMigra.SolicitudModel));
            sbAuditoria.Append(string.Format(" - HoraIni: {0}", System.DateTime.Now.ToString("hh:mm:ss")));
            if (new neUsuSisRolEntEstorg(this._objCoConexionDb).ValidaUsuSisPin(new EnServiciosDigitalizacion.enUsuSisRolEntEstorg()
            {
                ID_ENT = -1,
                ID_USU = intIdPersona,
                PIN = mdlDatosMigra.CredencialModel.Pin,
                ID_SIS = this._ConfigurationManager.Value.AppSettings.IdSis,
                FLG_EST = 1,
                OPR = "3"
            }))
            {
                if (this._objCoConexionDb.ServerCnx.ToUpper() == "PRODU")
                {
                    try
                    {
                        ServicioPide.Produ.WCFPideMigraCarnetExtranjeria.WCFPideMigraCarnetExtranjeriaClient wcf = new ServicioPide.Produ.WCFPideMigraCarnetExtranjeria.WCFPideMigraCarnetExtranjeriaClient();
                        Task<ServicioPide.Produ.WCFPideMigraCarnetExtranjeria.respuestaBean> objRespuestaBean = wcf.consultarDocumentoAsync(new ServicioPide.Produ.WCFPideMigraCarnetExtranjeria.solicitudBean()
                        {
                            strTipoDocumentoField = this._ConfigurationManager.Value.AppSettings.TipoDocumentoDefecto,
                            strNumDocumentoField = mdlDatosMigra.SolicitudModel.NumDocumento
                        });
                        if (objRespuestaBean.Result != null)
                        {
                            mdlResultadoMigra = new Models.ResultadoMigraModel()
                            {
                                ResultadoErrorModel = new Models.ResultadoErrorModel() { IdTipo = 0, DesError = obtenerRespuesta(objRespuestaBean.Result.strNumRespuestaField).DES_ERROR },
                                RespuestaDocumentoModel = new Models.RespuestaDocumentoModel()
                                {
                                    NumRespuesta = objRespuestaBean.Result.strNumRespuestaField,
                                    CalidadMigratoria = objRespuestaBean.Result.strCalidadMigratoriaField,
                                    Nombres = objRespuestaBean.Result.strNombresField,
                                    PrimerApellido = objRespuestaBean.Result.strPrimerApellidoField,
                                    SegundoApellido = objRespuestaBean.Result.strSegundoApellidoField
                                }
                            };
                        }
                        else
                        {
                            mdlResultadoMigra = new Models.ResultadoMigraModel()
                            {
                                ResultadoErrorModel = new Models.ResultadoErrorModel() { IdTipo = 2, DesError = objRespuestaBean.Status.ToString() }
                            };
                        }

                    }
                    catch (Exception ex)
                    {
                        mdlResultadoMigra = new Models.ResultadoMigraModel()
                        {
                            ResultadoErrorModel = new Models.ResultadoErrorModel() { IdTipo = 1, DesError = ex.ToString() }
                        };
                    }
                }
                else
                {
                    try
                    {
                        ServicioPide.QA.WCFPideMigraCarnetExtranjeria.WCFPideMigraCarnetExtranjeriaClient wcf = new ServicioPide.QA.WCFPideMigraCarnetExtranjeria.WCFPideMigraCarnetExtranjeriaClient();
                        Task<ServicioPide.QA.WCFPideMigraCarnetExtranjeria.respuestaBean> objRespuestaBean = wcf.consultarDocumentoAsync(new ServicioPide.QA.WCFPideMigraCarnetExtranjeria.solicitudBean()
                        {
                            strTipoDocumentoField = this._ConfigurationManager.Value.AppSettings.TipoDocumentoDefecto,
                            strNumDocumentoField = mdlDatosMigra.SolicitudModel.NumDocumento
                        });
                        if (objRespuestaBean.Result != null)
                        {
                            mdlResultadoMigra = new Models.ResultadoMigraModel()
                            {
                                ResultadoErrorModel = new Models.ResultadoErrorModel() { IdTipo = 0, DesError = obtenerRespuesta(objRespuestaBean.Result.strNumRespuestaField).DES_ERROR },
                                RespuestaDocumentoModel = new Models.RespuestaDocumentoModel()
                                {
                                    NumRespuesta = objRespuestaBean.Result.strNumRespuestaField,
                                    CalidadMigratoria = objRespuestaBean.Result.strCalidadMigratoriaField,
                                    Nombres = objRespuestaBean.Result.strNombresField,
                                    PrimerApellido = objRespuestaBean.Result.strPrimerApellidoField,
                                    SegundoApellido = objRespuestaBean.Result.strSegundoApellidoField
                                }
                            };
                        }
                        else
                        {
                            mdlResultadoMigra = new Models.ResultadoMigraModel()
                            {
                                ResultadoErrorModel = new Models.ResultadoErrorModel() { IdTipo = 2, DesError = objRespuestaBean.Status.ToString() }
                            };
                        }

                    }
                    catch (Exception ex)
                    {
                        mdlResultadoMigra = new Models.ResultadoMigraModel()
                        {
                            ResultadoErrorModel = new Models.ResultadoErrorModel() { IdTipo = 1, DesError = ex.ToString() }
                        };
                    }
                }

            }
            sbAuditoria.Append(string.Format(" - HoraFin: {0}", System.DateTime.Now.ToString("hh:mm:ss")));
            if (mdlResultadoMigra.ResultadoErrorModel.IdTipo == 1)
            {
                new neAccesoThread(this._objCoConexionDb.ServerCnx).enviarAccesoAsincrono(new EnServiciosDigitalizacion.enAcceso()
                {
                    ID_SIS = this._ConfigurationManager.Value.AppSettings.IdSis,
                    COD_FUENTE = "S",
                    ID_PERSONA = intIdPersona,
                    IP_ACCESO = obtenerIp(),
                    DES_URL = sbAuditoria.ToString(),
                    DES_OBS = mdlResultadoMigra.ResultadoErrorModel.DesError,
                    ID_TIPOACCESO = -1
                });
            } else
            {

                new neAccesoThread(this._objCoConexionDb.ServerCnx).enviarAccesoAsincrono(new EnServiciosDigitalizacion.enAcceso()
                {
                    ID_SIS = this._ConfigurationManager.Value.AppSettings.IdSis,
                    COD_FUENTE = "S",
                    ID_PERSONA = intIdPersona,
                    ID_TIPOACCESO = (mdlResultadoMigra.ResultadoErrorModel.IdTipo == 2 ? 2 : 3),
                    IP_ACCESO = obtenerIp(),
                    DES_OBS = sbAuditoria.ToString()
                });
            }
            return mdlResultadoMigra;
        }

        private coResultado obtenerRespuesta(string strNumRespuesta)
        {
            string strDesRespuesta = this._ConfigurationManager.Value.AppSettings.ManejoErrores;
            try
            {
                return strDesRespuesta.Split("|").Select(x => new coResultado() { 
                    ID_TIPO = (x.Split(":")[0].Trim() == "0000" ? 0 : 2), 
                    ID_ERROR = x.Split(":")[0].Trim(), 
                    DES_ERROR = x
                }).Where(x => x.ID_ERROR == strNumRespuesta).First<coResultado>();
            } catch (Exception ex)
            {
                return new coResultado() { ID_TIPO = 1, ID_ERROR = "-1", DES_ERROR = ex.ToString() };
            }
        }
        private static string obtenerIp()
        {
            try
            {
                return new Microsoft.AspNetCore.Http.HttpContextAccessor().HttpContext?.Connection.RemoteIpAddress.ToString();
            } catch {
                return "::1";
            }
        }
    }
}
