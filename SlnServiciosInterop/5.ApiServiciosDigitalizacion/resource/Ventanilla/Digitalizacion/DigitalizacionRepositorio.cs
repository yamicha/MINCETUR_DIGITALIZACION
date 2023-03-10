using System;
using System.Collections.Generic;
using System.Data;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;
using EnServiciosDigitalizacion.Models.Ventanilla; 
using NeServiciosDigitalizacion.Ventanilla.Digitalizacion;

namespace ApiServiciosDigitalizacion.resource.Ventanilla.Digitalizacion
{
    public class DigitalizacionRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private neDigitalizacion _rule = null;
        public DigitalizacionRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neDigitalizacion(_objCoConexionDb);
        }
        public List<enLote> Lote_Listar(enLote entidad, ref enAuditoria auditoria)
        {
            return _rule.Lote_Listar(entidad, ref auditoria);
        }

        public void Documento_Digitalizar(enDocumento_Asignado entidad, ref enAuditoria auditoria)
        {
            _rule.Documento_Digitalizar(entidad, ref auditoria);
        }

        public void Documento_Reprocesar(enDocumento_Asignado entidad, ref enAuditoria auditoria)
        {
            _rule.Documento_Reprocesar(entidad, ref auditoria);
        }
        public List<enDocumento_Proceso> Documento_Proceso_Listar(enDocumento_Proceso entidad, ref enAuditoria auditoria)
        {
            return _rule.Documento_Proceso_Listar(entidad, ref auditoria);
        }

        public void Documento_Digitalizado_Validar(DocumentoValidarModel entidad, ref enAuditoria auditoria)
        {
            _rule.Documento_Digitalizado_Validar(entidad, ref auditoria);
        }
        public void Documento_Fedatario_Validar(DocumentoValidarModel entidad, ref enAuditoria auditoria)
        {
            _rule.Documento_Fedatario_Validar(entidad, ref auditoria);
        }

        public void Documento_LoteValidar(DevolucionModel entidad, ref enAuditoria auditoria)
        {
            _rule.Documento_LoteValidar(entidad, ref auditoria);
        }
        public void Documento_Devolver(DevolucionModel entidad, ref enAuditoria auditoria)
        {
            _rule.Documento_Devolver(entidad, ref auditoria);
        }

        public List<enScdDigiUtil> Documento_DigitalizarUniformeSTD(DocumentoValidarModel entidad, ref enAuditoria auditoria)
        {
            return _rule.Documento_DigitalizarUniformeSTD(entidad, ref auditoria);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
