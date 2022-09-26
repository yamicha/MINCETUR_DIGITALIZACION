using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Carga;
using EnServiciosDigitalizacion.ArchivoCentral.Carga.Vistas;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Digitalizacion; 
using System.Data;

namespace NeServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
   public class neDocumento : neBase
    {
        DaDocumento _objDa = null;
        public neDocumento(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaDocumento(objCoConexionDb);
        }

        public List<enDocumentoTemporal> DocumentoTemporal_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            return _objDa.DocumentoTemporal_Paginado( ORDEN_COLUMNA,  ORDEN,  FILAS,  PAGINA,  @WHERE, ref auditoria);
        }
        public List<enDocumento> Documento_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            return _objDa.Documento_Paginado(ORDEN_COLUMNA, ORDEN, FILAS, PAGINA, @WHERE, ref auditoria);
        }

        
        public void Documento_Grabar(enDocumento entidad, ref enAuditoria auditoria)
        {
            _objDa.Documento_Grabar(entidad, ref auditoria);
        }

    }
}
