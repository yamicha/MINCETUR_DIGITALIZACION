using System;
using System.Collections.Generic;
using System.Data;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using NeServiciosDigitalizacion.ArchivoCentral.Digitalizacion;

namespace ApiServiciosDigitalizacion.resource.ArchivoCentral.Digitalizacion
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
        public List<enDocumento_Proceso> Documento_Proceso_Listar(enDocumento_Proceso entidad, ref enAuditoria auditoria)
        {
            return _rule.Documento_Proceso_Listar(entidad, ref auditoria);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
