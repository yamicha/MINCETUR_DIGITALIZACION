using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.Ventanilla.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Administracion;
using System.Collections.Generic;

namespace NeServiciosDigitalizacion.Ventanilla.Administracion
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
