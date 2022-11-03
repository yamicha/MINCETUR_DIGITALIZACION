using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Consulta;
using DaServiciosDigitalizacion.Ventanilla.Consulta;
using System.Data;

namespace NeServiciosDigitalizacion.Ventanilla.Consulta
{
    public class neDocumento: neBase
    {
        DaDocumentos _objDa = null;
        public neDocumento(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaDocumentos(objCoConexionDb);
        }
        public List<enExpediente> Documento_Ventanilla(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            return _objDa.Documento_Ventanilla(ORDEN_COLUMNA, ORDEN, FILAS, PAGINA, @WHERE, ref auditoria);
        }
    }
}
