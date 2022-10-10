using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using System.Collections.Generic;

namespace NeServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class neArea : neBase
    {
        DaArea _objDa = null;
        public neArea(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaArea(objCoConexionDb);
        }
        public List<enArea> Area_Listar(enArea objEnSubSerie, ref enAuditoria auditoria)
        {
            return this._objDa.Area_Listar(objEnSubSerie, ref auditoria);
        }
      
    }
}
