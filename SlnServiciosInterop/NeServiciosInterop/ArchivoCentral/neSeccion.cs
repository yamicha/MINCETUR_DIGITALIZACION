using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosMicroformas;
using EnServiciosMicroformas.ArchivoCentral;
using EnServiciosMicroformas; 
using DaServiciosMicroformas.Archivo_Central; 

namespace NeServiciosMicroformas.ArchivoCentral
{
    public class neSeccion : neBase
    {
        DaSeccion _objDa = null;
        public neSeccion(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaSeccion(objCoConexionDb);
        }

        public List<enSeccion> Seccion_Listar(enSeccion objEnSeccion, ref enAuditoria auditoria)
        {
            return this._objDa.Seccion_Listar(objEnSeccion, ref auditoria);
        }
    }
}
