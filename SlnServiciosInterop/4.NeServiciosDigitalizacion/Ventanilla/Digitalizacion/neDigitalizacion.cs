using System.Collections.Generic;
using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.Ventanilla.Digitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Models.Ventanilla; 
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;

namespace NeServiciosDigitalizacion.Ventanilla.Digitalizacion
{
    public class neDigitalizacion : neBase
    {
        DaDigitalizacion _objDa = null;
        public neDigitalizacion(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaDigitalizacion(objCoConexionDb);
        }

        public List<enLote> Lote_Listar(enLote entidad, ref enAuditoria auditoria)
        {
            return _objDa.Lote_Listar(entidad, ref auditoria);
        }

        public void Documento_Digitalizar(enDocumento_Asignado entidad, ref enAuditoria auditoria)
        {
            _objDa.Documento_Digitalizar(entidad, ref auditoria);
        }

        public void Documento_Reprocesar(enDocumento_Asignado entidad, ref enAuditoria auditoria)
        {
            _objDa.Documento_Reprocesar(entidad, ref auditoria);
        }
        
        public List<enDocumento_Proceso> Documento_Proceso_Listar(enDocumento_Proceso entidad, ref enAuditoria auditoria)
        {
            return _objDa.Documento_Proceso_Listar(entidad, ref auditoria);
        }

        public void Documento_Digitalizado_Validar(DocumentoValidarModel entidad, ref enAuditoria auditoria)
        {
            _objDa.Documento_Digitalizado_Validar(entidad, ref auditoria);
        }

        public void Documento_Fedatario_Validar(DocumentoValidarModel entidad, ref enAuditoria auditoria)
        {
            _objDa.Documento_Fedatario_Validar(entidad, ref auditoria);
        }
        public void Documento_LoteValidar(DevolucionModel entidad, ref enAuditoria auditoria)
        {
            _objDa.Documento_LoteValidar(entidad, ref auditoria);
        }

        public void Documento_Devolver(DevolucionModel entidad, ref enAuditoria auditoria)
        {
            _objDa.Documento_Devolver(entidad, ref auditoria);
        }

    }
}
