using System.Collections.Generic;
using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.Seguridad;
using EnServiciosDigitalizacion;

namespace NeServiciosDigitalizacion.Seguridad
{
    public class neDominio : neBase
    {
        DaDominio _objDa = null;
        public neDominio(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaDominio(objCoConexionDb);
        }
        public List<enDominio> Dominio_Listar(enDominio entidad, ref enAuditoria auditoria)
        {
            return this._objDa.Dominio_Listar(entidad, ref auditoria);
        }
    }
}
