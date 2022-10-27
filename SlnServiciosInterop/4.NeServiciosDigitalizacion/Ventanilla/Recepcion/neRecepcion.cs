using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Consulta;
using DaServiciosDigitalizacion.Ventanilla.Recepcion;
using System.Data;
namespace NeServiciosDigitalizacion.Ventanilla.Recepcion
{
    public class neRecepcion: neBase
    {
        DaRecepcion _objDa = null;
        public neRecepcion(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaRecepcion(objCoConexionDb);
        }
        public List<enDocumento> Documento_Ventanilla_Pen(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            return _objDa.Documento_Ventanilla_Pen(ORDEN_COLUMNA, ORDEN, FILAS, PAGINA, @WHERE, ref auditoria);
        }
        public List<enDocumento> Documento_Ventanilla_GetOne(enDocumento entidad,  ref enAuditoria auditoria)
        {
            return _objDa.Documento_Ventanilla_GetOne(entidad, ref auditoria);
        }
    }
}
