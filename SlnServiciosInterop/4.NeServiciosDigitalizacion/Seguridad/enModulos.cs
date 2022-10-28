using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using DaServiciosDigitalizacion.Seguridad; 
using System.Collections.Generic;
using Utilitarios.Helpers.Authorization;

namespace NeServiciosDigitalizacion.Seguridad
{
   public  class enModulos : neBase
    {
        DaModulos _objDa = null;
        public enModulos(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaModulos(objCoConexionDb);
        }
        public List<Utilitarios.Helpers.Authorization.enModulos> Modulos_Listar(Utilitarios.Helpers.Authorization.enModulos objEnSubSerie, ref enAuditoria auditoria)
        {
            return this._objDa.Modulos_Listar(objEnSubSerie, ref auditoria);
        }
    }
}
