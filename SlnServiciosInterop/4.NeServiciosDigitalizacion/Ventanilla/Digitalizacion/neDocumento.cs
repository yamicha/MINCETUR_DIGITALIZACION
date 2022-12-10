using System.Collections.Generic;
using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.Ventanilla.Digitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;


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
        public List<enDocumento_Proceso> DocumentoProceso_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            return _objDa.DocumentoProceso_Paginado(ORDEN_COLUMNA, ORDEN, FILAS, PAGINA, @WHERE, ref auditoria);
        }

        public HashSet<enDocumento> Documento_Exportar(string @WHERE, ref enAuditoria auditoria)
        {
            return _objDa.Documento_Exportar(@WHERE, ref auditoria);
        }
        public enDocumento Documento_ListarUno(enDocumento entidad, ref enAuditoria auditoria)
        {
            return _objDa.Documento_ListarUno(entidad, ref auditoria);
        }
        public List<enAdjuntos> DocumentoAdjuntos_Listar(enAdjuntos entidad, ref enAuditoria auditoria)
        {
            return _objDa.DocumentoAdjuntos_Listar(entidad, ref auditoria);
        }
        public void DocumentoAdjuntos_Eliminar(enAdjuntos entidad, ref enAuditoria auditoria)
        {
            _objDa.DocumentoAdjuntos_Eliminar(entidad, ref auditoria);
        }
        public void DocumentoAdjuntos_Actualizar(enAdjuntos entidad, ref enAuditoria auditoria)
        {
            _objDa.DocumentoAdjuntos_Actualizar(entidad, ref auditoria);
        }
        public void DocumentoAdjuntos_Insertar(enAdjuntos entidad, ref enAuditoria auditoria)
        {
            _objDa.DocumentoAdjuntos_Insertar(entidad, ref auditoria);
        }
        public List<enDocumento_Obs> DocumentoObservado_Listar(enDocumento_Obs entidad, ref enAuditoria auditoria)
        {
            return _objDa.DocumentoObservado_Listar(entidad, ref auditoria);
        }
        public void Documento_AsignacionInsertar(enDocumento entidad, ref enAuditoria auditoria)
        {
            _objDa.Documento_AsignacionInsertar(entidad, ref auditoria);
        }
        public void Documento_AsignacionActualizar(enDocumento entidad, ref enAuditoria auditoria)
        {
            _objDa.Documento_AsignacionActualizar(entidad, ref auditoria);
        }

    }
}
