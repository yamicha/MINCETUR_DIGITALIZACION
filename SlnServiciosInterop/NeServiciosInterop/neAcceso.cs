using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnServiciosMicroformas;

namespace NeServiciosMicroformas
{
    public class neAcceso : neBase
    {
        public neAcceso(string strServerCnx) : base(new CoServiciosMicroformas.coConexionDb() { ServerCnx = strServerCnx })
        {

        }

        public void enviarAcceso(enAcceso objEnAcceso)
        {
            if (objEnAcceso == null) objEnAcceso = new enAcceso();
            if (objEnAcceso.ID_TIPOACCESO == -1)
            {
                if (base.objCoConexionDb.ServerCnx.ToUpper() == "PRODU")
                {
                    try
                    {
                        ServicioSeguridad.Produ.WCFSeguridadLog.coResultadoDB objCoResultado = new ServicioSeguridad.Produ.WCFSeguridadLog.WCFSeguridadLogClient().logAsync(
                            new ServicioSeguridad.Produ.WCFSeguridadLog.enLogError()
                            {
                                ID_SIS = objEnAcceso.ID_SIS,
                                COD_FUENTE = objEnAcceso.COD_FUENTE,
                                DES_PAGINAOBJETO = objEnAcceso.DES_URL,
                                DES_ERROR = objEnAcceso.DES_OBS,
                                USU_CREA = objEnAcceso.ID_PERSONA,
                                IP_CREA = objEnAcceso.IP_ACCESO
                            }
                        ).Result;
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        ServicioSeguridad.QA.WCFSeguridadLog.coResultadoDB objCoResultado = new ServicioSeguridad.QA.WCFSeguridadLog.WCFSeguridadLogClient().logAsync(
                            new ServicioSeguridad.QA.WCFSeguridadLog.enLogError()
                            {
                                ID_SIS = objEnAcceso.ID_SIS,
                                COD_FUENTE = objEnAcceso.COD_FUENTE,
                                DES_PAGINAOBJETO = objEnAcceso.DES_URL,
                                DES_ERROR = objEnAcceso.DES_OBS,
                                USU_CREA = objEnAcceso.ID_PERSONA,
                                IP_CREA = objEnAcceso.IP_ACCESO
                            }
                        ).Result;
                    }
                    catch { }
                }
            } else 
            {
                if (base.objCoConexionDb.ServerCnx.ToUpper() == "PRODU")
                {
                    try
                    {
                        ServicioSeguridad.Produ.WCFSeguridadSistema.coResultadoDB objCoResultado = new ServicioSeguridad.Produ.WCFSeguridadSistema.WCFSeguridadSistemaClient().enviarAccesoAsync(
                            new ServicioSeguridad.Produ.WCFSeguridadSistema.enAcceso()
                            {
                                ID_SIS = objEnAcceso.ID_SIS,
                                COD_FUENTE = objEnAcceso.COD_FUENTE,
                                ID_PERSONA = objEnAcceso.ID_PERSONA,
                                ID_TIPOACCESO = objEnAcceso.ID_TIPOACCESO,
                                IP_ACCESO = objEnAcceso.IP_ACCESO,
                                DES_OBS = objEnAcceso.DES_OBS
                            }).Result;
                    }
                    catch {}
                }
                else
                {
                    try
                    {
                        ServicioSeguridad.QA.WCFSeguridadSistema.coResultadoDB objCoResultado = new ServicioSeguridad.QA.WCFSeguridadSistema.WCFSeguridadSistemaClient().enviarAccesoAsync(
                        new ServicioSeguridad.QA.WCFSeguridadSistema.enAcceso()
                        {
                            ID_SIS = objEnAcceso.ID_SIS,
                            COD_FUENTE = objEnAcceso.COD_FUENTE,
                            ID_PERSONA = objEnAcceso.ID_PERSONA,
                            ID_TIPOACCESO = objEnAcceso.ID_TIPOACCESO,
                            IP_ACCESO = objEnAcceso.IP_ACCESO,
                            DES_OBS = objEnAcceso.DES_OBS
                        }).Result;
                    }
                    catch { }
                }
            }
        }
    }
}
