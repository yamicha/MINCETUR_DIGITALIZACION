using System.Collections.Generic;
using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;

namespace NeServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
    public class neRecepcion : neBase
    {
        DaRecepcion _objDa = null;
        public neRecepcion(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaRecepcion(objCoConexionDb);
        }

        public List<enLote> Lote_Listar(enLote entidad, ref enAuditoria auditoria)
        {
            return _objDa.Lote_Listar(entidad, ref auditoria);
        }

    }
}
