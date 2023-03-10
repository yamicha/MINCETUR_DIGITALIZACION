using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Consulta;
using DaServiciosDigitalizacion.Ventanilla.Recepcion;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;
using EnServiciosDigitalizacion.Models.Ventanilla;

namespace NeServiciosDigitalizacion.Ventanilla.Recepcion
{
    public class neRecepcion: neBase
    {
        DaRecepcion _objDa = null;
        public neRecepcion(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaRecepcion(objCoConexionDb);
        }
        public List<enDocumentoVen> Documento_Ventanilla_Pen(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            return _objDa.Documento_Ventanilla_Pen(ORDEN_COLUMNA, ORDEN, FILAS, PAGINA, @WHERE, ref auditoria);
        }
        public List<enDocumentoVen> Documento_Ventanilla_GetOne(enDocumentoVen entidad,  ref enAuditoria auditoria)
        {
            return _objDa.Documento_Ventanilla_GetOne(entidad, ref auditoria);
        }
        public List<enAdjuntos> Expediente_DocumentoGetOne(long ID_EXPE, ref enAuditoria auditoria)
        {
            return _objDa.Expediente_DocumentoGetOne(ID_EXPE, ref auditoria);
        }

        public void Expediente_Insertar(ExpedienteModels entidad, ref enAuditoria auditoria)
        {
             _objDa.Expediente_Insertar(entidad, ref auditoria);
        }
    }
}
