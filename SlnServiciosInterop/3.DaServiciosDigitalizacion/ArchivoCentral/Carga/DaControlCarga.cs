using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using Utilitarios.Helpers;
using System.Data;

namespace DaServiciosDigitalizacion.ArchivoCentral.Carga
{
    public class DaControlCarga : daBase
    {
        public DaControlCarga(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            //Constructor
        }
 

   
    }
}
