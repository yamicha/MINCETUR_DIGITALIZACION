using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosMicroformas;
using EnServiciosMicroformas;

namespace NeServiciosMicroformas
{
    public class neUsuSisRolEntEstorg : neBase
    {
        public neUsuSisRolEntEstorg(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //constructor
        }

        public bool ValidaUsuSisPin(enUsuSisRolEntEstorg objEnUsuSisRolEntEstorg)
        {
            bool bValida = false;
            if (objEnUsuSisRolEntEstorg == null) objEnUsuSisRolEntEstorg = new enUsuSisRolEntEstorg();
            if (!string.IsNullOrEmpty(objEnUsuSisRolEntEstorg.PIN))
            {
                enResultadoEnListaUsuSisPin objEnResultadoEnListaUsuSisPin = new neUsuSisPin(base.objCoConexionDb).listar(new enUsuSisPin()
                {
                    ID_USU = objEnUsuSisRolEntEstorg.ID_USU,
                    ID_SIS = objEnUsuSisRolEntEstorg.ID_SIS,
                    DES_PIN = objEnUsuSisRolEntEstorg.PIN
                });

                if (objEnResultadoEnListaUsuSisPin.ID_TIPO == 0)
                {
                    if (base.objCoConexionDb.ServerCnx.ToUpper() == "PRODU")
                    {
                        ServicioSeguridad.Produ.WCFSeguridadUsuSisRolEntEstorg.ResultadoUsuSisRolEstorg objResultadoUsuSisRolEntEstorg =
                            new ServicioSeguridad.Produ.WCFSeguridadUsuSisRolEntEstorg.WCFSeguridadUsuSisRolEntEstorgClient().listarUsuSisRolEntEstorgAsync(
                                new ServicioSeguridad.Produ.WCFSeguridadUsuSisRolEntEstorg.DatosUsuSisRolEstorg()
                                {
                                    IdEnt = objEnUsuSisRolEntEstorg.ID_ENT,
                                    IdUsu = objEnUsuSisRolEntEstorg.ID_USU,
                                    IdSub = -1,
                                    FlgEst = objEnUsuSisRolEntEstorg.FLG_EST,
                                    Opr = objEnUsuSisRolEntEstorg.OPR
                                }).Result;
                        if (objResultadoUsuSisRolEntEstorg != null)
                        {
                            if (objResultadoUsuSisRolEntEstorg.IdTipo == 0 && objResultadoUsuSisRolEntEstorg.lstUsuSisRolEntEstorg != null)
                            {
                                if (objResultadoUsuSisRolEntEstorg.lstUsuSisRolEntEstorg.Length > 0) bValida = true;
                            }
                        }
                    }
                    else
                    {
                        ServicioSeguridad.QA.WCFSeguridadUsuSisRolEntEstorg.ResultadoUsuSisRolEstorg objResultadoUsuSisRolEntEstorg =
                            new ServicioSeguridad.QA.WCFSeguridadUsuSisRolEntEstorg.WCFSeguridadUsuSisRolEntEstorgClient().listarUsuSisRolEntEstorgAsync(
                                new ServicioSeguridad.QA.WCFSeguridadUsuSisRolEntEstorg.DatosUsuSisRolEstorg()
                                {
                                    IdEnt = objEnUsuSisRolEntEstorg.ID_ENT,
                                    IdUsu = objEnUsuSisRolEntEstorg.ID_USU,
                                    IdSub = -1,
                                    FlgEst = objEnUsuSisRolEntEstorg.FLG_EST,
                                    Opr = objEnUsuSisRolEntEstorg.OPR,
                                }).Result;
                        if (objResultadoUsuSisRolEntEstorg != null)
                        {
                            if (objResultadoUsuSisRolEntEstorg.IdTipo == 0 && objResultadoUsuSisRolEntEstorg.lstUsuSisRolEntEstorg != null)
                            {
                                if (objResultadoUsuSisRolEntEstorg.lstUsuSisRolEntEstorg.Length > 0) bValida = true;
                            }

                        }
                    }
                }

            }
            return bValida;
        }
    }
}
