using System;
using System.Collections.Generic;
using System.Data;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Consulta;
using NeServiciosDigitalizacion.Ventanilla.Recepcion;
using EnServiciosDigitalizacion.Ventanilla.Digitalizacion;
using EnServiciosDigitalizacion.Models.Ventanilla;

namespace ApiServiciosDigitalizacion.resource.Ventanilla.Recepcion
{
    public class RecepcionRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private neRecepcion _rule = null;
        public RecepcionRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neRecepcion(_objCoConexionDb);
        }
        public List<enDocumentoVen> Documento_Ventanilla_Pen(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            return _rule.Documento_Ventanilla_Pen(ORDEN_COLUMNA, ORDEN, FILAS, PAGINA, @WHERE, ref auditoria);
        }
        public List<enDocumentoVen> Documento_Ventanilla_GetOne(enDocumentoVen entidad, ref enAuditoria auditoria)
        {
            return _rule.Documento_Ventanilla_GetOne(entidad, ref auditoria);
        }
        public List<enAdjuntos> Expediente_DocumentoGetOne(long ID_EXPE, ref enAuditoria auditoria)
        {
            return _rule.Expediente_DocumentoGetOne(ID_EXPE, ref auditoria);
        }

        public void Expediente_Insertar(ExpedienteModels entidad, ref enAuditoria auditoria)
        {
            _rule.Expediente_Insertar(entidad, ref auditoria);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
