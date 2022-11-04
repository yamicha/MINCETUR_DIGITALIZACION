using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;
using DaServiciosDigitalizacion.Ventanilla.Digitalizacion;


namespace NeServiciosDigitalizacion.Ventanilla.Digitalizacion
{
    public class neDocumento : neBase
    {
        DaDocumento _objDa = null;
        public neDocumento(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaDocumento(objCoConexionDb);
        }
        public List<enDocumento> Documento_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            return _objDa.Documento_Paginado(ORDEN_COLUMNA, ORDEN, FILAS, PAGINA, @WHERE, ref auditoria);
        }

    }
}
